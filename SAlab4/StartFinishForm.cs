using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class StartFinishForm : Form
    {
        StartFinishTests startFinishTests = new StartFinishTests();
        private List<Question> questions = new List<Question>();

        public StartFinishForm()
        {
            InitializeComponent();
            loadQuestions();
            writeComboBoxes();
            checkButtons();
        }

        private void loadQuestions()
        {
            questions = startFinishTests.getQuestions();
        }

        private void writeComboBoxes()
        {
            if (questions != null)
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    if (!questions[i].isActive)
                    {
                        noActiveComboBox1.Items.Add($"{questions[i].id}={questions[i].Quest}");
                    }
                    else
                    {
                        activeComboBox2.Items.Add($"{questions[i].id}={questions[i].Quest}");
                    }
                }
            }
        }

        private void startQuest_Click(object sender, EventArgs e)
        {
            if (noActiveComboBox1.SelectedItem != null)
            {
                string item = noActiveComboBox1.SelectedItem.ToString();
                string[] SelectedItem = item.Split('=');
                int currentIndex = noActiveComboBox1.SelectedIndex;
                for (int i = 0; i < questions.Count; i++)
                {
                    if (Convert.ToInt32(SelectedItem[0]) == questions[i].id)
                    {
                        questions[i].isActive = true;
                        noActiveComboBox1.Items.RemoveAt(currentIndex);
                    }
                }
                startFinishTests.rewriteStartOrFinish(questions);
                activeComboBox2.Items.Add(item);
                activeComboBox2.Text = "";
                label3.Text = "Тест розпочато";
                checkButtons();
            }
            
        }

        private void Start_FinishForm_Load(object sender, EventArgs e)
        {
            
        }

        private void FinishQuest_Click(object sender, EventArgs e)
        {
            if (activeComboBox2.SelectedItem != null)
            {
                string item = activeComboBox2.SelectedItem.ToString();
                string[] SelectedItem = item.Split('=');
                int currentIndex = activeComboBox2.SelectedIndex;
                for (int i = 0; i < questions.Count; i++)
                {
                    if (Convert.ToInt32(SelectedItem[0]) == questions[i].id)
                    {
                        questions[i].isActive = false;
                        activeComboBox2.Items.RemoveAt(currentIndex);
                    }
                }
                startFinishTests.rewriteStartOrFinish(questions);
                noActiveComboBox1.Items.Add(item);
                noActiveComboBox1.Text = "";
                label3.Text = "Тест зупинено";
                checkButtons();
            }
        }

        private void checkButtons()
        {
            button1.Enabled = noActiveComboBox1.Items.Count > 0;
            button2.Enabled = activeComboBox2.Items.Count > 0;
        }
    }
}

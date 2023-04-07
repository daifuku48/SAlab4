using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class StartFinishForm : Form
    {
        private List<Question> questions;

        public StartFinishForm()
        {
            InitializeComponent();
            loadQuestions();
            writeComboBoxes();
            checkButtons();
        }

        private void loadQuestions()
        {
            string json = File.ReadAllText("questions.txt");
            questions = JsonConvert.DeserializeObject<List<Question>>(json) ?? new List<Question>(); // Додали перевірку на null
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
                rewriteFile();
                activeComboBox2.Items.Add(item);
                activeComboBox2.Text = "";
                label3.Text = "Тест розпочато";
                checkButtons();
            }
            
        }

        private void rewriteFile()
        {
            string json = JsonConvert.SerializeObject(questions);
            File.WriteAllText("questions.txt", json);
        }

        private void Start_FinishForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
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
                rewriteFile();
                noActiveComboBox1.Items.Add(item);
                noActiveComboBox1.Text = "";
                label3.Text = "Тест зупинено";
                checkButtons();
            }
        }

        private void checkButtons()
        {
            if (activeComboBox2.Items.Count == 0)
            {
                button2.Enabled = false;
            }
            if (activeComboBox2.Items.Count != 0)
            {
                button2.Enabled = true;
            }
            if (noActiveComboBox1.Items.Count == 0)
            {
                button1.Enabled = false;
            }
            if (noActiveComboBox1.Items.Count != 0)
            {
                button1.Enabled = true;
            }
        }
    }
}

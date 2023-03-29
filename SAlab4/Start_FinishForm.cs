using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class Start_FinishForm : Form
    {
        public Start_FinishForm()
        {
            InitializeComponent(); 
            string json = File.ReadAllText("questions.txt");
            List<Question> ques = JsonConvert.DeserializeObject<List<Question>>(json);
            for (int i = 0; i < ques.Count; i++)
            {
                if (!ques[i].isActive)
                {
                    noActiveComboBox1.Items.Add($"{ques[i].id}={ques[i].Quest}");
                } else
                {
                    activeComboBox2.Items.Add($"{ques[i].id}={ques[i].Quest}");
                }
            }
            checkButtons();
        }

        private void startQuest_Click(object sender, EventArgs e)
        {
            if (noActiveComboBox1.SelectedItem != null)
            {
                string item = noActiveComboBox1.SelectedItem.ToString();
                string[] SelectedItem = item.Split('=');
                int currentIndex = noActiveComboBox1.SelectedIndex;
                string json = File.ReadAllText("questions.txt");
                List<Question> ques = JsonConvert.DeserializeObject<List<Question>>(json);
                for (int i = 0; i < ques.Count; i++)
                {
                    if (Convert.ToInt32(SelectedItem[0]) == ques[i].id)
                    {
                        ques[i].isActive = true;
                        noActiveComboBox1.Items.RemoveAt(currentIndex);
                    }
                }
                string js = JsonConvert.SerializeObject(ques);
                File.WriteAllText("questions.txt", js);
                activeComboBox2.Items.Add(item);
                activeComboBox2.Text = "";
                label3.Text = "Тест розпочато";
                checkButtons();
            }
            
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
                string json = File.ReadAllText("questions.txt");
                List<Question> ques = JsonConvert.DeserializeObject<List<Question>>(json);
                for (int i = 0; i < ques.Count; i++)
                {
                    if (Convert.ToInt32(SelectedItem[0]) == ques[i].id)
                    {
                        ques[i].isActive = false;
                        activeComboBox2.Items.RemoveAt(currentIndex);
                    }
                }
                string js = JsonConvert.SerializeObject(ques);
                File.WriteAllText("questions.txt", js);
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

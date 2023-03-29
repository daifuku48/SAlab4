using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class AddTest : Form
    {
        public AddTest()
        {
            InitializeComponent();
        }

        private bool checking()
        {
            if (questionTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Питання пусте");
                return false;
            } else if (answer1TextBox.Text.Trim() == "")
            {
                MessageBox.Show("Варіант 1 пустий");
                return false;
            } else if (answer2TextBox.Text.Trim() == "")
            {
                MessageBox.Show("Варіант 2 пустий");
                return false;
            } else if (answer3TextBox.Text.Trim() == "")
            {
                MessageBox.Show("Варіант 3 пустий");
                return false;
            } else if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Оберіть правильний варіант відповіді");
                return false;
            }
            return true;
        }

        private void SaveTest_Click(object sender, EventArgs e)
        {
            var check = checking();
            if (!check)
                return;
            var question = questionTextBox.Text.Trim();
            var answer1 = answer1TextBox.Text.Trim();
            var answer2 = answer2TextBox.Text.Trim();
            var answer3 = answer3TextBox.Text.Trim();
            string ans1 = "", ans2 = "", ans3 = ""; 
            if (radioButton1.Checked)
            {
                ans1 = "1";
                ans2 = "0";
                ans3 = "1";
            } else if (radioButton2.Checked)
            {
                ans1 = "0";
                ans2 = "1";
                ans3 = "0";
            } else if (radioButton3.Checked)
            {
                ans1 = "0";
                ans2 = "1";
                ans3 = "0";
            }
            List<string> answer1List = new List<string>();
            answer1List.Add(answer1);
            answer1List.Add(ans1);
            List<string> answer2List = new List<string>();
            answer2List.Add(answer2);
            answer2List.Add(ans2);
            List<string> answer3List = new List<string>();
            answer3List.Add(answer3);
            answer3List.Add(ans3);
            Question que = new Question(question, answer1List, answer2List, answer3List);
            string json = File.ReadAllText("questions.txt");
            // Deserialize the JSON into an array of User objects
            List<Question> ques = JsonConvert.DeserializeObject<List<Question>>(json);
            if (ques != null)
            {
                que.id = ques[ques.Count - 1].id + 1;

            } else
            {
                ques = new List<Question>();
            }
            ques.Add(que);
            string js = JsonConvert.SerializeObject(ques);
            File.WriteAllText("questions.txt", js);
            label7.Text = "Питання збережено";
            questionTextBox.Text = "";
            answer1TextBox.Text = "";
            answer2TextBox.Text = "";
            answer3TextBox.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }
    }
}

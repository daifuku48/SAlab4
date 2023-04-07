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
    public partial class Redag : Form
    {
        private List<Question> questions;
        public Redag()
        {
            InitializeComponent();
            string item = Data.questionForRedag;
            string[] SelectedItem = item.Split('=');
            readFile();
            
            for (int i = 0; i < questions.Count; i++)
            {
               if (questions[i].id == Convert.ToInt32(SelectedItem[0]))
                {
                    questionTextBox.Text = questions[i].Quest;
                    answer1TextBox.Text = questions[i].answer1[0];
                    answer2TextBox.Text = questions[i].answer2[0];
                    answer3TextBox.Text = questions[i].answer3[0];
                    if (questions[i].answer1[1] == Data.CORRECT_ANSWER)
                        radioButton1.Checked = true;
                    else if (questions[i].answer2[1] == Data.CORRECT_ANSWER)
                        radioButton2.Checked = true;
                    else if (questions[i].answer3[1] == Data.CORRECT_ANSWER)
                        radioButton3.Checked = true;
                    break;
                }
            }
        }

        private void readFile()
        {
            string json = File.ReadAllText("questions.txt");
            questions = JsonConvert.DeserializeObject<List<Question>>(json);
        }

        private void rewriteFile()
        {
            string json = JsonConvert.SerializeObject(questions);
            File.WriteAllText("questions.txt", json);
        }

        private void Redag_Load(object sender, EventArgs e)
        {

        }

        private void redag_Click(object sender, EventArgs e)
        {
            string item = Data.questionForRedag;
            string[] SelectedItem = item.Split('=');
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].id == Convert.ToInt32(SelectedItem[0]))
                {
                    questions[i].Quest = questionTextBox.Text;
                    questions[i].answer1[0] = answer1TextBox.Text;
                    questions[i].answer2[0] = answer2TextBox.Text;
                    questions[i].answer3[0] = answer3TextBox.Text;
                    if (radioButton1.Enabled)
                        questions[i].answer1[1] = Data.CORRECT_ANSWER;
                    else if (!radioButton1.Enabled)
                        questions[i].answer1[1] = Data.WRONG_ANSWER;
                    else if (radioButton2.Enabled)
                        questions[i].answer2[1] = Data.CORRECT_ANSWER;
                    else if (!radioButton2.Enabled)
                        questions[i].answer2[1] = Data.WRONG_ANSWER;
                    else if (radioButton3.Enabled)
                        questions[i].answer3[1] = Data.CORRECT_ANSWER;
                    else if (!radioButton3.Enabled)
                        questions[i].answer3[1] = Data.WRONG_ANSWER;
                    break;
                }
            }
            rewriteFile();
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            string item = Data.questionForRedag;
            string[] SelectedItem = item.Split('=');
            List<Question> newQues = new List<Question>();
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].id != Convert.ToInt32(SelectedItem[0]))
                {
                    newQues.Add(questions[i]);
                }
            }
            string js = JsonConvert.SerializeObject(newQues);
            File.WriteAllText("questions.txt", js);
            this.Close();
        }
    }
}

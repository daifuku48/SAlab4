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
        public Redag()
        {
            InitializeComponent();
            string item = Data.questionForRedag;
            string[] SelectedItem = item.Split('=');
            string json = File.ReadAllText("questions.txt");
            List<Question> ques = JsonConvert.DeserializeObject<List<Question>>(json);
            for (int i = 0; i < ques.Count; i++)
            {
               if (ques[i].id == Convert.ToInt32(SelectedItem[0]))
                {
                    questionTextBox.Text = ques[i].Quest;
                    answer1TextBox.Text = ques[i].answer1[0];
                    answer2TextBox.Text = ques[i].answer2[0];
                    answer3TextBox.Text = ques[i].answer3[0];
                    if (ques[i].answer1[1] == Data.CORRECT_ANSWER)
                        radioButton1.Enabled = true;
                    else if (ques[i].answer2[1] == Data.CORRECT_ANSWER)
                        radioButton2.Enabled = true;
                    else if (ques[i].answer3[1] == Data.CORRECT_ANSWER)
                        radioButton3.Enabled = true;
                    break;
                }
            }
        }

        private void Redag_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string item = Data.questionForRedag;
            string[] SelectedItem = item.Split('=');
            string json = File.ReadAllText("questions.txt");
            List<Question> ques = JsonConvert.DeserializeObject<List<Question>>(json);
            for (int i = 0; i < ques.Count; i++)
            {
                if (ques[i].id == Convert.ToInt32(SelectedItem[0]))
                {
                    ques[i].Quest = questionTextBox.Text;
                    ques[i].answer1[0] = answer1TextBox.Text;
                    ques[i].answer2[0] = answer2TextBox.Text;
                    ques[i].answer3[0] = answer3TextBox.Text;
                    if (radioButton1.Enabled)
                        ques[i].answer1[1] = Data.CORRECT_ANSWER;
                    else if (!radioButton1.Enabled)
                        ques[i].answer1[1] = Data.WRONG_ANSWER;
                    else if (radioButton2.Enabled)
                        ques[i].answer2[1] = Data.CORRECT_ANSWER;
                    else if (!radioButton2.Enabled)
                        ques[i].answer2[1] = Data.WRONG_ANSWER;
                    else if (radioButton3.Enabled)
                        ques[i].answer3[1] = Data.CORRECT_ANSWER;
                    else if (!radioButton3.Enabled)
                        ques[i].answer3[1] = Data.WRONG_ANSWER;
                    break;
                }
            }
            string js = JsonConvert.SerializeObject(ques);
            File.WriteAllText("questions.txt", js);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string item = Data.questionForRedag;
            string[] SelectedItem = item.Split('=');
            string json = File.ReadAllText("questions.txt");
            List<Question> ques = JsonConvert.DeserializeObject<List<Question>>(json);
            List<Question> newQues = new List<Question>();
            for (int i = 0; i < ques.Count; i++)
            {
                if (ques[i].id != Convert.ToInt32(SelectedItem[0]))
                {
                    newQues.Add(ques[i]);
                }
            }
            string js = JsonConvert.SerializeObject(newQues);
            File.WriteAllText("questions.txt", js);
            this.Close();
        }
    }
}

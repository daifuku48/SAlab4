using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class ResultsForm : Form
    {
        LookingResults lookingResults = new LookingResults();
        List<int> ids = new List<int>();
        List<Question> questions;
        public ResultsForm()
        {
            InitializeComponent();
            loadQuestions();
            writeComboBox();
        }

        private void loadQuestions()
        {
            questions = lookingResults.getAllQuestions();
        }

        private void writeComboBox()
        {
            if (questions != null)
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    if (questions[i].emailsForCheck != null)
                    {
                        for (int j = 0; j < questions[i].emailsForCheck.Count; j++)
                        {
                            if (questions[i].emailsForCheck[j] == Data.currentUser.Email)
                            {
                                comboBox1.Items.Add($"{questions[i].Quest}");
                                ids.Add(questions[i].id);
                            }
                        }
                    }
                }
            }
        }

        private void start_test_button_Click(object sender, EventArgs e)
        {
            string quest = comboBox1.Text;
            int index = comboBox1.SelectedIndex;
            int id = 0;
            for (int i = 0; i < ids.Count; i++)
            {
                if (index == i)
                {
                    id = ids[i];
                }
            }
            Question currentQuest = null;
            int answer1 = 0, answer2 = 0, answer3 = 0;
            double totalAnswers = 0.0;
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].id == id)
                {
                   currentQuest = questions[i];
                   break;
                }
            }
            if (currentQuest != null)
            {
                for (int i = 0; i < currentQuest.answers.Count; i++)
                {
                    if (currentQuest.answers[i].Ans == 2)
                    {
                        answer2 += 1;
                        totalAnswers += 1.0;
                    } else if (currentQuest.answers[i].Ans == 1)
                    {
                        answer1 += 1;
                        totalAnswers += 1.0;
                    } else if (currentQuest.answers[i].Ans == 3)
                    {
                        answer3 += 1;
                        totalAnswers += 1.0;
                    }
                }
                writeRightAnswer(currentQuest);
                write_answers(currentQuest, answer1, answer2, answer3, totalAnswers);
            }
        }

        private void writeRightAnswer(Question question)
        {
            if (question.answer1[1] == "1")
            {
                label2.Text = "Вірна відповідь";
                label3.Text = "";
                label4.Text = "";
            }
            else if (question.answer2[1] == "1")
            {
                label2.Text = "";
                label3.Text = "Вірна відповідь";
                label4.Text = "";
            }    
                
            else if (question.answer3[1] == "1")
            {
                label2.Text = "";
                label3.Text = "";
                label4.Text = "Вірна відповідь";
            }
        }

        private void write_answers(Question quest,int answer1, int answer2, int answer3, double totalAnswers)
        {
            double ans1 = answer1 / totalAnswers * 100;
            answer1_label.Text =quest.answer1[0] + ": " + ans1.ToString() + " %" ;
            double ans2 = answer2 / totalAnswers * 100;
            answer2_label.Text = quest.answer2[0] + ": " + ans2.ToString() + " %";
            double ans3 = answer3 / totalAnswers * 100;
            answer3_label.Text = quest.answer3[0] + ": " + ans3.ToString() + " %";
        }

        private void Results_Load(object sender, EventArgs e)
        {

        }
    }
}

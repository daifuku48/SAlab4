using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class TestForm : Form
    {

        List<Question> questions = new List<Question>();
        public TestForm()
        {
            InitializeComponent();
            initQuestion();
        }

        private void initQuestion()
        {
            question.Text = Data.currentTest.Quest;
            answer1.Text = Data.currentTest.answer1[0];
            answer2.Text = Data.currentTest.answer2[0];
            answer3.Text = Data.currentTest.answer3[0];
            for (int i = 0; i < Data.currentTest.comments.Count; i++)
            {
                listBox1.Items.Add($"{Data.currentTest.comments[i].Name}: {Data.currentTest.comments[i].Text}");
            }
        }
        
        private int GetSelectedAnswerIndex()
        {
            if (radioButton1.Checked)
            {
                return 1;
            }
            else if (radioButton2.Checked)
            {
                return 2;
            }
            else if (radioButton3.Checked)
            {
                return 3;
            }
            return -1;
        }

        private void answer_Click(object sender, EventArgs e)
        {
            var ans = GetSelectedAnswerIndex();
            Answer answer = new Answer(Data.currentUser.Email, Data.currentTest.id, Data.currentTest.Quest, ans);
            Data.currentTest.answers.Add(answer);
            Data.currentTest.emailsForCheck.Add(Data.currentUser.Email);
            questions = FileOperating.readFileQuestions();
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].id == Data.currentTest.id)
                {
                    questions[i] = Data.currentTest;
                }
            }
            FileOperating.rewriteFileQuestions(questions);
            MessageBox.Show("Відповідь прийнято");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addComment();  
        }

        private void addComment()
        {
            string text = textBox1.Text.Trim();
            Comment ans = new Comment(Data.currentUser.Username, text);
            Data.currentTest.comments.Add(ans);
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].id == Data.currentTest.id)
                {
                    questions[i].comments.Add(ans);
                }
            }
            FileOperating.rewriteFileQuestions(questions);
            listBox1.Items.Add($"{ans.Name}: {ans.Text}");
        }
    }
}

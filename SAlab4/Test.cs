using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            question.Text = Data.currentTest.Quest;
            answer1.Text = Data.currentTest.answer1[0];
            answer2.Text = Data.currentTest.answer2[0];
            answer3.Text = Data.currentTest.answer3[0];
            for (int i = 0; i < Data.currentTest.comments.Count; i++)
            {
                listBox1.Items.Add($"{Data.currentTest.comments[i].Name}: {Data.currentTest.comments[i].Text}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ans = 0;
            if (radioButton1.Enabled)
            {
                ans = 1;
            } else if (radioButton2.Enabled)
            {
                ans = 2;
            } else if (radioButton3.Enabled)
            {
                ans = 3;
            }
            Answer answer = new Answer(Data.currentUser.Email, Data.currentTest.id, Data.currentTest.Quest, ans);
            MessageBox.Show("Відповідь прийнято");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();
            Comment ans = new Comment(Data.currentUser.Username, text);
            Data.currentTest.comments.Add(ans);
            listBox1.Items.Add($"{ans.Name}: {ans.Text}");
        }
    }
}

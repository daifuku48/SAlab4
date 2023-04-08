using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class RedagingForm : Form
    {
        public RedagingForm()
        {
            InitializeComponent();
            List<Question> questions = FileOperating.readFileQuestions();
            for (int i = 0; i < questions.Count; i++)
            {
               redagComboBox.Items.Add($"{questions[i].id}={questions[i].Quest}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Data.questionForRedag = redagComboBox.SelectedItem.ToString();
            RedagForm form = new RedagForm();
            form.Show();
        }
    }
}

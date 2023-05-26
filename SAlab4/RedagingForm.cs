using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class RedagingForm : Form
    {
        Repository repository = new Repository();
        public RedagingForm()
        {
            InitializeComponent();
            List<Question> questions = repository.readFileQuestions();
            for (int i = 0; i < questions.Count; i++)
            {
               redagComboBox.Items.Add($"{questions[i].id}={questions[i].Quest}");
            }
        }

        private void choosingQuestion_Click(object sender, EventArgs e)
        {
            this.Close();
            Data.questionForRedag = redagComboBox.SelectedItem.ToString();
            RedagForm form = new RedagForm();
            form.Show();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class StartTestsForm : Form
    {
        Repository repository = new Repository();
        List<int> ids = new List<int>();
        List<Question> questions = new List<Question>();
        public StartTestsForm()
        {
            InitializeComponent();
            initComboBox();
        }

        private void initComboBox()
        {
            questions = repository.readFileQuestions();
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].isActive)
                {
                    bool check = true;
                    for (int j = 0; j < questions[i].emailsForCheck.Count; j++)
                    {
                        if (Data.currentUser.Email == questions[i].emailsForCheck[j])
                        {
                            check = false;
                        }
                    }
                    if (check)
                    {
                        comboBox1.Items.Add($"{questions[i].Quest}");
                        ids.Add(questions[i].id);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void start_test_button_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Тест не обрано");
                return;
            }
            int index = comboBox1.SelectedIndex;
            int id = 0;
            for (int i = 0; i < ids.Count; i++)
            {
                if (index == i)
                {
                    id = ids[i];
                }
            }
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].id == id)
                {
                    Data.currentTest = questions[i];
                    break;
                }
            }
            openFormTest();
        }

        private void openFormTest()
        {
            TestForm form = new TestForm();
            MessageBox.Show("Тест розпочато");
            form.Show();
            this.Close();
        }
    }
}

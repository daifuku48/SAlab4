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
    public partial class Tests : Form
    {
        List<int> ids = new List<int>();
        public Tests()
        {
            InitializeComponent();
            string item = Data.questionForRedag;
            string[] SelectedItem = item.Split('=');
            string json = File.ReadAllText("questions.txt");
            List<Question> ques = JsonConvert.DeserializeObject<List<Question>>(json);
            for (int i = 0; i < ques.Count; i++)
            {
                if (ques[i].isActive)
                {
                    comboBox1.Items.Add(ques[i]);
                    ids.Add(ques[i].id);
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
                if (index == ids[i])
                {
                    id = ids[i];
                }
            }
            string json = File.ReadAllText("questions.txt");
            List<Question> ques = JsonConvert.DeserializeObject<List<Question>>(json);
            for (int i = 0; i < ques.Count; i++)
            {
                if (ques[i].id == id)
                {
                    Data.currentTest = ques[i];

                    break;
                }
            }
        }
    }
}

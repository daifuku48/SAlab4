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
    public partial class Redaging : Form
    {
        public Redaging()
        {
            InitializeComponent();
            string json = File.ReadAllText("questions.txt");
            List<Question> ques = JsonConvert.DeserializeObject<List<Question>>(json);
            for (int i = 0; i < ques.Count; i++)
            {
               redagComboBox.Items.Add($"{ques[i].id}={ques[i].Quest}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Data.questionForRedag = redagComboBox.SelectedItem.ToString();
            Redag form = new Redag();
            form.Show();
        }
    }
}

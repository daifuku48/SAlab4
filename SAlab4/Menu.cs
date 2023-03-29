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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void addTest_Button(object sender, EventArgs e)
        {
            AddTest form = new AddTest();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Start_FinishForm form = new Start_FinishForm();
            form.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}

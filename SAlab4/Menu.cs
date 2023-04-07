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
            if (!Data.currentUser.Roles[0].Contains("admin"))
            {
                setInvisibleAdminButtons();
            }
        }
        
        private void setInvisibleAdminButtons()
        {
            button1.Visible = false;
            button2.Visible = false;
            button5.Visible = false;
        }

        private void addTest_Button(object sender, EventArgs e)
        {
            AddTest form = new AddTest();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartFinishForm form = new StartFinishForm();
            form.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Redaging form = new Redaging();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Tests form = new Tests();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Results form = new Results();
            form.Show();
        }
    }
}

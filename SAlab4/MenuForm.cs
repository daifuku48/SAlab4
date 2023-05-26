using System;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class MenuForm : Form
    {
        public MenuForm()
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
            AddTestForm form = new AddTestForm();
            form.Show();
        }

        private void Start_Finish_Button(object sender, EventArgs e)
        {
            StartFinishForm form = new StartFinishForm();
            form.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RedagingForm_Button(object sender, EventArgs e)
        {
            RedagingForm form = new RedagingForm();
            form.Show();
        }

        private void Start_test_Button(object sender, EventArgs e)
        {
            StartTestsForm form = new StartTestsForm();
            form.Show();
        }

        private void Results_Button(object sender, EventArgs e)
        {
            ResultsForm form = new ResultsForm();
            form.Show();
        }
    }
}

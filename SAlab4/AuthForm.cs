using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SAlab4
{
    public partial class AuthForm : Form
    {
        Repository repository = new Repository();
        public AuthForm()
        {
            InitializeComponent();
        }

        private bool checkSignIn()
        {
            if (nameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Name text is empty");
                return false;
            }
            else if (nameTextBox.Text.Trim().Length < 3)
            {
                MessageBox.Show("Name text less then 3 symbols");
                return false;
            }
            else if (emailSign.Text.Trim() == "")
            {
                MessageBox.Show("Email text is empty");
                return false;
            }
            else if (emailSign.Text.Trim().Length < 3)
            {
                MessageBox.Show("Email text less then 3 symbols");
                return false;
            } else if (passwordSignIn.Text.Trim() == "")
            {
                MessageBox.Show("Password is empty");
                return false;
            } else if (passwordSignIn.Text.Trim().Length < 3)
            {
                MessageBox.Show("Password less then 3 symbols");
                return false;
            }
            return true;
        }

        private bool checkLogIn()
        {
            if (emailLogIn.Text.Trim() == "")
            {
                MessageBox.Show("Email text is empty");
                return false;
            } else if (emailLogIn.Text.Trim().Length < 3)
            {
                MessageBox.Show("Email text less then 3 symbols");
                return false;
            } else if (passwordLogIn.Text.Trim() == "")
            {
                MessageBox.Show("Password is empty");
                return false;
            } else if (passwordLogIn.Text.Trim().Length < 3)
            {
                MessageBox.Show("Password less then 3 symbols");
                return false;
            }
            return true;
        }


        private void singIn_Click(object sender, EventArgs e)
        {
            bool check = checkSignIn();
            if (!check)
                return;
            List<string> listRoles = new List<string>() { "user" };
            Data.currentUser = new User(nameTextBox.Text, emailSign.Text, passwordSignIn.Text, listRoles);
            repository.signMember();
            MessageBox.Show("Користувача зареєстровано");
            MenuForm form = new MenuForm();
            this.Hide();
            form.Show();
        }

        private void Auth_Button_Click(object sender, EventArgs e)
        {
            bool checkLog = checkLogIn();
            if (!checkLog)
                return;
            var checkAuth = repository.loginMember(emailLogIn.Text.Trim(), passwordLogIn.Text.Trim());
            if (!checkAuth)
            {
                MessageBox.Show("Користувача з даним або емейлом або паролем не існує");
                return;
            }
            MessageBox.Show("Авторизація прошла успішно");
            MenuForm form = new MenuForm();
            this.Hide();
            form.Show();
        }

        private void passwordLogIn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Auth : Form
    {
        public Auth()
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
            string json = File.ReadAllText("users.txt");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            if (users != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Email == Data.currentUser.Email)
                    {
                        MessageBox.Show("Користувач з даним емейлом існує");
                        return;
                    }
                }
                users = new List<User>();
                users.Add(Data.currentUser);
            }
            else
            {
                users = new List<User>();
                users.Add(Data.currentUser);
            }
                string js = JsonConvert.SerializeObject(users);
            File.WriteAllText("users.txt", js);
            MessageBox.Show("Користувача зареєстровано");
            Menu form = new Menu();
            this.Hide();
            form.Show();
        }

        private bool login()
        {
            string json = File.ReadAllText("users.txt");

            // Deserialize the JSON into an array of User objects
            User[] users = JsonConvert.DeserializeObject<User[]>(json);

            // Find the user with matching login and password
            foreach (User user in users)
            {
                if (user.Email == emailLogIn.Text.Trim() && user.Password == passwordLogIn.Text.Trim())
                {
                    Data.currentUser = user;
                    return true; // Login successful
                }
            }

            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var check = login();
            if (!check)
                MessageBox.Show("Користувача з даним або емейлом або паролем не існує");
            MessageBox.Show("Авторизація прошла успішно");
            Menu form = new Menu();
            this.Hide();
            form.Show();
        }

        private void passwordLogIn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

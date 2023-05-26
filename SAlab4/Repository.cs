using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SAlab4
{
    interface IRepository
    {
        void rewriteFileQuestions(List<Question> questions);
        List<Question> readFileQuestions();
        void signMember();

        bool loginMember(string email, string password);
    }
    public class Repository : IRepository
    {
        public void rewriteFileQuestions(List<Question> questions)
        {
            try
            {
                string json = JsonConvert.SerializeObject(questions);
                File.WriteAllText("questions.txt", json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося зберегти: {ex.Message}");
            }
        }

        public List<Question> readFileQuestions()
        {
            try
            {
                string json = File.ReadAllText("questions.txt");
                List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(json) ?? new List<Question>();
                return questions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося завантажити: {ex.Message}");
                List<Question> questions = new List<Question>();
                return questions;
            }
        }

        public void signMember()
        {
            try
            {
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
                    users.Add(Data.currentUser);
                }
                else
                {
                    users = new List<User>();
                    users.Add(Data.currentUser);
                }
                string js = JsonConvert.SerializeObject(users);
                File.WriteAllText("users.txt", js);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося завантажити: {ex.Message}");
            }
        }

        public bool loginMember(string email, string password)
        {
            try
            {
                string json = File.ReadAllText("users.txt");

                User[] users = JsonConvert.DeserializeObject<User[]>(json);

                if (users != null)
                {
                    foreach (User user in users)
                    {
                        if (user.Email == email && user.Password == password)
                        {
                            Data.currentUser = user;
                            return true; // Login successful
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося завантажити: {ex.Message}");
                return false;
            }
        }
    }
}

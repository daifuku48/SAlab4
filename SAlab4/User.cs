using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SAlab4
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }

        public User()
        {
            Username = "";
            Password = "";
            Email = "";
            Roles = null;
        }

        public User(string username, string email, string password,  List<string> roles)
        {
            Username = username;
            Password = password;
            Email = email;
            Roles = roles;
        }

        public static User LoadFromFile(string filename)
        {
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<User>(json);
        }

        public void SaveToFile(string filename)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(filename, json);
        }
    }
}

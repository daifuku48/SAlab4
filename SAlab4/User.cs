using System.Collections.Generic;

namespace SAlab4
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();

        public User(string username, string email, string password, List<string> roles)
        {
            Username = username;
            Password = password;
            Email = email;
            Roles = roles;
        }
    }
}

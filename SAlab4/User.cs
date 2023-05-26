using System.Collections.Generic;

namespace SAlab4
{
    interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        List<string> Roles { get; set; }
    }
    public class User : IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public User(string username, string email, string password, List<string> roles)
        {
            UserName = username;
            Password = password;
            Email = email;
            Roles = roles;
        }
    }
}

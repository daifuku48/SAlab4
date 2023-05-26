using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAlab4
{
    interface IAuth
    {
        void signIn();
        bool logIn(string email, string password);
    }
    public class Auth : IAuth
    {
        Repository repository = new Repository();
        public bool logIn(string email, string password)
        {
            return repository.loginMember(email, password);
        }

        public void signIn()
        {
            repository.signMember();
        }
    }
}

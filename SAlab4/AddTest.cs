using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAlab4
{
    interface IAddTest{
        void addTest(List<Question> questions);
    }
    public class AddTest : IAddTest
    {
        Repository repository = new Repository();
        public void addTest(List<Question> questions)
        {
            repository.rewriteFileQuestions(questions);
        }
    }
}

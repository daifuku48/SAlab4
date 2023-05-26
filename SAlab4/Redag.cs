using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAlab4
{
    interface IRedag
    {
        List<Question> GetQuestions();
        void rewriteTests(List<Question> question);
    }
    public class Redag : IRedag
    {
        Repository repository = new Repository();

        public List<Question> GetQuestions()
        {
            return repository.readFileQuestions();
        }

        public void rewriteTests(List<Question> question)
        {
            repository.rewriteFileQuestions(question);
        }
    }
}

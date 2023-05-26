using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAlab4
{
    interface ITesting
    {
        List<Question> getAllQuestions();
        void AddAnswer(List<Question> questions);
    }
    public class Testing : ITesting
    {
        Repository repository = new Repository();
        public void AddAnswer(List<Question> questions)
        {
            repository.rewriteFileQuestions(questions);
        }

        public List<Question> getAllQuestions()
        {
            return repository.readFileQuestions();
        }
    }
}

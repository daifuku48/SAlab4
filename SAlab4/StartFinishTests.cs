using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAlab4
{
    interface IStartFinishTests
    {
        List<Question> getQuestions();
        void rewriteStartOrFinish(List<Question> questions);
    }
    public class StartFinishTests : IStartFinishTests
    {
        Repository repository = new Repository();

        public List<Question> getQuestions()
        {
            return repository.readFileQuestions();
        }

        public void rewriteStartOrFinish(List<Question> questions)
        {
            repository.rewriteFileQuestions(questions);
        }
    }
}

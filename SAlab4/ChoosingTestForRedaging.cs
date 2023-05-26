using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAlab4
{
    interface IChoosingTestForRedaging
    {
        List<Question> getAllQuestions();
    }
    public class ChoosingTestForRedaging : IChoosingTestForRedaging
    {
        Repository repository = new Repository();
        public List<Question> getAllQuestions()
        {
            return repository.readFileQuestions();
        }
    }
}

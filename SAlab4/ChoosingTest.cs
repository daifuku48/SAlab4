using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAlab4
{
    interface IChoosingTest
    {
        List<Question> getAllQuestions();

    }
    internal class ChoosingTest : IChoosingTest
    {
        Repository repository = new Repository();
        public List<Question> getAllQuestions()
        {
            return repository.readFileQuestions();
        }
    }
}

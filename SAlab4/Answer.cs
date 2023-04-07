

namespace SAlab4
{
    public class Answer
    {
        public string Email { get; set; }
        public int Id { get; set; }
        public string Quest { get; set; }
        public int Ans { get; set; }

        public Answer(string email, int id, string quest, int answer)
        {
            Email = email;
            Id = id;
            Quest = quest;
            Ans = answer;
        }
    }
}



namespace SAlab4
{
    interface IAnswer
    {
        string Email { get; set; }
        int Id { get; set; }
        string Quest { get; set; }
        int Ans { get; set; }
    }

    public class Answer : IAnswer
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

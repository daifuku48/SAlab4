
namespace SAlab4
{
    interface IComment
    {
        string Name { get; set; }
        string Text { get; set; }
    }
    public class Comment : IComment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}

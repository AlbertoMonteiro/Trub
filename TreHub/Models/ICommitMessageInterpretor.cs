namespace TreHub.Models
{
    public interface ICommitMessageInterpretor
    {
        CardAction Interpret(string commitMessage);
    }

    public class CardAction
    {
        public string CardId { get; set; }
        public CardActionKind Kind { get; set; }
    }
}
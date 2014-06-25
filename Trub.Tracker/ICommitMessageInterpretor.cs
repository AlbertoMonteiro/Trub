namespace Trub.Tracker
{
    public interface ICommitMessageInterpretor
    {
        CardAction Interpret(string commitMessage);
    }
}
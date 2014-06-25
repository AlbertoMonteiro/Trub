using System;
using System.Text.RegularExpressions;

namespace Trub.Tracker
{
    public class CommitMessageInterpretor : ICommitMessageInterpretor
    {
        private string pattern;

        public CommitMessageInterpretor()
        {
            pattern = @"\[(?<action>(Close|Closed|Fixed))*\s*#(?<cardId>\d+)\]";
        }

        public CardAction Interpret(string commitMessage)
        {
            if (string.IsNullOrWhiteSpace(commitMessage))
                throw new ArgumentException("Required commit message", "commitMessage");

            var result = new CardAction();
            var match = Regex.Match(commitMessage, pattern);
            if (match.Success)
            {
                var cardIdGroup = match.Groups["cardId"];
                if (cardIdGroup.Success)
                    result.CardId = cardIdGroup.Value;

                var actionGroup = match.Groups["action"];
                if (actionGroup.Success)
                    result.Kind = CardActionKind.Close;

                return result;
            }
            return null;
        }
    }

    public enum CardActionKind
    {
        Log,
        Close
    }
}
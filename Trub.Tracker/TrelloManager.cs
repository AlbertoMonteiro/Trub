using System;
using System.Collections.Generic;
using System.Linq;
using TrelloNet;
using Trub.Tracker.Models;

namespace Trub.Tracker
{
    public class TrelloManager : ITrelloManager
    {
        private readonly ITrello trello;
        private bool isAuthorized;
        private string currentToken;

        public TrelloManager(ITrello trello)
        {
            this.trello = trello;
        }

        public IEnumerable<TrelloBoard> GetOpenBoards()
        {
            if (isAuthorized)
            {
                //trello.Tokens.WithToken("currentToken");
                return trello.Boards.ForMe(BoardFilter.Open).Select(b => new TrelloBoard
                {
                    Id = b.Id,
                    Name = b.Name,
                });
            }
            throw new Exception("You must authorize before get open boards");
        }

        public string GetTrelloAuthUrl()
        {
            return trello.GetAuthorizationUrl("Trub", Scope.ReadWrite, Expiration.Never).ToString();
        }

        public void Authorize(string token = "bfb3661ecc74a0d18e6ab4754471d81a84f914e7a38277004c262e0e73875730")
        {
            currentToken = token;
            trello.Authorize(token);
            isAuthorized = true;
        }
    }
}
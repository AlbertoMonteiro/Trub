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

        public TrelloManager(ITrello trello)
        {
            this.trello = trello;
        }

        public IEnumerable<TrelloBoard> GetOpenBoards()
        {
            if (isAuthorized)
            return trello.Boards.ForMe(BoardFilter.Open).Select(b => new TrelloBoard
            {
                Id = b.Id,
                Name = b.Name,
            });
            throw new Exception("You must authorize before get open boards");
        }

        public string GetTrelloAuthUrl()
        {
            return trello.GetAuthorizationUrl("Trub", Scope.ReadWrite, Expiration.Never).ToString();
        }

        public void Authorize(string token = "f0220431655d1096c636251c5677f1844d2a2d82f9ac3ba6df72c8191c97763f")
        {
            trello.Authorize(token);
            isAuthorized = true;
        }
    }
}
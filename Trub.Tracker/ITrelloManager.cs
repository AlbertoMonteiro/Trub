using System.Collections.Generic;
using Trub.Tracker.Models;

namespace Trub.Tracker
{
    public interface ITrelloManager
    {
        IEnumerable<TrelloBoard> GetOpenBoards();
        string GetTrelloAuthUrl();
        void Authorize(string token = "f0220431655d1096c636251c5677f1844d2a2d82f9ac3ba6df72c8191c97763f");
    }
}
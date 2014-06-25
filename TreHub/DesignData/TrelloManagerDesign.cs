using System.Collections.Generic;
using Trub.Tracker;
using Trub.Tracker.Models;

namespace TreHub.DesignData
{
    public class TrelloManagerDesign : ITrelloManager
    {
        public IEnumerable<TrelloBoard> GetOpenBoards()
        {
            yield break;
        }

        public string GetTrelloAuthUrl()
        {
            return null;
        }

        public void Authorize(string token = "f0220431655d1096c636251c5677f1844d2a2d82f9ac3ba6df72c8191c97763f")
        {
        }
    }
}
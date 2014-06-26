using System.Collections.Generic;
using Trub.Tracker.Models;

namespace Trub.Tracker
{
    public interface ITrelloManager
    {
        IEnumerable<TrelloBoard> GetOpenBoards();
        string GetTrelloAuthUrl();
        void Authorize(string token = "bfb3661ecc74a0d18e6ab4754471d81a84f914e7a38277004c262e0e73875730");
    }
}
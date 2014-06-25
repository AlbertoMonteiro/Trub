using System.Collections.Generic;
using Trub.Tracker.Models;

namespace Trub.Tracker
{
    public interface ITrelloManager
    {
        IEnumerable<TrelloBoard> GetOpenBoards();
    }
}
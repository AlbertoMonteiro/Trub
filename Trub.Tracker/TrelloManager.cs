using System.Collections.Generic;
using System.Linq;
using TrelloNet;
using Trub.Tracker.Models;

namespace Trub.Tracker
{
    public class TrelloManager : ITrelloManager
    {
        private readonly ITrello trello;

        public TrelloManager(ITrello trello)
        {
            this.trello = trello;
            if (trello == null)
                this.trello = new Trello("08ef1643c5e214994f53fb67c115af43");
            this.trello.Authorize("b98be4952d2086dfb322b8b28643b3bc2288b3983f2f99762f1bb24525c0d26f");
        }

        public IEnumerable<TrelloBoard> GetOpenBoards()
        {
            return trello.Boards.ForMe(BoardFilter.Open).Select(b => new TrelloBoard
            {
                Id = b.Id,
                Name = b.Name,
            });
        }
    }
}
namespace Trub.Tracker.Models
{
    public class TrelloBoard
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
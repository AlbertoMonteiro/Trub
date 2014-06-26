namespace Trub.Tracker.Models
{
    public class GitHubRepository
    {
        public string Name { get; set; }
        public string Owner { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0}/{1}", Owner, Name);
            }
        }
    }
}
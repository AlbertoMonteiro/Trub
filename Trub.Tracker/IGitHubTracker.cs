using System.Collections.Generic;
using Trub.Tracker.Models;

namespace Trub.Tracker
{
    public interface IGitHubTracker
    {
        void TrackNewCommits();
        IEnumerable<GitHubRepository> GitHubRepositories();
    }
}

using System.Collections.Generic;
using Trub.Tracker;
using Trub.Tracker.Models;

namespace TreHub.DesignData
{
    public class GitHubTrackerDesign:IGitHubTracker
    {
        public void TrackNewCommits()
        {
        }

        public IEnumerable<GitHubRepository> GitHubRepositories()
        {
            yield break;
        }
    }
}
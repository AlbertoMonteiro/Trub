using System.Collections.Generic;
using System.Linq;
using Octokit;
using Trub.Tracker.Models;

namespace Trub.Tracker
{
    public class GitHubTracker : IGitHubTracker
    {
        private GitHubClient github;

        public GitHubTracker()
        {
            var productHeaderValue = new ProductHeaderValue("TreHub");
            #region Cred
            github = new GitHubClient(productHeaderValue)
                {
                    Credentials = new Credentials("albertomonteiro", "MP@clan$123")
                };
            #endregion

        }

        public void TrackNewCommits()
        {
        }

        public IEnumerable<GitHubRepository> GitHubRepositories()
        {
            var repos = new List<GitHubRepository>();
            repos.AddRange(GetRepositoriesFromOrganization());
            repos.AddRange(GetRepositoriesFromCurrentUser());
            return repos;
        }

        private IEnumerable<GitHubRepository> GetRepositoriesFromOrganization()
        {
            var repos = new List<GitHubRepository>();
            var allForCurrent = github.Organization.GetAllForCurrent();
            allForCurrent.Wait();
            var organization = allForCurrent.Result.FirstOrDefault();

            if (organization != null)
            {
                var allForOrg = github.Repository.GetAllForOrg(organization.Login);
                allForOrg.Wait();
                var repositories = allForOrg.Result;
                repos.AddRange(repositories.Select(r => new GitHubRepository() { Name = r.Name, Owner = organization.Name }));
            }
            return repos;
        }
        private IEnumerable<GitHubRepository> GetRepositoriesFromCurrentUser()
        {
            var repos = new List<GitHubRepository>();
            var current = github.User.Current();
            current.Wait();
            var allForCurrent = github.Repository.GetAllForCurrent();
            allForCurrent.Wait();
            var repositories = allForCurrent.Result;
            repos.AddRange(repositories.Select(r => new GitHubRepository() { Name = r.Name, Owner = current.Result.Name }));
            return repos;
        }
    }
}
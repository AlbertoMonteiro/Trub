using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using Octokit;
using TrelloNet;

namespace TreHub.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Board> Boards { get; set; }
        public ObservableCollection<List> Lists { get; set; }
        public MainViewModel()
        {
            ITrello trello = new Trello("08ef1643c5e214994f53fb67c115af43");
            trello.Authorize("b98be4952d2086dfb322b8b28643b3bc2288b3983f2f99762f1bb24525c0d26f");

            Lists = new ObservableCollection<List>();
            Boards = new ObservableCollection<Board>();


            if (IsInDesignMode)
            {
                Lists.Add(new List { Name = "Nash" });
            }
            else
            {
                try
                {
                    //DoIt();
                    foreach (var board in trello.Boards.ForMe(BoardFilter.Open))
                        Boards.Add(board);
                    var nashBoard = trello.Boards.WithId("52f225f4991a23ff20150af0");
                    foreach (var list in trello.Lists.ForBoard(nashBoard))
                    {
                        Lists.Add(list);
                    }
                }
                catch (System.Exception e)
                {
                    //MessageBox.Show(e.Message);
                }
            }
        }

        private async void DoIt()
        {
            var github = new GitHubClient(new ProductHeaderValue("TreHub"))
            {
                Credentials = new Credentials("albertomonteiro", "MP@clan$123")
            };
            var organization = (await github.Organization.GetAllForCurrent()).FirstOrDefault();
            if (organization != null)
            {
                var repositories = await github.Repository.GetAllForOrg(organization.Login);
                var repoNames = string.Join(", ", repositories.Select(r => r.Name));
                MessageBox.Show(repoNames);
            }
        }
    }
}
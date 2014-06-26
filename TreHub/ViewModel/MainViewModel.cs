using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Trub.Tracker;
using Trub.Tracker.Models;

namespace TreHub.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IGitHubTracker gitHubTracker;
        private readonly ITrelloManager trelloManager;
        private TrelloBoard selectedBoard;
        private GitHubRepository selectedRepository;
        private string step;

        public MainViewModel(ITrelloManager trelloManager, IGitHubTracker gitHubTracker)
        {
            this.trelloManager = trelloManager;
            this.gitHubTracker = gitHubTracker;

            step = "FirstStep";
            TrelloBoards = new ObservableCollection<TrelloBoard>();
            GitHubRepositories = new ObservableCollection<GitHubRepository>();

            if (IsInDesignMode)
            {
            }
            else
            {
                //var trelloAuthUrl = trelloManager.GetTrelloAuthUrl();
                trelloManager.Authorize();
                foreach (TrelloBoard trelloBoard in trelloManager.GetOpenBoards())
                    TrelloBoards.Add(trelloBoard);

                foreach (GitHubRepository gitHubRepository in gitHubTracker.GitHubRepositories().OrderBy(r => r.Owner).ThenBy(r => r.Name))
                    GitHubRepositories.Add(gitHubRepository);
            }

            OnBoardSelected = new RelayCommand(BoardSelected);
        }

        public ObservableCollection<TrelloBoard> TrelloBoards { get; set; }
        public ObservableCollection<GitHubRepository> GitHubRepositories { get; set; }

        public TrelloBoard SelectedBoard
        {
            get { return selectedBoard; }
            set
            {
                selectedBoard = value;
                RaisePropertyChanged("SelectedBoard");
            }
        }

        public GitHubRepository SelectedRepository
        {
            get { return selectedRepository; }
            set
            {
                selectedRepository = value;
                RaisePropertyChanged("SelectedRepository");
            }
        }

        public string Step
        {
            get { return step; }
            set
            {
                step = value;
                RaisePropertyChanged("Step");
            }
        }

        public RelayCommand OnBoardSelected { get; set; }
        public RelayCommand OnRepositoryChanged { get; set; }

        private void BoardSelected()
        {
            Step = "SecondStep";
        }
    }
}
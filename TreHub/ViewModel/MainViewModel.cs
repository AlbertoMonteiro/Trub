using System.Collections.ObjectModel;
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
                trelloManager.Authorize();
                foreach (var trelloBoard in trelloManager.GetOpenBoards())
                    TrelloBoards.Add(trelloBoard);

                foreach (var gitHubRepository in gitHubTracker.GitHubRepositories())
                    GitHubRepositories.Add(gitHubRepository);
            }

            OnBoardSelected = new RelayCommand(BoardSelected);
        }

        private void BoardSelected()
        {
            Step = "SecondStep";
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
    }
}
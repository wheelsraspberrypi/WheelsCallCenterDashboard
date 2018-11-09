using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using WheelsCallCenterDashboard.Services;
using WheelsCallCenterDashboard.Services.Abstract;
using WheelsCallCenterDashboard.ViewModels.Abstract;

namespace WheelsCallCenterDashboard.ViewModels
{
    public class MainViewModel : RootViewModel<MainViewModel>
    {
        private readonly ISnackbarMessageQueue SnackbarMessageQueue;
        public MainViewModel(ISnackbarMessageQueue snackbarMessageQueue, ITaskDispatcher dispatcher) : base(dispatcher)
        {
            SnackbarMessageQueue = snackbarMessageQueue;
            CurrentViewModel = new DashboardViewModel(new FeedServices(), dispatcher);
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    RaisePropertyChanged(x => x.Name);                    
                }
            }
        }

        private bool _LeftMenuVisible;
        public bool LeftMenuVisible
        {
            get
            {
                return _LeftMenuVisible;
            }
            set
            {
                if (_LeftMenuVisible != value)
                {
                    _LeftMenuVisible = value;
                    RaisePropertyChanged(x => x.LeftMenuVisible);
                }
            }
        }


        private IBaseViewModel _CurrentViewModel;
        public IBaseViewModel CurrentViewModel
        {
            get
            {
                return _CurrentViewModel;
            }
            set
            {
                if (_CurrentViewModel != value)
                {
                    _CurrentViewModel = value;
                    RaisePropertyChanged(x => x.CurrentViewModel);
                }
            }
        }

        private ICommand _DoToggleMenu;
        public ICommand DoToggleMenu
        {
            get
            {
                if (_DoToggleMenu == null)
                {
                    _DoToggleMenu = new RelayCommand(o => {                        
                        SnackbarMessageQueue.Enqueue($"Toggling to {LeftMenuVisible}");
                    });
                }
                return _DoToggleMenu;
            }
        }
    }
}

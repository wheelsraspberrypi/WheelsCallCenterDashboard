using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using WheelsCallCenterDashboard.Services.Abstract;
using WheelsCallCenterDashboard.ViewModels.Abstract;

namespace WheelsCallCenterDashboard.ViewModels
{
    public class DashboardViewModel : BaseViewModel<DashboardViewModel>
    {
        private int cycleIndex = 0;
        private readonly IFeedServices FeedServices;
        private readonly ITaskDispatcher Dispatcher;
        public ObservableCollection<DashboardSideItemViewModel> ListItems { get; set; }

        public DashboardViewModel(IFeedServices feedServices, ITaskDispatcher dispatcher)
        {
            FeedServices = feedServices;
            Dispatcher = dispatcher;

            ListItems = new ObservableCollection<DashboardSideItemViewModel>();

            LoadData();

            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += (a,b)=> {
                CycleImages();
            };
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();            
        }

        private void CycleImages()
        {
            if (ListItems.Count > 0)
            {
                cycleIndex++;
                cycleIndex = cycleIndex % 12;

                var item = ListItems[0];
                ListItems.Remove(item);
                ListItems.Add(item);

                if (cycleIndex == 0) {
                    LoadData();
                }
            }
        }

        private void LoadData()
        {
            Task.Factory.StartNew(async () => {
                var data = await FeedServices.GetFeedDataAsync();
                Dispatcher.DispatchOnUI(() =>
                {
                    ListItems.Clear();
                    data.ForEach(x => {
                        ListItems.Add(new DashboardSideItemViewModel {
                            Name = x.Name,
                            Description = x.Description,
                            ImageUrl = x.ImageUrl,                            
                        });
                    });                    
                });
            });
        }
    }
}

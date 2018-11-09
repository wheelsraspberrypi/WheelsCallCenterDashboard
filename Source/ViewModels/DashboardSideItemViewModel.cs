using WheelsCallCenterDashboard.ViewModels.Abstract;

namespace WheelsCallCenterDashboard.ViewModels
{
    public class DashboardSideItemViewModel : BaseViewModel<DashboardSideItemViewModel>
    {
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

        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    RaisePropertyChanged(x => x.Description);
                }
            }
        }

        private string _ImageUrl;
        public string ImageUrl
        {
            get
            {
                return _ImageUrl;
            }
            set
            {
                if (_ImageUrl != value)
                {
                    _ImageUrl = value;
                    RaisePropertyChanged(x => x.ImageUrl);
                }
            }
        }
    }
}

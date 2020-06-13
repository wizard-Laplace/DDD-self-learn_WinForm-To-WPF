using DDD.WPF.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace DDD.WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private string _title = "DDD";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            WeatherLatestButton = new DelegateCommand(
                WeatherLatestButtonExecute);

            WeatherListButton = new DelegateCommand(
                WeatherListButtonExecute);
        }

        public DelegateCommand WeatherLatestButton { get; }
        public DelegateCommand WeatherListButton { get; }

        private void WeatherLatestButtonExecute()
        {
            _regionManager.RequestNavigate
                ("ContentRegion", nameof(WeatherLatestView));
        }

        private void WeatherListButtonExecute()
        {
            _regionManager.RequestNavigate
                ("ContentRegion", nameof(WeatherListView));

        }
    }
}

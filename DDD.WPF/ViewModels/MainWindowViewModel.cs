using DDD.WPF.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace DDD.WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IDialogService _dialogService;
        private string _title = "DDD";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        //StatusLabel
        private string _statusLabel = "--";
        public string StatusLabel
        {
            get { return _statusLabel; }
            set { SetProperty(ref _statusLabel, value); }
        }

        public MainWindowViewModel(
            IRegionManager regionManager,
            IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            WeatherLatestButton = new DelegateCommand(
                WeatherLatestButtonExecute);

            WeatherListButton = new DelegateCommand(
                WeatherListButtonExecute);

            WeatherSaveButton = new DelegateCommand(
                WeatherSaveButtonExecute);
        }

        public DelegateCommand WeatherLatestButton { get; }
        public DelegateCommand WeatherListButton { get; }
        public DelegateCommand WeatherSaveButton { get; }

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

        private void WeatherSaveButtonExecute()
        {
            _dialogService.ShowDialog(
                nameof(WeatherSaveView),
                null,
                null);
        }
    }
}

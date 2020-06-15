using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DDD.WPF.ViewModels
{
    public class WeatherListViewModel : BindableBase
    {
        private IWeatherRepository _weather;

        public WeatherListViewModel()
            : this(new WeatherSQLite())
        {
        }
        public WeatherListViewModel(IWeatherRepository weather)
        {
            _weather = weather;

            foreach (var entity in _weather.GetData())
            {
                Weathers.Add(new WeatherListViewModelWeather(entity));
            }

            UpdateButton = new DelegateCommand(UpdateButtonExecute);

            DatagridSelectionChanged = new DelegateCommand(DatagridSelectionChangedExecute);

            DatagridMouseDoubleClick = new DelegateCommand(DatagridMouseDoubleClickExecute);
        }

        private ObservableCollection<WeatherListViewModelWeather> _weathers
            = new ObservableCollection<WeatherListViewModelWeather>();

        public ObservableCollection<WeatherListViewModelWeather> Weathers
        {
            get { return _weathers; }
            set
            {
                SetProperty(ref _weathers, value);
            }
        }

        //SelectedWeater
        private WeatherListViewModelWeather _selectedWeater;
        public WeatherListViewModelWeather SelectedWeater
        {
            get { return _selectedWeater; }
            set { SetProperty(ref _selectedWeater, value); }
        }

        public DelegateCommand UpdateButton { get; }

        public DelegateCommand DatagridSelectionChanged { get; }

        public DelegateCommand DatagridMouseDoubleClick { get; }

        private void UpdateButtonExecute()
        {

        }

        private void DatagridSelectionChangedExecute()
        {

        }

        private void DatagridMouseDoubleClickExecute()
        {

        }
    }
}

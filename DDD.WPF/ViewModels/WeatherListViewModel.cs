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
    }
}

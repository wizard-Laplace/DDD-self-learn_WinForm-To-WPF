using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace DDD.WPF.ViewModels
{
    public class WeatherLatestViewModel : BindableBase
    {
        private IWeatherRepository _weather;
        private IAreasRepositoy _areasRepositoy;

        public WeatherLatestViewModel()
            : this(new WeatherSQLite(), new AreasSQLite())
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather,
            IAreasRepositoy areas)
        {
            _weather = weather;
            _areasRepositoy = areas;

            foreach (var area in _areasRepositoy.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }

            LatestButton = new DelegateCommand(LatestButtonExecute);
        }

        private AreaEntity _selectedArea;
        public AreaEntity SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                SetProperty(ref _selectedArea, value);
            }
        }

        private string _dataDateText = string.Empty;
        public string DataDateText
        {
            get { return _dataDateText; }
            set
            {
                SetProperty(ref _dataDateText, value);

            }
        }

        private string _conditionText = string.Empty;
        public string ConditionText
        {
            get { return _conditionText; }
            set
            {
                SetProperty(ref _conditionText, value);
            }
        }

        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                SetProperty(ref _temperatureText, value);

            }
        }

        private ObservableCollection<AreaEntity> _areas
            = new ObservableCollection<AreaEntity>();
        public ObservableCollection<AreaEntity> Areas
        {
            get { return _areas; }
            set
            {
                SetProperty(ref _areas, value);
            }
        }

        public DelegateCommand LatestButton { get; }

        private void LatestButtonExecute()
        {
            if(SelectedArea==null)
            {
                throw new InputException("地域を選択してください");
            }

            var entity =
                _weather.GetLatest((SelectedArea.AreaId));
            if (entity == null)
            {
                DataDateText = string.Empty;
                ConditionText = string.Empty;
                TemperatureText = string.Empty;
            }
            else
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;

                ////intelisenseで好きなバリューオブジェクトを呼ぶ
                ///EX:12.30・・・DisplayValue
                ///   12.30℃・・・DisplayValueWithUnit
                ///   12.30 ℃・・・DisplayValueWithUnitSpace
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }
    }
}

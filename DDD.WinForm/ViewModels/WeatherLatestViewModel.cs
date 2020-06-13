using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        IAreasRepositoy _areas;

        public WeatherLatestViewModel()
            :this(new WeatherSQLite(), new AreasSQLite())
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather,
            IAreasRepositoy areas)
        {
            _weather = weather;
            _areas = areas;

            foreach(var area in _areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName)); 
            }
        }

        private object _selectedAreaId;
        public object SelectedAreaId
        {
            get { return _selectedAreaId; }
            set
            {
                SetProperty(ref _selectedAreaId, value);
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

        public BindingList<AreaEntity> Areas { get; set; }
        = new BindingList<AreaEntity>();

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(_selectedAreaId));
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

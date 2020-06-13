﻿using DDD.Domain.ValueObjects;
using System;

namespace DDD.Domain.Entities
{
    public sealed class WeatherEntity
    {
        /// <summary>
        /// 完全コンストラクタパターン
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="dataDate"></param>
        /// <param name="condition"></param>
        /// <param name="temperature"></param>
        public WeatherEntity(int areaId,
                                DateTime dataDate,
                                int condition,
                                float temperature)
            :this(areaId,string.Empty,dataDate,condition,temperature)
        {
        }

        public WeatherEntity(int areaId,
                                string areaName,
                                DateTime dataDate,
                                int condition,
                                float temperature
            )
        {
            AreaId = new AreaId(areaId);
            AreaName = areaName;
            DataDate = dataDate;
            Condition = new Condition(condition);
            Temperature = new Temperature(temperature);
        }

        public AreaId AreaId { get; }
        public string AreaName { get; }
        public DateTime DataDate { get; }
        public Condition Condition { get; }
        public Temperature Temperature { get; }

        public bool IsMousho()
        {
            if(Condition == Condition.Sunny)
            {
                if(Temperature.Value > 30 )
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsOk()
        {
            if(DataDate < DateTime.Now.AddMonths(-1))
            {
                if(Temperature.Value < 10)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

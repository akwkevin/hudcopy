﻿using AIC.Core.Events;
using AIC.Core.SignalModels;
using AIC.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.SignalProcess
{
    public partial class SignalProcess : ISignalProcess
    {
        public List<StatisticalInformationData> StatisticalInformation { get; set; }

        public event StatisticalInformationDataChangedEvent StatisticalInformationDataChanged;        

        public async void GetDailyMedianData(DateTime startTime, DateTime endTime)
        {
            StatisticalInformation = await _databaseComponent.GetDailyMedianData<StatisticalInformationData>(startTime, endTime, StatisticalInformationData.GetColumnsString());
            if (StatisticalInformationDataChanged != null)
            {
                Dictionary<string, List<Tuple<DateTime, int, int, int>>> statisticalResult = new Dictionary<string, List<Tuple<DateTime, int, int, int>>>();
                foreach(var serverip in _databaseComponent.GetServerIPCategory())
                {
                    var signals = Signals.Where(p => p.ServerIP == serverip).Select(p => p.Guid);
                    List<Tuple<DateTime, int, int, int>> tuple = new List<Tuple<DateTime, int, int, int>>();
                    for (DateTime dt = startTime; dt <= endTime; dt = dt.AddDays(1))//把每天危险测点加起来
                    {
                        var daysignals = StatisticalInformation.Where(p => p.ACQDatetime.Date == dt.Date && signals.Contains(p.T_Item_Guid)).ToArray();
                        var allNumber = daysignals.Count();
                        var dangerNumber = daysignals.Where(p => (p.AlarmGrade & 0xff) == 4).Count();
                        var alarmNumber = daysignals.Where(p => (p.AlarmGrade & 0xff) == 3).Count();                       
                        tuple.Add(new Tuple<DateTime, int, int, int>(dt, allNumber, dangerNumber, alarmNumber));
                    }
                    statisticalResult.Add(serverip, tuple);
                }
                StatisticalInformationDataChanged(statisticalResult);
            }
        }

    }
}
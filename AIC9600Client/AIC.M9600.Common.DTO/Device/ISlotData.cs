﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.M9600.Common.DTO.Device
{
    public interface ISlotData
    {
        SignalType Type { get; }
        DateTime ACQDatetime { get; set; }
        DateTime RegionACQDatetime { get; }
        string ChannelHDID { get; set; }
        int AlarmGrade { get; set; }
        AlarmLimit[] AlarmLimit { get; set; }
        Guid? RecordLab { get; set; }
        double? Result { get; set; }
        double? RPM { get; set; }
        string Unit { get; set; }

        Dictionary<string, double> StatisticsInfo { get; set; }

        void SetTestPointIdAndUploadTime(Guid itemGuid,DateTime uploadTime);
    }
}

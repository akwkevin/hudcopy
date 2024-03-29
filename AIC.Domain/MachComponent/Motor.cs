﻿//using NullGuard;

using AIC.CoreType;

namespace AIC.Domain
{
    public class Motor : IMach
    {
        public Motor()
        {
            LineFrequency = 50;
            Poles = 2;
            SCRs = 6;
            MotorType = MotorType.AC;
        }
        //[AllowNull]
        public string Name { get; set; }
        //电网工频,单位HZ,默认值50
        public double LineFrequency { get; set; }

        //磁极数,必须为大于等于2的偶数，如2,4,6,8，… 默认值2
        public int Poles { get; set; }

        //转子条数
        public int RotorBars { get; set; }

        //定子线圈数(同步电机)
        public int StatorCoils { get; set; }

        //绕组槽数
        public int WindingSlots { get; set; }

        //可控硅整流器数,只有3与6两种选择。默认值6
        public int SCRs { get; set; }

        //交流电机 默认值true
        public MotorType MotorType { get; set; }
    }
}

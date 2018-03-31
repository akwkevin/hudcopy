﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.DeviceDataPage.Models
{
    public class DeviceDiagnosisInfo//设备诊断模型
    {
        public bool IsFaultprobability; //是否显示故障概率
        public double HeadDivFreThreshold; //总分频门槛值，如DivFreThresholdProportionInfo.Threshold分频存在，忽略HeadDivFreThreshold，否则起作用。
        public double FreDiagnosisSetupInterval;//频率诊断设置间隔，默认值为1
        public double FrePeakFilterInterval;// 频率峰值过滤间隔，默认值为5
        public bool IsDeviceDiagnosis;//=1为多个测点诊断一台设备；=0一个测点诊断一台设备。
        public double KurtosisIndexThreshold;//峭度指标门槛值。
        public double MeanThreshold;//绝对平均值门槛值
        public double PeakIndexThreshold;//峰值指标门槛值
        public double PeakThreshold;//峰值门槛值
        public double PulseIndexThreshold;//脉冲指标门槛值
        public double RMSThreshold;//有效值门槛值。
        public ShaftInfo[] ShaftInfos;
        public SingleTestPointInfo SingleTestPointInfo;

        private string CreateTestJson(string vdata)
        {
            DeviceDiagnosisInfo deviceInfo = new DeviceDiagnosisInfo();
            deviceInfo.HeadDivFreThreshold = 0;
            deviceInfo.FreDiagnosisSetupInterval = 5;
            deviceInfo.FrePeakFilterInterval = 0.1;
            deviceInfo.IsDeviceDiagnosis = true;
            deviceInfo.KurtosisIndexThreshold = 0;
            deviceInfo.MeanThreshold = 0;
            deviceInfo.PeakIndexThreshold = 0;
            deviceInfo.PeakThreshold = 0;
            deviceInfo.PulseIndexThreshold = 0;
            deviceInfo.RMSThreshold = 0;

            ShaftInfo shaftInfo = new ShaftInfo();
            shaftInfo.Name = "风机轴";
            shaftInfo.RPM = 6000;
            shaftInfo.RPMCoeff = 1;
            shaftInfo.IsSlidingBearing = false;
            shaftInfo.BearingInfos = new BearingInfo[]
            {
                new BearingInfo() {Name="轴承1", ContactAngle = 0.0, InnerRingDiameter = 10.0, NumberOfColumns = 1, NumberOfRoller = 1, OuterRingDiameter = 100.0, PitchDiameter = 20.0, RollerDiameter = 15.0 },
                new BearingInfo() {Name="轴承2", ContactAngle = 0.0, InnerRingDiameter = 10.0, NumberOfColumns = 1, NumberOfRoller = 1, OuterRingDiameter = 100.0, PitchDiameter = 20.0, RollerDiameter = 15.0 },
            };
            shaftInfo.GearInfos = new GearInfo[]
            {
                new GearInfo { Name="齿轮1", TeethNumber = 10 },
                new GearInfo { Name="齿轮2", TeethNumber = 10 },
            };
            shaftInfo.BeltInfos = new BeltInfo[]
            {
                new BeltInfo {Name="皮带1", BeltLength = 100, PulleyDiameter = 10 },
                new BeltInfo {Name="皮带2", BeltLength = 100, PulleyDiameter = 10 },
            };
            shaftInfo.ImpellerInfos = new ImpellerInfo[]
            {
                new ImpellerInfo {Name="叶轮1", VaneNumber = 15 } ,
                 new ImpellerInfo {Name="叶轮2", VaneNumber = 15 },
            };
            shaftInfo.AddNaturalFres = new NaturalFreInfo[]
            {
                new NaturalFreInfo() { DivFreType = 0, Name = "不平衡", Value1 = 1 },
                new NaturalFreInfo() { DivFreType = 0, Name = "不对中", Value1 = 1 },
            };
            shaftInfo.DeleteNaturalFres = new NaturalFreInfo[]
            {
                new NaturalFreInfo() { DivFreType = 0, Name = "不平衡", Value1 = 1 },
                new NaturalFreInfo() { DivFreType = 0, Name = "不对中", Value1 = 1 },
            };
            shaftInfo.DivFreThresholdProportions = new DivFreThresholdProportionInfo[]
            {
                new DivFreThresholdProportionInfo() { DivFreType = 0, Name = "不平衡", Proportion = 1.0, Threshold = 0.1, Value1 = 1.0, Value2 = 2.0 },
                new DivFreThresholdProportionInfo() { DivFreType = 0, Name = "不对中", Proportion = 1.0, Threshold = 0.1, Value1 = 1.0, Value2 = 2.0 },
            };
            shaftInfo.NegationDivFreStrategies = new NegationDivFreStrategyInfo[]
            {
                new NegationDivFreStrategyInfo { Code = 1, Name = "不平衡", RelativeX = 1, RelativeY = 1, RelativeZ = 2 },
                new NegationDivFreStrategyInfo { Code = 1, Name = "不对中", RelativeX = 1, RelativeY = 1, RelativeZ = 2 }
            };
            shaftInfo.TestPointGroupInfos = new TestPointGroupInfo[]
            {
                new TestPointGroupInfo()
                {
                    X = new TestPointInfo() { Name = "测点1X方向", SampleFre = 2560, SamplePoint = 1024, VData=vdata },
                    Y = new TestPointInfo() { Name = "测点1Y方向", SampleFre = 2560, SamplePoint = 1024 },
                    Z = new TestPointInfo() { Name = "测点1Z方向", SampleFre = 2560, SamplePoint = 1024 },
                },
                new TestPointGroupInfo()
                {
                    X = new TestPointInfo() { Name = "测点2X方向", SampleFre = 2560, SamplePoint = 1024 },
                    Y = new TestPointInfo() { Name = "测点2Y方向", SampleFre = 2560, SamplePoint = 1024 },
                    Z = new TestPointInfo() { Name = "测点2Z方向", SampleFre = 2560, SamplePoint = 1024 },
                }
            };

            SingleTestPointInfo singleTestPointInfo = new SingleTestPointInfo();
            singleTestPointInfo.RPM = 6000;
            singleTestPointInfo.ShaftName = "";
            singleTestPointInfo.TestPointGroupInfo = new TestPointGroupInfo()
            {
                X = new TestPointInfo() { Name = "测点SX", SampleFre = 2560, SamplePoint = 1024 },
                Y = new TestPointInfo() { Name = "测点SY", SampleFre = 2560, SamplePoint = 1024 },
                Z = new TestPointInfo() { Name = "测点SZ", SampleFre = 2560, SamplePoint = 1024 },
            };

            deviceInfo.ShaftInfos = new ShaftInfo[] { shaftInfo };
            deviceInfo.SingleTestPointInfo = singleTestPointInfo;

            string json = JsonConvert.SerializeObject(deviceInfo);
            return json;
        }
    }

    public class DiagnoseResultInfo
    {
        public FaultInfo[] description;
        public string Error;
        public string Warning;
    }

    public class FaultInfo
    {
        public int Code;
        public string Fault;
        public string Harm;
        public string Proposal;
    }

    public class BearingInfo  //轴承信息
    {
        public string Name;
        public double PitchDiameter;  //节圆直径
        public double RollerDiameter;//滚子直径
        public double ContactAngle; //接触角
        public int NumberOfRoller; //滚子个数
        public double OuterRingDiameter;//外圈直径
        public double InnerRingDiameter; //内圈直径
        public int NumberOfColumns;//列数
    };
    public class BeltInfo  //皮带信息
    {
        public string Name;
        public double BeltLength;//皮带长度
        public double PulleyDiameter;//皮带轮长度。
    };
    public class GearInfo //齿轮信息
    {
        public string Name;
        public int TeethNumber;
    };
    public class ImpellerInfo //叶轮信息
    {
        public string Name;
        public int VaneNumber;//叶片数
    };
    public class NegationDivFreStrategyInfo //否定分频诊断策略
    {
        public int Code;  //故障代码
        public string Name;//故障名称
        public double RelativeY; //垂直相对值
        public double RelativeX;  //水平相对值
        public double RelativeZ;  //轴向相对值
    };
    public class NaturalFreInfo  //特征频率
    {
        public int DivFreType;//分频类型，=0倍频，=1固定分频，=2分频在一段范围
        public string Name; //故障名称
        public double Value1; //DivFreType=0时表示倍频，如1；DivFreType=1时表示固定分频，如80；DivFreType=2时频率起始值，如40；
        public double Value2;//DivFreType=2时频率结束值，如80；其它两种分频值为此项忽略。
    };
    public class DivFreThresholdProportionInfo//分频门槛与加权
    {
        public int DivFreType;//分频类型，=0倍频，=1固定分频，=2分频在一段范围
        public string Name; //故障名称
        public double Value1; //DivFreType=0时表示倍频，如1；DivFreType=1时表示固定分频，如80；DivFreType=2时频率起始值，如40；
        public double Value2;//DivFreType=2时频率结束值，如80；其它两种分频值为此项忽略。
        public double Proportion;//加权值，必须>=0
        public double Threshold;//门槛值，>=0且<=100%
    };
    public class TestPointGroupInfo
    {
        public TestPointInfo X;
        public TestPointInfo Y;
        public TestPointInfo Z;
    }
    public class TestPointInfo //测点信息
    {
        public string Name; //测点名称
        public double SampleFre;//采样频率
        public int SamplePoint;//采样点数
        public string VData;// 经过反BASE64转换的data，即原始时域数据。
    };
    public class ShaftInfo
    {
        public string Name;//轴名称；
        public double RPM;//轴转速
        public double RPMCoeff;//转速系数，默认值为1
        public bool IsSlidingBearing;//是否滑动轴承
        public BearingInfo[] BearingInfos;
        public GearInfo[] GearInfos;
        public BeltInfo[] BeltInfos;
        public ImpellerInfo[] ImpellerInfos;
        public NaturalFreInfo[] AddNaturalFres;
        public NaturalFreInfo[] DeleteNaturalFres;
        public DivFreThresholdProportionInfo[] DivFreThresholdProportions;
        public NegationDivFreStrategyInfo[] NegationDivFreStrategies;
        public TestPointGroupInfo[] TestPointGroupInfos;
    };
    public class SingleTestPointInfo
    {
        public double RPM;
        public string ShaftName;
        public TestPointGroupInfo TestPointGroupInfo;
    };
}
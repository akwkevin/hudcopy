﻿/* Author : zhengyangyong */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.M9600.Common.DTO
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum WebMessageType : short
    {
        QueryRequest = 1001,
        AddRequest = 1002,
        ModifyRequest = 1003,
        ComplexRequest = 1004,
        DeleteRequest = 1005,
        /// <summary>
        /// 与设备通信
        /// </summary>
        CommunicateDeviceRequest = 2001,
        /// <summary>
        /// 查询最新采样数据
        /// </summary>
        QueryLatestSampleDataRequest = 3001,
        /// <summary>
        /// 查询历史采样数据
        /// </summary>
        QueryHistorySampleDataRequest = 3002,
        /// <summary>
        /// 查询统计数据数据
        /// </summary>
        QueryStatisticsDataRequest = 3003,
        /// <summary>
        /// 查询所有历史采样数据，这个接口危险，请确定不会返回海量数据
        /// </summary>
        QueryAllHistorySampleDataRequest = 3999,
        /// <summary>
        /// 高效查询历史波形数据
        /// </summary>
        QueryHistoryWaveformDataRequest = 3004,

        /// <summary>
        /// 查询服务器接口版本信息
        /// </summary>
        QueryVersionRequest = 4001,

        

        QueryResponse = -1001,
        AddResponse = -1002,
        ModifyResponse = -1003,
        ComplexResponse = -1004,
        DeleteResponse = -1005,
        /// <summary>
        /// 与设备通信
        /// </summary>
        CommunicateDeviceResponse = -2001,
        /// <summary>
        /// 查询最新采样数据
        /// </summary>
        QueryLatestSampleDataResponse = -3001,
        /// <summary>
        /// 查询历史采样数据
        /// </summary>
        QueryHistorySampleDataResponse = -3002,
        /// <summary>
        /// 查询统计数据数据
        /// </summary>
        QueryStatisticsDataResponse = -3003,
        /// <summary>
        /// 查询所有历史采样数据，这个接口危险，请确定不会返回海量数据
        /// </summary>
        QueryAllHistorySampleDataResponse = -3999,
        /// <summary>
        /// 高效查询历史波形数据
        /// </summary>
        QueryHistoryWaveformDataResponse = -3004,

        /// <summary>
        /// 查询服务器接口版本信息
        /// </summary>
        QueryVersionResponse = -4001,
    }
}

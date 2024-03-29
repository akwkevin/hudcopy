﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappy;
using CitizenSoftwareLib.Common;

namespace CitizenSoftwareLib.Network.Socket
{
    /// <summary>
    /// UInt32          Byte                   GUID去掉-           Int16           UInt32             UInt32          Byte Array
    /// Length(4byte) + Compress(1byte) + SessionContent(32byte) + Type(2byte) + DataCount(4byte) + { Length(4byte) + Data(nbyte) }
    ///                                                                                            |-       Compress区域       -|
    /// </summary>
    public class TCPMessage
    {
        /// <summary>
        /// 本次请求压缩方式
        /// </summary>
        public CompressMode RequestCompressMode { get; set; }

        /// <summary>
        /// 如果希望应答，应答的压缩方式
        /// </summary>
        public CompressMode ResponseCompressMode { get; set; }

        /// <summary>
        /// 协议主版本
        /// </summary>
        public ushort MajorVerson { get; set; } 
        /// <summary>
        /// 协议分支版本
        /// </summary>
        public ushort MinorVersion { get; set; }

        /// <summary>
        /// 消息的Session
        /// </summary>
        public string Session { get;set; }
        /// <summary>
        /// 消息类型，可以自定义消息类型,AIC.OnlineSystem.Common.MessageType
        /// </summary>
        public short Type { get; set; }

        private byte[][] _datas = null;
        public byte[][] Datas
        {
            get { return _datas; }
            set { _datas = value; _dataChanged = true; }
        }

        public long DataLength
        {
            get
            {
                if (_datas == null) return 0;
                else
                {
                    return _datas.Sum(data => data == null ? 0 : data.LongLength);
                }
            }
        }

        private bool _dataChanged = false;
        private string[] _dataTexts = null;

        /// <summary>
        /// String数组形式的内容，方便设置，如果是二进制，最好直接使用Datas
        /// </summary>
        public string[] DataTexts
        {
            get
            {
                if (_dataTexts == null || _dataChanged)
                {
                    if (Datas == null) return null;
                    else
                    {
                        _dataTexts = Datas.Select(data => Encoding.UTF8.GetString(data)).ToArray();
                    }
                }
                return _dataTexts;
            }
            set
            {
                if (value == null) Datas = null;
                else
                {
                    Datas = value.Select(text => string.IsNullOrWhiteSpace(text) ? new byte[0] : Encoding.UTF8.GetBytes(text)).ToArray();
                }
            }
        }

        public TCPMessage()
        {
            Session = Guid.NewGuid().ToString("N");
            RequestCompressMode = CompressMode.None;
            ResponseCompressMode = CompressMode.None;
            MajorVerson = 1;
            MinorVersion = 1;
        }

        public byte[] GetStreamBody()
        {
            if (RequestCompressMode != CompressMode.None)
            {
                byte[] body = null;
                using (MemoryStream stream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8))
                    {
                        foreach (var data in Datas)
                        {
                            writer.Write((uint)data.LongLength);
                            writer.Write(data);
                        }
                        writer.Flush();
                    }
                    if (RequestCompressMode == CompressMode.Snappy)
                    {
                        body = SnappyCodec.Compress(stream.ToArray());
                    }
                    else if (RequestCompressMode == CompressMode.Gzip)
                    {
                        body = GzipOperator.Compress(stream.ToArray());
                    }
                    else throw new Exception("Unknow CompressMode");
                }
                using (MemoryStream stream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8))
                    {
                        writer.Write((byte)RequestCompressMode);
                        writer.Write((byte)ResponseCompressMode);
                        writer.Write(Encoding.UTF8.GetBytes(Session));
                        writer.Write(Type);
                        writer.Write(MajorVerson);
                        writer.Write(MinorVersion);
                        writer.Write((uint)Datas.LongLength);
                        writer.Write(body);
                        writer.Flush();
                    }
                    return stream.ToArray();
                }
            }
            else
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8))
                    {
                        writer.Write((byte)RequestCompressMode);
                        writer.Write((byte)ResponseCompressMode);
                        writer.Write(Encoding.UTF8.GetBytes(Session));
                        writer.Write(Type);
                        writer.Write(MajorVerson);
                        writer.Write(MinorVersion);
                        writer.Write((uint)Datas.LongLength);
                        foreach (var data in Datas)
                        {
                            writer.Write((uint)data.LongLength);
                            writer.Write(data);
                        }
                        writer.Flush();
                    }
                    return stream.ToArray();
                }
            }
        }

        public void WriteToStream(Stream stream)
        {
            try
            {
                byte[] data = this.GetStreamBody();
                byte[] len = BitConverter.GetBytes((uint)data.LongLength);
                stream.Write(len);
                stream.Write(data);
                stream.Flush();
            }
            catch { }
        }

    }
}

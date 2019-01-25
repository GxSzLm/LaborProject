using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using LaborProject.ComManip;

namespace LaborProject.ComFrames
{
    public class theFrame
    {
        // 辅助FrameBytesInString()函数进行输出，有的字节数组太长了
        protected string ByteArrContent(byte[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; ++i)
            {
                str = str + " " + arr[i].ToString("X2");
            }
            return str;
        }

    }

    // 数据源参数配置帧
    public class ConfigDataSourceFrame : theFrame
    {
        // 端口物理连接状态查询帧的帧结构
        [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 1, CharSet = CharSet.Ansi)]   // 之前采用的LayoutKind是Explicit，在该附加字段设置下无法使用byte数组
        public struct Frame_ConfigDataSource
        {
            public byte frame_header;
            public byte frame_type;
            public byte parameter_type;
            public byte test_type;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] test_frame_length;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] frame_interval;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] number_of_test;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] number_of_frames_each_time;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] port_number_src_plus_dest;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] mac_addr_src;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] mac_addr_dest;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] ip_packet_header;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] udp_port_src;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] udp_port_dest;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] custom_data;
        }

        public Frame_ConfigDataSource frm;       // 使用StructToBytes方法转成byte数组前，进行了内存对齐的结构体。

        // 构造函数(这年头构造函数也需要访问限制了吗）
        public ConfigDataSourceFrame(byte test_type, byte[] test_frame_length,byte[] frame_interval, byte[] number_of_test, byte[] number_of_frames_each_time, byte[] port_number, 
                                     byte[] mac_addr_src, byte[] mac_addr_dest, byte[] ip_packet_header, byte[] udp_port_src, byte[] udp_port_dest, byte[] custom_data)
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x04;

            frm.test_type = test_type;
            frm.test_frame_length = test_frame_length;
            frm.frame_interval = frame_interval;
            frm.number_of_test = number_of_test;
            frm.number_of_frames_each_time = number_of_frames_each_time;
            frm.port_number_src_plus_dest = port_number;
            frm.mac_addr_src = mac_addr_src;
            frm.mac_addr_dest = mac_addr_dest;
            frm.ip_packet_header = ip_packet_header;
            frm.udp_port_src = udp_port_src;
            frm.udp_port_dest = udp_port_dest;
            frm.custom_data = custom_data;
        }

        // 将16进制的帧内容写进字符串中返回。
        public string FrameBytesInString()
        {
            return frm.frame_header.ToString("X2")
                + " " + frm.frame_type.ToString("X2")
                + " " + frm.parameter_type.ToString("X2")
                + " " + frm.test_type.ToString("X2")

                + ByteArrContent(frm.test_frame_length)
                + ByteArrContent(frm.frame_interval)
                + ByteArrContent(frm.number_of_test)
                + ByteArrContent(frm.number_of_frames_each_time)
                + ByteArrContent(frm.port_number_src_plus_dest)
                + ByteArrContent(frm.mac_addr_src)
                + ByteArrContent(frm.mac_addr_dest)
                + ByteArrContent(frm.ip_packet_header)
                + ByteArrContent(frm.udp_port_src)
                + ByteArrContent(frm.udp_port_dest)
                + ByteArrContent(frm.custom_data);
        }

        // 发送frm到指定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));
            return true;
        }
    }

    // 端口配置帧
    public class PortConfigFrame : theFrame
    {
        [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 1, CharSet = CharSet.Ansi)]   // 之前采用的LayoutKind是Explicit，在该附加字段设置下无法使用byte数组
        public struct Frame_PortConfig
        {
            public byte frame_header;
            public byte frame_type;
            public byte parameter_type;
            public byte port_id;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] mac_addr;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ip_addr;

            //public byte fill;
        }

        public Frame_PortConfig frm;

        // 构造函数(这年头构造函数也需要访问限制了吗）
        // 目前的参数用作测试 用户应该可以自定义
        public PortConfigFrame()
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x02;

            frm.port_id = 0x01;

            frm.mac_addr = new byte[6] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            frm.ip_addr = new byte[4] { 0xc0, 0xA8, 0x00, 0x17 };
        }

        // 将16进制的帧内容写进字符串中返回。
        public string FrameBytesInString()
        {
            return frm.frame_header.ToString("X2")
                + " " + frm.frame_type.ToString("X2")
                + " " + frm.parameter_type.ToString("X2")
                + ByteArrContent(frm.mac_addr)
                + ByteArrContent(frm.ip_addr);
        }

        // 发送frm到指定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));
            return true;
        }

    }

    // 端口物理连接状态查询帧
    public class TestBeginFrame : theFrame
    {
        // 端口物理连接状态查询帧的帧结构
        [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 1, CharSet = CharSet.Ansi)]   // 之前采用的LayoutKind是Explicit，在该附加字段设置下无法使用byte数组
        public struct Frame_TestBegin
        {
            public byte frame_header;
            public byte frame_type;
            public byte parameter_type;
            public byte number_of_port_in_test;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] port_id;
        }

        public Frame_TestBegin frm;       // 使用StructToBytes方法转成byte数组前，进行了内存对齐的结构体。

        // 构造函数
        public TestBeginFrame(byte port_num, byte port0_id = 0, byte port1_id = 0, byte port2_id = 0, byte port3_id = 0)
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x03;
            frm.number_of_port_in_test = port_num;

            frm.port_id[0] = port0_id;
            frm.port_id[1] = port1_id;
            frm.port_id[2] = port2_id;
            frm.port_id[3] = port3_id;
        }

        // 将16进制的帧内容写进字符串中返回。
        public string FrameBytesInString()
        {
            return frm.frame_header.ToString("X2")
                + " " + frm.frame_type.ToString("X2")
                + " " + frm.parameter_type.ToString("X2")
                + " " + frm.number_of_port_in_test.ToString("X2")
                + ByteArrContent(frm.port_id);
        }

        // 发送frm到指定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));
            return true;
        }
    }

    // 端口物理连接状态查询帧
    public class ConnectionStatusInquiryFrame : theFrame
    {
        // 端口物理连接状态查询帧的帧结构
        [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 1, CharSet = CharSet.Ansi)]   // 之前采用的LayoutKind是Explicit，在该附加字段设置下无法使用byte数组
        public struct Frame_ConnectionStatusInquiry
        {
            public byte frame_header;
            public byte frame_type;
            public byte parameter_type;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] inquiry_type;

            public byte fill;
        }

        public Frame_ConnectionStatusInquiry frm;       // 使用StructToBytes方法转成byte数组前，进行了内存对齐的结构体。

        // 构造函数(这年头构造函数也需要访问限制了吗）
        public ConnectionStatusInquiryFrame()
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x04;
            frm.inquiry_type = new byte[2] { 0x00, 0x01 };
            frm.fill = 0x00;
        }

        // 将16进制的帧内容写进字符串中返回。
        public string FrameBytesInString()
        {
            return frm.frame_header.ToString("X2")
                + " " + frm.frame_type.ToString("X2")
                + " " + frm.parameter_type.ToString("X2")
                + " " + frm.inquiry_type[0].ToString("X2")
                + " " + frm.inquiry_type[1].ToString("X2")
                + " " + frm.fill.ToString("X2");
        }

        // 发送frm到指定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));       
            return true;
        }
    }

    // 端口参数查询帧
    public class PortParameterInquiryFrame : theFrame
    {
        // 端口参数查询帧的帧结构
        [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 1, CharSet = CharSet.Ansi)]   // 之前采用的LayoutKind是Explicit，在该附加字段设置下无法使用byte数组
        public struct Frame_PortParameter
        {
            public byte frame_header;
            public byte frame_type;
            public byte parameter_type;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] inquiry_type;

            public byte fill;
        }

        public Frame_PortParameter frm;       // 使用StructToBytes方法转成byte数组前，进行了内存对齐的结构体。

        // 构造函数
        public PortParameterInquiryFrame()
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x04;
            frm.inquiry_type = new byte[2] { 0x00, 0x02 };
            frm.fill = 0x01;
        }

        // 将16进制的帧内容写进字符串中返回。
        public string FrameBytesInString()
        {
            return frm.frame_header.ToString("X2")
                + " " + frm.frame_type.ToString("X2")
                + " " + frm.parameter_type.ToString("X2")
                + " " + frm.inquiry_type[0].ToString("X2")
                + " " + frm.inquiry_type[1].ToString("X2")
                + " " + frm.fill.ToString("X2");
        }

        // 发送frm到指定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));
            return true;
        }
    }

    // 开始帧
    public class StartFrame : theFrame
    {
        // 开始帧的帧结构
        [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 1, CharSet = CharSet.Ansi)]   // 之前采用的LayoutKind是Explicit，在该附加字段设置下无法使用byte数组
        public struct Frame_Start
        {
            public byte frame_header;
            public byte frame_type;
            public byte parameter_type;
        }

        public Frame_Start frm;       // 使用StructToBytes方法转成byte数组前，进行了内存对齐的结构体。

        // 构造函数
        public StartFrame()
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x05;
        }

        // 将16进制的帧内容写进字符串中返回。
        public string FrameBytesInString()
        {
            return frm.frame_header.ToString("X2")
                + " " + frm.frame_type.ToString("X2")
                + " " + frm.parameter_type.ToString("X2");
        }

        // 发送frm到指定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));
            return true;
        }
    }

    // 复位帧
    public class ResetFrame : theFrame
    {
        // 复位帧的帧结构
        [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 1, CharSet = CharSet.Ansi)]   // 之前采用的LayoutKind是Explicit，在该附加字段设置下无法使用byte数组
        public struct Frame_Reset
        {
            public byte frame_header;
            public byte frame_type;
            public byte parameter_type;
        }

        public Frame_Reset frm;       // 使用StructToBytes方法转成byte数组前，进行了内存对齐的结构体。

        // 构造函数
        public ResetFrame()
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x06;
        }

        // 将16进制的帧内容写进字符串中返回。
        public string FrameBytesInString()
        {
            return frm.frame_header.ToString("X2")
                + " " + frm.frame_type.ToString("X2")
                + " " + frm.parameter_type.ToString("X2");
        }

        // 发送frm到指定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));
            return true;
        }
    }

    // 端口状态命令帧
    public class PortStatusCommandFrame : theFrame
    {
        // 端口状态命令帧的帧结构
        [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 1, CharSet = CharSet.Ansi)]   // 之前采用的LayoutKind是Explicit，在该附加字段设置下无法使用byte数组
        public struct Frame_PortStatusCommand
        {
            public byte frame_header;
            public byte frame_type;
            public byte parameter_type;
            public byte port_id;
            public byte command;
        }

        public Frame_PortStatusCommand frm;       // 使用StructToBytes方法转成byte数组前，进行了内存对齐的结构体。

        // 构造函数
        public PortStatusCommandFrame(byte port_id, byte command)
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x03;
            frm.port_id = port_id;
            frm.command = command;
        }

        // 将16进制的帧内容写进字符串中返回。
        public string FrameBytesInString()
        {
            return frm.frame_header.ToString("X2")
                + " " + frm.frame_type.ToString("X2")
                + " " + frm.parameter_type.ToString("X2")
                + " " + frm.port_id.ToString("X2")
                + " " + frm.command.ToString("X2");
        }

        // 发送frm到指定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));
            return true;
        }
    }

    // 业务帧
    public class ServiceFrame : theFrame
    {
        // 端口状态命令帧的帧结构
        [StructLayout(LayoutKind.Sequential, Size = 6, Pack = 1, CharSet = CharSet.Ansi)]   // 之前采用的LayoutKind是Explicit，在该附加字段设置下无法使用byte数组
        public struct Frame_Service
        {
            public byte frame_header;
            public byte frame_type;
            public byte port_id;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] frame_length;

            public byte[] frame_data;
        }

        public Frame_Service frm;       // 使用StructToBytes方法转成byte数组前，进行了内存对齐的结构体。

        // 构造函数
        public ServiceFrame(byte port_id, byte[] frame_length, byte[] frame_data)
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x05;
            frm.port_id = port_id;

            frm.frame_length = frame_length;
            frm.frame_data = frame_data;
        }

        // 将16进制的帧内容写进字符串中返回。
        //public string FrameBytesInString()
        //{
        //    return frm.frame_header.ToString("X2")
        //        + " " + frm.frame_type.ToString("X2")
        //        + " " + frm.parameter_type.ToString("X2")
        //        + " " + frm.port_id.ToString("X2")
        //        + " " + frm.command.ToString("X2");
        //}

        // 发送frm到指定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));
            return true;
        }
    }
    
}

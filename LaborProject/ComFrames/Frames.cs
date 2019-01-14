using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using LaborProject.ComManip;

namespace LaborProject.ComFrames
{
    public class ConnectionStatusInquiryFrame
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

        // 发送frm到制定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));       
            return true;
        }
    }

    public class PortParameterInquiryFrame
    {
        // 端口物理连接状态查询帧的帧结构
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

        // 发送frm到制定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));
            return true;
        }
    }

    // 端口配置帧
    public class PortConfigFrame
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


            //frm.fill = 0x00;
        }

        // 将16进制的帧内容写进字符串中返回。
        public string FrameBytesInString()
        {
            return frm.frame_header.ToString("X2")
                + " " + frm.frame_type.ToString("X2")
                + " " + frm.parameter_type.ToString("X2")
                + " " + frm.mac_addr[0].ToString("X2")
                + " " + frm.mac_addr[1].ToString("X2")
                + " " + frm.mac_addr[2].ToString("X2")
                + " " + frm.mac_addr[3].ToString("X2")
                + " " + frm.mac_addr[4].ToString("X2")
                + " " + frm.mac_addr[5].ToString("X2")
                + " " + frm.ip_addr[0].ToString("X2")
                + " " + frm.ip_addr[1].ToString("X2")
                + " " + frm.ip_addr[2].ToString("X2")
                + " " + frm.ip_addr[3].ToString("X2");
        }

        // 发送frm到制定的串口。
        public bool SendFrame(Serialmanip com)
        {
            com.rs232.send(Tools.StructToBytes(frm));
            return true;
        }

    }
    // 时延测试的数据源参数帧
    public class Frame_TestDelay
    {

    }

    // 丢包测试的数据源参数帧
    public class Frame_TestLoss
    {

    }
    
}

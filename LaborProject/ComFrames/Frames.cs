using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace LaborProject.ComFrames
{
    public class Frames
    {
        // 端口物理连接状态查询帧
        [StructLayout(LayoutKind.Explicit, Size = 6, Pack = 1, CharSet = CharSet.Ansi)]
        public struct Frame_ConnectionStatusInquiry
        {
            [FieldOffset(0)]
            public byte frame_header;
            [FieldOffset(1)]
            public byte frame_type;
            [FieldOffset(2)]
            public byte parameter_type;
            [FieldOffset(3)]
            public ushort inquiry_type;
            //public ushort inquiry_type;
            [FieldOffset(5)]
            public byte fill;
        }

        public Frame_ConnectionStatusInquiry frm;               // 使用StructToBytes方法转成byte数组前，进行了内存对齐的结构体。

        // 构造函数(构造函数也需要访问限制了吗）
        public Frames()
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x04;

            frm.inquiry_type = 0x0100;
            //frm.inquiry_type = new byte[2];
            //frm.inquiry_type[0] = 0x00;
            //frm.inquiry_type[1] = 0x01;

            frm.fill = 0x00;
        }

        // 发送
        public bool send()
        {
            Serialmanip Serial = new Serialmanip();
            Serial.Com_open();
            Serial.rs232.send(Tools.StructToBytes(frm));

            return true;
        }
    }

    

    /*
    // 端口配置帧 还没完成
    public class Frame_PortConfigure : Frames
    {
        [StructLayout(LayoutKind.Explicit, Size = 16, Pack = 1, CharSet = CharSet.Ansi)]
        public struct frame
        {
            [FieldOffset(0)]
            public byte frame_header;
            [FieldOffset(1)]
            public byte frame_type;
            [FieldOffset(2)]
            public byte parameter_type;
            [FieldOffset(3)]
            public byte port_number;
            [FieldOffset(4)]
            public byte[] mac_address;      // 怎么存自定义位数的变量？
            [FieldOffset(10)]               // mac地址48位，所以相比之前此处应该有6位的额外偏移，总共是1+1+1+1+6=10
            public byte[] ip_address;
            // 给了一个数据类型0x02 不知道指的是哪一个参数
            // 也许需要一个public byte data_type;
        }
        public frame frm;

        Frame_PortConfigure(byte[] mac, byte[] ip)
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x02;  // 似乎没有规定
            frm.port_number = 0x0001;   // 没有规定

            frm.mac_address = mac;
            frm.ip_address = ip;
        }

        protected override bool send()
        {
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
    */
}

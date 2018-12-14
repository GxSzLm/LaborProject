using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace LaborProject.Api
{
    public class Frames
    {   
        private bool send()
        {
            return true;
        }
    }

    public class Frame_ConnectionStatusInquiry : Frames
    {
        [StructLayout(LayoutKind.Explicit, Size = 5, Pack = 1, CharSet = CharSet.Ansi)]
        public struct frame
        {
            [FieldOffset(0)]
            public byte frame_header;
            [FieldOffset(1)]
            public byte frame_type;
            [FieldOffset(2)]
            public byte parameter_type;
            [FieldOffset(3)]
            public ushort inquiry_type;
        }

        public frame frm;

        Frame_ConnectionStatusInquiry()
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x04;
            frm.inquiry_type = 0x0001;
        }
        
    }

    public class Frame_PortConfigure : Frames
    {
        [StructLayout(LayoutKind.Explicit, Size = 5, Pack = 1, CharSet = CharSet.Ansi)]
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
            public byte[] mac_address; // 怎么存自定义位数的变量？
            [FieldOffset(5)]
            public byte[] ip_address;
            // 给了一个数据类型0x02 不知道指的是哪一个参数
        }
        public frame frm;

        Frame_PortConfigure()
        {
            frm.frame_header = 0xff;
            frm.frame_type = 0x01;
            frm.parameter_type = 0x02; // 似乎没有规定
            frm.port_number = 0x0001; // 没有规定
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LaborProject.ComFrames
{
    // 存放解码收到的帧所用的方法的类
    class FrameDecoder
    {

    }

    // 连接状态反馈帧
    // 
    class FDecoder_ConnectionStatusFeedback
    {
        public struct frame
        {
            public byte header_mark;
            public byte frm_type;
            public byte para_type;
            public byte[] inq_type;
            public byte port_num;

            public byte[] port_status;            
        }

        frame inFrm;

        public void Decode(byte[] frm)
        {
            // 读取header标志
            inFrm.header_mark = frm[0];
            if (inFrm.header_mark != 0xff)
                return;// 此处应该报错

            // 读取帧类型 应确保为0x04
            inFrm.frm_type = frm[1];
            if (inFrm.frm_type != 0x04)
                return;// 此处应报错

            // 读取参数类型，应为0x04
            inFrm.para_type = frm[2];
            if (inFrm.para_type != 0x04)
                return;// 此处应报错

            // 读取参数类型，应为0x04
            inFrm.inq_type = new byte[2];
            inFrm.inq_type[0] = frm[3];
            inFrm.inq_type[1] = frm[4];
            if (inFrm.inq_type[0] != 0x00 && inFrm.inq_type[1] != 0x01)
                return;// 此处应报错

            // 读取端口数量，0-4间整数
            inFrm.port_num = frm[5];
            // 暂不做错误检查
            inFrm.port_status = new byte[inFrm.port_num];
            
            for(int i = 0; i < inFrm.port_num; ++i)
            {
                inFrm.port_status[i] = frm[6 + i];
            }

            // For TEST
            Display();
            return;
        }

        private void Display()
        {
            System.Windows.MessageBox.Show("PORT NUMBER:" + inFrm.port_num + "Port 0 status: " + inFrm.port_status[0]);
        }
    }

    // 时延参数显示帧
    class FDecoder_DelayParameterDisplay
    {

    }

    // 丢包参数显示帧
    class FDecoder_LossParameterDisplay
    {

    }


}

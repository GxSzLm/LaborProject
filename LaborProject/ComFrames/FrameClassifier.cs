using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using LaborProject.Modules;


namespace LaborProject.ComFrames
{

    public class InquiryParameterFeedbackEventArgs: EventArgs
    {
        // 构造函数
        public InquiryParameterFeedbackEventArgs(int pnum)
        {
            PortNum = pnum;
            PortConnectionStatus = new byte[PortNum];
        }

        public int PortNum { get; private set; }
        public byte[] PortConnectionStatus { get; }
    }
    // 存放解码收到的帧所用的方法的类
    class FrameDecoder
    {

    }

    // 分类器确保接收到的帧确实有效，并且识别帧的种类，将其分配给各个解码器
    public class FrameClassifier
    {
        public enum IncomingFrameTypes
        {
            UnknownType = -1,        // 未知格式的帧，一般意味着格式不对
            WrongType = 0,          // 错误的帧，格式符合要求，但是来错了地方

            Config_DataSrc,         // 测试仪配置帧--数据源参数    0xff 0x01 0x01
            Config_PortParameter,   // 测试仪配置帧--端口配置参数   0xff 0x01 0x02
            Config_TestOn,          // 测试仪配置帧--测试启动参数   0xff 0x01 0x03
            Config_Inquiry,         // 测试仪配置帧--查询参数      0xff 0x01 0x04
            Config_Start,           // 测试仪配置帧--启动测试      0xff 0x01 0x05
            Config_Reset,           // 测试仪配置帧--复位测试      0xff 0x01 0x06
            Config_PortStatus,      // 测试仪配置帧--端口状态命令   0xff 0x01 0x07


            PortDisplay_Send,       // 端口显示帧--端口发送帧     0xff 0x02 0x01
            PortDisplay_Recv,       // 端口显示帧--端口接受帧     0xff 0x02 0x01

            TestDisplay_Delay,      // 测试显示帧--时延参数帧     0xff 0x03 0x01
            TestDisplay_Loss,       // 测试显示帧--丢帧参数帧     0xff 0x03 0x02

            Feedback_DataSrc,                     // 配置反馈帧--数据源反馈帧    0xff 0x04 0x01
            Feedback_Inquiry_ConnectionStatus,    // 配置反馈帧--查询参数反馈帧--端口物理连接状态   0xff 0x04 0x01 0x0001
            Feedback_Inquiry_Parameter,           // 配置反馈帧--查询参数反馈帧--端口参数   0xff 0x04 0x01 0x0002

            xxx,                // 业务帧 应该是发送的，当前不太清楚，先写在这儿
        }


        // 接受一个字节数组，分析其位于前面的各个字段，返回该帧的类型
        private IncomingFrameTypes AnalyzeFrameHeader(byte[] data, ref int index)
        {
            int arr_size = data.Length;     // 获取数组长度

            // 第一个字节都应是0xff
            if(data[++index] != 0xff)
            {
                return IncomingFrameTypes.UnknownType;
            }

            // 第二个字节
            // 0x01 配置帧; 0x02 端口显示帧; 0x03 测试显示帧; 0x04 配置反馈帧; 0x05 业务帧;
            switch (data[++index])
            {
                case 0x01:
                    {
                        // 配置帧
                        // 配置帧是发送用的，进这儿就错了
                        return IncomingFrameTypes.WrongType;
                    }
                case 0x02:
                    {
                        // 端口显示帧
                        // 调用端口显示帧的decoder
                        switch (data[++index])
                        {
                            case 0x01:
                                {
                                    return IncomingFrameTypes.PortDisplay_Send;
                                }
                            case 0x02:
                                {
                                    return IncomingFrameTypes.PortDisplay_Recv;
                                }
                            default:
                                {
                                    return IncomingFrameTypes.UnknownType;
                                }
                        }
                    }
                case 0x03:
                    {
                        // 测试显示帧
                        switch (data[++index])
                        {
                            case 0x01:
                                {
                                    return IncomingFrameTypes.TestDisplay_Delay;
                                }
                            case 0x02:
                                {
                                    return IncomingFrameTypes.TestDisplay_Loss;
                                }
                            default:
                                {
                                    return IncomingFrameTypes.UnknownType;
                                }
                        }
                    }
                case 0x04:
                    {
                        // 配置反馈帧
                        // 调用配置反馈帧的decoder
                        switch (data[++index])
                        {
                            case 0x01:
                                {
                                    return IncomingFrameTypes.Feedback_DataSrc;
                                }
                            case 0x02:
                                {
                                    if (data[++index] == 0x00)
                                    {
                                        switch (data[++index])
                                        {
                                            case 0x01:
                                                {
                                                    return IncomingFrameTypes.Feedback_Inquiry_ConnectionStatus;
                                                }
                                            case 0x02:
                                                {
                                                    return IncomingFrameTypes.Feedback_Inquiry_Parameter;
                                                }
                                            default:
                                                {
                                                    return IncomingFrameTypes.UnknownType;
                                                }     
                                        }
                                    }
                                    else
                                        return IncomingFrameTypes.UnknownType;
                                }
                            default:
                                {
                                    return IncomingFrameTypes.UnknownType;
                                }
                        }
                    }
                case 0x05:
                    {
                        // 业务帧
                        return IncomingFrameTypes.xxx;
                    }
                default:
                    {
                        // 如果进入default就说明搞错了，接收到了错误的帧
                        return IncomingFrameTypes.UnknownType;
                    }
            }
        }

        // 对外部用这个方法作接口 
        public IncomingFrameTypes RunClassifier(byte[] data)
        {
            int index = -1;
            IncomingFrameTypes f_type = AnalyzeFrameHeader(data, ref index);
            if (f_type == IncomingFrameTypes.UnknownType)
            {
                // 未知类型的帧
                return f_type;
            }
            else if(f_type == IncomingFrameTypes.WrongType)
            {
                // 发错了地儿的帧
                return f_type;
            }
            // 以上情况应该丢弃该帧，并且在UI层输出相关提示
            else
            {
                return f_type;
            }
        }

    }
}

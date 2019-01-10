using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using LaborProject.Modules;


namespace LaborProject.ComFrames
{
    using map = Tools.FMap;

    // 存放解码收到的帧所用的方法的类
    class FrameDecoder
    {

    }

    // 分类器确保接收到的帧确实有效，并且识别帧的种类，将其分配给各个解码器
    class FrameClassifier
    {
        private enum IncomingFrameTypes
        {
            PortDisplay,        // 端口显示
            TestDisplay,        // 测试显示
            ConfigFeedback,     // 配置反馈
            xxx,                // 业务帧 应该是发送的，当前不太清楚，先写在这儿
            
            UnknownType,        // 未知格式的帧，一般意味着格式不对
            WrongType,          // 错误的帧，格式符合要求，但是来错了地方
        }

        // 接受一个字节数组，分析其位于前面的各个字段。返回值返回该帧的有效性
        private static IncomingFrameTypes AnalyzeFrame(byte[] data, ref int nextIndex)
        {
            int arr_size = data.Length;     // 获取数组长度


            // 第一个字节都应是0xff
            if(data[nextIndex] != 0xff)
            {
                ++nextIndex;
                return IncomingFrameTypes.UnknownType;
            }

            // 第二个字节
            // 0x01 配置帧; 0x02 端口显示帧; 0x03 测试显示帧; 0x04 配置反馈帧; 0x05 业务帧;
            switch (data[nextIndex])
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
                        return IncomingFrameTypes.PortDisplay;
                    }
                case 0x03:
                    {
                        // 测试显示帧
                        return IncomingFrameTypes.TestDisplay;
                    }
                case 0x04:
                    {
                        // 配置反馈帧
                        // 调用配置反馈帧的decoder
                        return IncomingFrameTypes.ConfigFeedback;
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
        public static List<map> RunClassifier(byte[] data)
        {
            int nextIndex = 0;
            IncomingFrameTypes f_type = AnalyzeFrame(data, ref nextIndex);
            if (f_type == IncomingFrameTypes.UnknownType)
            {
                // 未知类型的帧
                return null;
            }
            else if(f_type == IncomingFrameTypes.WrongType)
            {
                // 发错了地儿的帧
                return null;
            }
            // 以上情况应该丢弃该帧，并且在UI层输出相关提示
            else
            {
                ++nextIndex;

                // 之前的分析中没有出现问题，帧（截至目前）有效
                switch (f_type)
                {
                    case IncomingFrameTypes.PortDisplay:
                        {
                            // 端口显示帧
                            // 调用端口显示帧的decoder
                            break;
                        }
                    case IncomingFrameTypes.TestDisplay:
                        {
                            // 测试显示帧
                            break;
                        }
                    case IncomingFrameTypes.ConfigFeedback:
                        {
                            // 配置反馈帧共2种：数据源反馈帧，查询参数反馈帧
                            // 判断是哪一种，调用相应配置反馈帧的fdecoder
                            switch (data[nextIndex])
                            {
                                case 0x01:
                                    {
                                        // 数据源反馈帧
                                        ++nextIndex;
                                        return ProcessDataSourceFeedback(data, nextIndex);
                                    }
                                case 0x02:
                                    {
                                        // 查询参数反馈帧
                                        ++nextIndex;
                                        return ProcessInquiryParameterFeedback(data, nextIndex);
                                    }
                                default:
                                    {
                                        // 无效数据
                                        return null;
                                    }
                            }
                            // 上面的全部都能返回
                        }
                    default:
                        {
                            return null;
                        }
                }
                return null;

            }
        }

        private static List<map> ProcessDataSourceFeedback(byte[] data, int idx)
        {
            int portNumberSrc = data[idx++];
            int portNumberDest = data[idx++];
            int testType = data[idx++];

            
            List<map> outList = new List<map>();

            outList.Add(new map("Data Source Feedback Frame", "数据源反馈帧", ""));
            outList.Add(new map("Source Port No.", "源端口号", portNumberSrc.ToString()));
            outList.Add(new map("Destnation Port No.", "目的端口号", portNumberDest.ToString()));
            outList.Add(new map("Test Type", "测试类型", testType.ToString()));

            return outList;
        }

        private static List<map> ProcessInquiryParameterFeedback(byte[] data, int idx)
        {
            if(data[idx++] == 0x00 && (data[idx] == 0x01 || data[idx] == 0x02))
            {
                if (data[idx] == 0x01)
                {
                    ++idx;
                    int portNum = data[idx++];

                    int[] portStat = new int[portNum];
                    for(int i = 0; i < portNum; ++i, ++idx)
                    {
                        portStat[i] = data[idx];
                    }

                    List<map> outList = new List<map>();

                    outList.Add(new map("Inquiry Parameter Feedback Frame", "查询参数反馈帧", "Port Connection Status Feedback Frame"));
                    outList.Add(new map("Port Number", "端口数量", portNum.ToString()));
                    for (int i = 0; i < portNum; ++i, ++idx)
                    {
                        outList.Add(new map("Port" + i + " Connection Status", "端口" + i + "连接状态", portStat[i].ToString()));
                    }

                    return outList;
                }
                else
                {
                    ++idx;
                    int portNumber = data[idx++];

                    string ipAddr = "";
                    for (int i = 0; i < 4; ++i, ++idx)
                    {
                        ipAddr = ipAddr + data[idx];
                        if (i != 3)
                            ipAddr = ipAddr + ".";
                    }

                    string macAddr = "";
                    for (int i = 0; i < 6; ++i, ++idx)
                    {
                        macAddr = macAddr + data[idx];
                        if (i != 5)
                            macAddr = macAddr + "-";
                    }

                    List<map> outList = new List<map>();

                    outList.Add(new map("Inquiry Parameter Feedback Frame", "查询参数反馈帧", "Port Parameter Feedback Frame"));
                    outList.Add(new map("Port No.", "端口号", portNumber.ToString()));
                    outList.Add(new map("Port IP Address", "端口IP地址", ipAddr));
                    outList.Add(new map("Port MAC Address", "端口MAC地址", macAddr));

                    return outList;
                }
            }
            else
            {
                return null;
            }
        }


    }

    // 配置反馈帧
    // 
    class FDecoder_ConfigFeedback
    {
        public struct dataSourceFeedback
        {
            //public string header_mark;
            //public byte frm_type;
            //public byte para_type;
            public byte portNumberSrc;
            public byte portNumberDest;
            public byte testType;
        }

        public struct InquiryParameterFeedback
        {
            public byte header_mark;
            public byte frm_type;
            public byte para_type;
            public byte[] inq_type;
            public byte port_num;

            public byte[] port_status;            
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

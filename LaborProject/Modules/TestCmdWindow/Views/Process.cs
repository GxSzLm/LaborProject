using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using LaborProject.ComFrames;
using LaborProject.ComManip;
using LaborProject.Modules.GePort;
using LaborProject.Models;

namespace LaborProject.Modules.TestCmdWindow.Views
{
    public partial class TestCmdWindowView : UserControl
    {
        // 声明串口
        private Serialmanip serial;

        // 用来显示接收到的帧
        public static string RecvOutStr;

        // 是否第一次进行初始化（显示相关文字）
        private bool is_initialized = false;

        // 端口
        int PortNum = 0;
        TesterPort[] port = new TesterPort[] {
            new TesterPort(0),
            new TesterPort(1),
            new TesterPort(2),
            new TesterPort(3)
        }; // 先默认他是四个

        // 当下层帧来的时候在这儿显示一下原始内容
        private void ComFrameUp(object sender, FrameReceivedArgs e)
        {
            // 如果不用下面这一行，我想要的对象还被子线程所拥有，无法用来改变UI层的元素
            // 按这一行这样操作一下就可以了。虽然我也不清楚为什么，C#这边还需要学习。
            // 参考了https://blog.csdn.net/u014117094/article/details/47776165
            Dispatcher.Invoke(new Action(() => {
                _output.AppendLine("Frame received:  " + e.IncomingFrame + Environment.NewLine + Environment.NewLine);
                TheTextBox.ScrollToEnd();

                // 调用FrameClassifier来解析帧
                FrameClassifier.IncomingFrameTypes result;
                FrameClassifier classifier = new FrameClassifier();
                result = classifier.RunClassifier(e.IncomingFrameBytes);
                ProcessClassifyResult(result, e.IncomingFrameBytes);
            }));

            // 显示一次之后就取消委托，下次要再显示下次再添加委托。不然每次“初始化”都增加一个委托，每次都多显示一行同样的内容。
            serial.rs232.rsr.NewFrame -= ComFrameUp;

        }

        // 处理传回来的分类结果
        public void ProcessClassifyResult(FrameClassifier.IncomingFrameTypes result, byte[] data)
        {
            int startIndex;
            int index = 0;
            switch (result)
            {
                case FrameClassifier.IncomingFrameTypes.Feedback_DataSrc:
                    {
                        startIndex = 3;
                        
                        break;
                    }
                case FrameClassifier.IncomingFrameTypes.Feedback_Inquiry_ConnectionStatus:
                    {
                        startIndex = 5;
                        index = startIndex;
                        PortNum = data[index++];
                        if (PortNum != 4)
                        {
                            // 此处应该assert
                        }
                        for(int i = 0; i < PortNum; ++i, ++index)
                        {
                            if(data[index] == 0x01)
                            {
                                port[i].isConnected = true;
                            }
                            else
                            {
                                port[i].isConnected = false;
                            }
                            port[i].isAvailable = true;
                        }

                        _output.AppendLine("端口数量：" + PortNum + "，连接状态分别为：" + 
                                             port[0].isConnected + "," + port[1].isConnected + "," + port[2].isConnected + "," + port[3].isConnected + Environment.NewLine);
                        break;
                    }
                case FrameClassifier.IncomingFrameTypes.Feedback_Inquiry_Parameter:
                    {
                        startIndex = 5;
                        index = startIndex;
                        int portIdx = data[index++];
                        
                        // 提取ip地址
                        byte[] ipAddress = new byte[4];
                        for(int i = 0; i < ipAddress.Length; ++i, ++index)
                        {
                            ipAddress[i] = data[index];
                        }
                        port[portIdx].IpAddr.AddressInBytes = ipAddress;        // 赋值给端口

                        // 提取mac地址
                        byte[] macAddress = new byte[6];
                        for (int i = 0; i < macAddress.Length; ++i, ++index)
                        {
                            macAddress[i] = data[index];
                        }
                        port[portIdx].MacAddr.AddressInBytes = macAddress;      // 赋值给端口

                        _output.AppendLine("端口" + portIdx + "地址如下：");
                        _output.AppendLine("Ip Address:" + port[portIdx].IpAddr.AddressInString);
                        _output.AppendLine("Mac Address:" + port[portIdx].MacAddr.AddressInString);
                        _output.AppendLine("");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return;
        }

    }
}

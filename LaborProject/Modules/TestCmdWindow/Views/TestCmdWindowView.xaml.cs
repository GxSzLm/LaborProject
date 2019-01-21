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

using Caliburn.Micro;
using Gemini.Modules.Output;

using LaborProject.ComFrames;
using LaborProject.ComManip;

namespace LaborProject.Modules.TestCmdWindow.Views
{
    /// <summary>
    /// TestCmdWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class TestCmdWindowView : UserControl
    {
        private readonly IOutput _output;
        public TestCmdWindowView()
        {
            InitializeComponent();
            _output = IoC.Get<IOutput>();
            _output.AppendLine("I AM READY.");
        }

        // 用来打开串口的按钮
        private void OpenComButton_Click(object sender, RoutedEventArgs e)
        {
            if(serial != null && serial.rs232.ComPortIsOpen)      // 用串口的这个参数来获取串口是否打开这一状态
            {
                // 已经打开了就提示一下，啥也不干
                MessageBox.Show("串口已经打开");
                return;
            }
            else
            {
                // 如果串口还未打开，就尝试打开串口
                serial = new Serialmanip();
                serial.Com_open();

                // 应该都会成功吧，如果不成功应该在底层就会报错。保险起见留一个这个
                if (serial.rs232.ComPortIsOpen)
                {
                    TheTextBox.Text = "COM3 opened." + Environment.NewLine;
                    _output.AppendLine("COM3 opened." + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("串口打开失败，妹有打开");
                }
                return;
            }
        }

        // 按下初始化按钮之后执行的操作，即：发送连接状态查询帧。
        private void InitializeButton_Click(object sender, RoutedEventArgs e)
        {
            // 确认串口已经被打开
            if (serial != null && serial.rs232.ComPortIsOpen)
            {
                // 按钮被按下后进行初始化，发送对应的帧
                // 第一次被按下的时候现实性初始化相关字样
                if (!is_initialized)
                {
                    _output.AppendLine("Initialize process activated." + Environment.NewLine
                    + "Initializing..." + Environment.NewLine + Environment.NewLine);
                    is_initialized = true;
                }
                
                // 准备好要发送的帧
                ConnectionStatusInquiryFrame frames_inq = new ConnectionStatusInquiryFrame();

                // 做好帧的赋值工作（这个帧的值都是确定的）
                // 字符串保存即将发出去的帧内容，然后显示
                string outStr = frames_inq.FrameBytesInString();        
                _output.AppendLine("Sending inquiry frame......Content: " + outStr + Environment.NewLine + Environment.NewLine);
                TheTextBox.ScrollToEnd();

                // 注册等待接收事件
                serial.rs232.rsr.NewFrame += ComFrameUp;

                // 调用发送方法将其发给串口
                frames_inq.SendFrame(serial);
            }
            else
            {
                MessageBox.Show("未打开串口。");
                return;
            }
        }
       
        // reset按钮。这里应该向串口发送reset那个帧。
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // 似乎暂时没用
        private void TheTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // 似乎暂时没用，不过没上面那个没用
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            // 确认串口已经被打开
            if (serial != null && serial.rs232.ComPortIsOpen)
            {
                // 按钮被按下后发送对应的测试帧
                // 准备好要发送的帧
                PortConfigFrame frames_port_config = new PortConfigFrame();

                // 做好帧的赋值工作（这个帧的值都是确定的）
                // 字符串保存即将发出去的帧内容，然后显示
                string outStr = frames_port_config.FrameBytesInString();
                //_output.AppendLine("Sending test frame......Content: " + outStr + Environment.NewLine + Environment.NewLine);
                TheTextBox.ScrollToEnd();

                // 注册等待接收事件
                serial.rs232.rsr.NewFrame += ComFrameUp;

                // 调用发送方法将其发给串口
                frames_port_config.SendFrame(serial);
            }
            else
            {
                MessageBox.Show("未打开串口。");
                return;
            }
        }

        private void TestButton2_Click(object sender, RoutedEventArgs e)
        {
            // 确认串口已经被打开
            if (serial != null && serial.rs232.ComPortIsOpen)
            {
                // 按钮被按下后发送对应的测试帧
                // 准备好要发送的帧
                PortParameterInquiryFrame frames_portpara_inq = new PortParameterInquiryFrame();

                // 做好帧的赋值工作（这个帧的值都是确定的）
                // 字符串保存即将发出去的帧内容，然后显示
                string outStr = frames_portpara_inq.FrameBytesInString();
                _output.AppendLine("Sending test frame......Content: " + outStr + Environment.NewLine + Environment.NewLine);
                TheTextBox.ScrollToEnd();

                // 注册等待接收事件
                serial.rs232.rsr.NewFrame += ComFrameUp;

                // 调用发送方法将其发给串口
                frames_portpara_inq.SendFrame(serial);
            }
            else
            {
                MessageBox.Show("未打开串口。");
                return;
            }
        }

        private void Tree_Port0_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Port1Panel.Visibility = Visibility.Hidden;
            Port2Panel.Visibility = Visibility.Hidden;
            Port3Panel.Visibility = Visibility.Hidden;

            Port0Panel.Visibility = Visibility.Visible;
        }

        private void Tree_Port1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Port0Panel.Visibility = Visibility.Hidden;
            Port2Panel.Visibility = Visibility.Hidden;
            Port3Panel.Visibility = Visibility.Hidden;

            Port1Panel.Visibility = Visibility.Visible;
        }

        private void Tree_Port2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Port0Panel.Visibility = Visibility.Hidden;
            Port1Panel.Visibility = Visibility.Hidden;
            Port3Panel.Visibility = Visibility.Hidden;

            Port2Panel.Visibility = Visibility.Visible;
        }

        private void Tree_Port3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Port0Panel.Visibility = Visibility.Hidden;
            Port1Panel.Visibility = Visibility.Hidden;
            Port2Panel.Visibility = Visibility.Hidden;

            Port3Panel.Visibility = Visibility.Visible;
        }
    }
}

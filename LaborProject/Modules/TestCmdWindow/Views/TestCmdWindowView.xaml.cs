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

namespace LaborProject.Modules.TestCmdWindow.Views
{
    /// <summary>
    /// TestCmdWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class TestCmdWindowView : UserControl
    {
        public TestCmdWindowView()
        {
            InitializeComponent();
        }

        // 声明串口
        private Serialmanip serial;
        
        // 用来显示接收到的帧
        public static string RecvOutStr;

        // 是否第一次进行初始化（显示相关文字）
        private bool is_initialized = false;

        // 用来打开串口的按钮
        private void OpenComButton_Click(object sender, RoutedEventArgs e)
        {
            if(serial != null)// && serial.rs232.ComPortIsOpen)      // 用串口的这个参数来获取串口是否打开这一状态
            {
                // 打开了就提示一下，啥也不干
                MessageBox.Show("串口已经打开");
                return;
            }
            else
            {
                // 如果串口还未打开，就尝试打开串口
                serial = new Serialmanip();
                serial.Com_open();

                // 应该都会成功吧，如果不成功应该在底层就会报错。保险起见留一个这个
                if (true)//(serial.rs232.ComPortIsOpen)
                {
                    TheTextBox.Text = "COM3 opened." + Environment.NewLine;
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
            if (serial != null)// && serial.rs232.ComPortIsOpen)
            {
                // 按钮被按下后进行初始化，发送对应的帧
                // 第一次被按下的时候现实性初始化相关字样
                if (!is_initialized)
                {
                    TheTextBox.AppendText("Initialize process activated." + Environment.NewLine
                    + "Initializing..." + Environment.NewLine + Environment.NewLine);
                    is_initialized = true;
                }
                
                // 准备好要发送的帧
                ConnectionStatusInquiryFrame frames_inq = new ConnectionStatusInquiryFrame();

                // 做好帧的赋值工作（这个帧的值都是确定的）
                // 字符串保存即将发出去的帧内容，然后显示
                string outStr = frames_inq.FrameBytesInString();        
                TheTextBox.AppendText("Sending inquiry frame......Content: " + outStr + Environment.NewLine + Environment.NewLine);

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

        // 当下层帧来的时候在这儿显示一下原始内容
        private void ComFrameUp(object sender, FrameReceivedArgs e)
        {
            // 如果不用下面这一行，我想要的对象还被子线程所拥有，无法用来改变UI层的元素
            // 按这一行这样操作一下就可以了。虽然我也不清楚为什么，C#这边还需要学习。
            // 参考了https://blog.csdn.net/u014117094/article/details/47776165
            Dispatcher.Invoke(new Action(() => {
                TheTextBox.AppendText("Frame received:  " + e.IncomingFrame + Environment.NewLine + Environment.NewLine);
            }) );

            // 显示一次之后就取消委托，下次要再显示下次再添加委托。不然每次“初始化”都增加一个委托，每次都多显示一行同样的内容。
            serial.rs232.rsr.NewFrame -= ComFrameUp;
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

    }
}

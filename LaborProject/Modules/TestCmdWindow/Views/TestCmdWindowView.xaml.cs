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

namespace LaborProject.Modules.TestCmdWindow.Views
{
    /// <summary>
    /// TestCmdWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class TestCmdWindowView : UserControl
    {
        //public static Rs232 rs232;
        //private static bool rs232_opened = false;
        //private static List<int> rs232_list = new List<int>();

        public TestCmdWindowView()
        {
            InitializeComponent();
        }

        private void InitializeButton_Click(object sender, RoutedEventArgs e)
        {
            //按钮被按下后进行初始化，发送对应的帧
            TheTextBox.Text = "";
            TheTextBox.AppendText("Initialize process activated." + Environment.NewLine 
                + "Initializing..." + Environment.NewLine
                + " ");
            //准备好要发送的包
            Frames frames_inq = new Frames();
            //做好包的赋值工作
            //调用发送方法将其发给串口
            frames_inq.send();

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TheTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

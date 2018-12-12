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

        private void InitializeButton_Click(object sender, RoutedEventArgs e)
        {
            //按钮被按下后进行初始化，发送对应的帧
            TheTextBox.Text = "";
            TheTextBox.AppendText("Initialize process activated." + Environment.NewLine 
                + "Initializing..." + Environment.NewLine
                + " ");
        }

        private void TheTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}

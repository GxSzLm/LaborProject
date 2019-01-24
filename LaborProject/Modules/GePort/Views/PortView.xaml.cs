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

using LaborProject.Modules.GePort.ViewModels;
using LaborProject.Models;

namespace LaborProject.Modules.GePort.Views
{
    /// <summary>
    /// PortView.xaml 的交互逻辑
    /// </summary>
    public partial class PortView : UserControl
    {
        public PortView()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            //PortInstance.ThePortViewModels[0].Content_PortIp = "1.1.1.1";
            PortInstance.Ports[0].IpAddr = new PortIpAddress("1.1.1.1");
        }
    }
}

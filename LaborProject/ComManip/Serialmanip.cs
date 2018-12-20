using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaborProject;
using System.Windows;
using System.IO.Ports;


namespace LaborProject
{
    public class Serialmanip
    {
        public Rs232 rs232 = new Rs232();

        private static bool rs232_opened = false;
        private static bool rj45_opened = false;
        private static bool pcie_opened = false;
        private static List<int> rs232_list = new List<int>();
        private static List<int> rj45_list = new List<int>();
        private static List<int> pcie_list = new List<int>();

        public void Com_open()
        {
            // 想打开端口似乎要先获取端口的名字
            if (rs232.ComPortIsOpen == false)
            {
                rs232.Ports_Reflash();
                try
                {
                    rs232.ComPort.PortName = "COM3"; // 暂时先硬编码在这儿 仔细一想后期似乎也不需要更改，看吧
                    int test = Convert.ToInt32(115200);
                    rs232.ComPort.BaudRate = test;
                    rs232.ComPort.Parity = (Parity)Convert.ToInt32(0);
                    rs232.ComPort.DataBits = Convert.ToInt32(8);
                    rs232.ComPort.StopBits = (StopBits)Convert.ToDouble(1);
                    rs232.ComPort.Open();
                    // 在这里可以输出一下是不是打开串口了 不过没报错也可以视为就是顺利打开了
                    rs232.receive();

                }
                catch
                {
                    MessageBox.Show("无法打开次串口，请检测此串口是否有效或被其他设备占用");
                    rs232.Ports_Reflash();
                    return;
                }
                //Com_close.IsEnabled = true;
                //Com_open.IsEnabled = false;
                //Com_select.IsEnabled = false;
                //Band_rate.IsEnabled = false;
                //Check_bits.IsEnabled = false;
                //Date_bits.IsEnabled = false;
                //Stop_bits.IsEnabled = false;
                rs232.ComPortIsOpen = true;
                rs232_opened = true;
                rs232_list.Add(1);
                if (rs232.RecStaus == false)
                {
                    rs232.RecStaus = true;
                }

            }


        }

        public void Com_close()
        {
            try//尝试关闭串口
            {
                rs232.ComPort.DiscardOutBuffer();//清发送缓存
                rs232.ComPort.DiscardInBuffer();//清接收缓存              
                rs232.ComPort.Close();//关闭串口
            }

            catch//如果在未关闭串口前，串口就已丢失，这时关闭串口会出现异常
            {
                if (rs232.ComPort.IsOpen == false)//判断当前串口状态，如果ComPort.IsOpen==false，说明串口已丢失
                {
                    //Com_open.IsEnabled = true;
                    //Com_close.IsEnabled = false;
                    //Com_select.IsEnabled = true;
                    MessageBox.Show("串口已丢失");
                    rs232.Ports_Reflash();

                }
                else//未知原因，无法关闭串口
                {
                    MessageBox.Show("无法关闭串口，原因未知！");
                    return;//无法关闭串口，提示后直接返回
                }
            }
            //Com_open.IsEnabled = true;
            //Com_close.IsEnabled = false;
            //Com_select.IsEnabled = true;
            //Band_rate.IsEnabled = true;
            //Check_bits.IsEnabled = true;
            //Date_bits.IsEnabled = true;
            //Stop_bits.IsEnabled = true;

            rs232_opened = false;
            rs232_list.RemoveAt(0);
            rs232.ComPortIsOpen = false;
            if (rs232.RecStaus == true)
            {
                rs232.RecStaus = false;
            }
        }
    }
    
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Ports;
using System.Windows;
using System.Windows.Threading;
using System.Threading;
using System.Collections;

namespace LaborProject
{
    class Rs232
    {                                                                                                                       
        public SerialPort ComPort;
        public string[] Ports;
        public bool RecStaus = true;
        public bool ComPortIsOpen = false;//COM口开启状态字，在打开/关闭串口中使用，这里没有使用自带的ComPort.IsOpen，因为在串口突然丢失的时候，ComPort.IsOpen会自动false，逻辑混乱
        public bool WaitClose = false;//invoke里判断是否正在关闭串口是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke ,解决关闭串口时，程序假死，具体参见http://news.ccidnet.com/art/32859/20100524/2067861_4.html 仅在单线程收发使用，但是在公共代码区有相关设置，所以未用#define隔离
        public IList<customer> ComList;
        public IList<customer> RateList;
        public IList<customer> ComParity;
        public IList<customer> DataBits;
        public IList<customer> StopBits;
        private static bool Sending = false;
        private static Thread _ComSend;//发送数据线程
        private static byte[] Send_data;
        public Queue recQueue = new Queue();//接收数据过程中，接收数据线程与数据处理线程直接传递的队列，先进先出

        public Rs232()
        {
            ComPort = new SerialPort();
            ComList = new List<customer>();
            RateList = new List<customer>();//可用波特率集合
            RateList.Add(new customer() { BaudRate = "1200" });
            RateList.Add(new customer() { BaudRate = "2400" });
            RateList.Add(new customer() { BaudRate = "4800" });
            RateList.Add(new customer() { BaudRate = "9600" });
            RateList.Add(new customer() { BaudRate = "14400" });
            RateList.Add(new customer() { BaudRate = "19200" });
            RateList.Add(new customer() { BaudRate = "28800" });
            RateList.Add(new customer() { BaudRate = "38400" });
            RateList.Add(new customer() { BaudRate = "57600" });
            RateList.Add(new customer() { BaudRate = "115200" });

            ComParity = new List<customer>();//可用校验位集合
            ComParity.Add(new customer() { Parity = "None", ParityValue = "0" });
            ComParity.Add(new customer() { Parity = "Odd", ParityValue = "1" });
            ComParity.Add(new customer() { Parity = "Even", ParityValue = "2" });
            ComParity.Add(new customer() { Parity = "Mark", ParityValue = "3" });
            ComParity.Add(new customer() { Parity = "Space", ParityValue = "4" });

            DataBits = new List<customer>();//数据位集合
            DataBits.Add(new customer() { Dbits = "8" });
            DataBits.Add(new customer() { Dbits = "7" });
            DataBits.Add(new customer() { Dbits = "6" });

            StopBits = new List<customer>();//停止位集合
            StopBits.Add(new customer() { Sbits = "1" });
            StopBits.Add(new customer() { Sbits = "1.5" });
            StopBits.Add(new customer() { Sbits = "2" });


            Ports_Reflash();

        }
        public void Ports_Reflash()
        {
            Ports = SerialPort.GetPortNames();
            if (Ports.Length > 0)//ports.Length > 0说明有串口可用
            {
                for (int i = 0; i < Ports.Length; i++)
                {
                    ComList.Add(new customer() { com = Ports[i] });//下拉控件里添加可用串口
                }

            }
            else
            {
                MessageBox.Show("未找到串口");
            }
        }

        public bool send(byte[] data)
        {
            if (Sending == true)
                return false;
            else
            {
                _ComSend = new Thread(new ParameterizedThreadStart(ComSend));
                Send_data = data;
                _ComSend.Start(data);
                return true;
            }

        }
        //void UIAction(Action action)//在主线程外激活线程方法
        //{
        //    System.Threading.SynchronizationContext.SetSynchronizationContext(new System.Windows.Threading.DispatcherSynchronizationContext(this.Dispatcher));
        //    System.Threading.SynchronizationContext.Current.Post(_ => action(), null);
        //}
        private void ComSend(object obj)//发送数据 独立线程方法 发送数据时UI可以响应
        {

            lock (this)//由于send()中的if (Sending == true) return，所以这里不会产生阻塞，如果没有那句，多次启动该线程，会在此处排队
            {
                Sending = true;//正在发生状态字
                byte[] sendBuffer = null;//发送数据缓冲区
                sendBuffer = Send_data;//复制发送数据，以免发送过程中数据被手动改变                            
                try//尝试发送数据
                {//如果发送字节数大于1000，则每1000字节发送一次
                    int sendTimes = (sendBuffer.Length / 1000);//发送次数
                    for (int i = 0; i < sendTimes; i++)//每次发生1000Bytes
                    {
                        ComPort.Write(sendBuffer, i * 1000, 1000);//发送sendBuffer中从第i * 1000字节开始的1000Bytes
                    }
                    if (sendBuffer.Length % 1000 != 0)//发送字节小于1000Bytes或上面发送剩余的数据
                    {
                        ComPort.Write(sendBuffer, sendTimes * 1000, sendBuffer.Length % 1000);
                    }

                }
                catch//如果无法发送，产生异常
                {

                    MessageBox.Show("无法发送数据，原因未知！");
                }
                //sendScrol.ScrollToBottom();//发送数据区滚动到底部
                Sending = false;//关闭正在发送状态
                _ComSend.Abort();//终止本线程
            }

        }

        public void receive()
        {
            ComPort.DataReceived += new SerialDataReceivedEventHandler(ComReceive);//串口接收中断
        }
        private void ComReceive(object sender, SerialDataReceivedEventArgs e)//接收数据 中断只标志有数据需要读取，读取操作在中断外进行
        {
            if (WaitClose) return;//如果正在关闭串口，则直接返回
            Thread.Sleep(10);//发送和接收均为文本时，接收中为加入判断是否为文字的算法，发送你（C4E3），接收可能识别为C4,E3，可用在这里加延时解决
            if (RecStaus)//如果已经开启接收
            {
                byte[] recBuffer;//接收缓冲区
                try
                {
                    recBuffer = new byte[ComPort.BytesToRead];//接收数据缓存大小
                    ComPort.Read(recBuffer, 0, recBuffer.Length);//读取数据
                    recQueue.Enqueue(recBuffer);//读取数据入列Enqueue（全局）
                }
                catch
                {

                    MessageBox.Show("无法接收数据，原因未知！");

                }

            }
            else//暂停接收
            {
                ComPort.DiscardInBuffer();//清接收缓存
            }
        }
    }
    public class customer
    {
        public string com { get; set; }
        public string com1 { get; set; }
        public string BaudRate { get; set; }
        public string Parity { get; set; }
        public string ParityValue { get; set; }//校验位对应值
        public string Dbits { get; set; }
        public string Sbits { get; set; }

    }
}


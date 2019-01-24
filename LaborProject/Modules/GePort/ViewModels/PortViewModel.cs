using Gemini.Framework;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaborProject.Models;

namespace LaborProject.Modules.GePort.ViewModels
{

    public class PortViewModel : Document
    {
        // 本View Model所对应的Model的引用，即对应的Port对象
        private TesterPort myPort;

        // 分别对应端口数据中的ip地址和mac地址
        private string _content_PortIp;
        public string Content_PortIp
        {
            get
            {
                return _content_PortIp;
            }
            set
            {
                _content_PortIp = value;
                NotifyOfPropertyChange(() => Content_PortIp);
            }
        }

        private string _content_PortMac;
        public string Content_PortMac
        {
            get
            {
                return _content_PortMac;
            }
            set
            {
                _content_PortMac = value;
                NotifyOfPropertyChange(() => Content_PortMac);
            }
        }

        // 显示的端口号
        private int _content_PortId;
        public int Content_PortId
        {
            get { return _content_PortId; }
            private set
            {
                _content_PortId = value;
                NotifyOfPropertyChange(() => Content_PortId);
            }
        }


        // constructor通过id来标识View Model与Model的对应关系
        public PortViewModel(int id)
        {
            Content_PortId = id;
            DisplayName = "端口" + id;

            myPort = PortInstance.Ports[id];
            myPort.VMPort = this;
            // 第一次也用ReExtract来获取数据
            ReExract(id);

            myPort.ParameterChanged += OnParaChanged;
        }

        // 重新从Model中抽取数据。（配合相关属性的get方法使用？）
        public void ReExract(int id)
        {
            if(Content_PortIp == "1.1.1.1")
                PortInstance.Ports[id].IpAddr.AddressInString = "1.2.3.4";
            Content_PortIp = PortInstance.Ports[id].IpAddr.AddressInString;
            Content_PortMac = PortInstance.Ports[id].MacAddr.AddressInString;
        }

        private void OnParaChanged(object sender, ParaChangeEventArgs e)
        {
            ReExract(Content_PortId);
        }

        
    }

    public static class PortVMInstance
    {
        public static PortViewModel[] ThePortViewModels = new PortViewModel[4] { new PortViewModel(0), new PortViewModel(1), new PortViewModel(2), new PortViewModel(3) };
    }

}

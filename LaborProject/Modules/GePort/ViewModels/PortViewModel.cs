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
        public string Content_PortIp { get; set; }
        public string Content_PortMac { get; set; }
        public int Content_PortId { get; private set; }

        // constructor通过id来标识View Model与Model的对应关系
        public PortViewModel(int id)
        {
            Content_PortId = id;
            DisplayName = "端口" + id;

            // 第一次也用ReExtract来获取数据
            ReExract(id);
        }

        // 重新从Model中抽取数据。（配合相关属性的get方法使用？）
        private bool ReExract(int id)
        {
            myPort = PortInstance.Ports[id];
            Content_PortIp = PortInstance.Ports[id].IpAddr.AddressInString;
            Content_PortMac = PortInstance.Ports[id].MacAddr.AddressInString;

            return true;
        }
    }

    public static class PortVMInstance
    {
        public static PortViewModel[] ThePortViewModels = new PortViewModel[4] { new PortViewModel(0), new PortViewModel(1), new PortViewModel(2), new PortViewModel(3) };
    }

}

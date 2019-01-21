using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LaborProject.Models
{
    public class TesterPort
    {
        public int PortId { get; set; }

        public bool isAvailable { get; set; }
        public bool isConnected { get; set; }

        public PortMacAddress MacAddr { get; set; }
        public PortIpAddress IpAddr { get; set; }

        public TesterPort(int id)
        {
            PortId = id;

            isAvailable = false;
            isConnected = false;

            MacAddr = new PortMacAddress("00-00-00-00-00-00");
            IpAddr = new PortIpAddress("0.0.0.0");
        }
    }
}

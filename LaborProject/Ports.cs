using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LaborProject
{
    public class Ports
    {
        public bool isAvailable;
        public bool isConnected;

        public PortMacAddress MacAddr;
        public PortIpAddress IpAddr;

        public Ports()
        {
            isAvailable = false;
            isConnected = false;

            MacAddr = new PortMacAddress("00-00-00-00-00-00");
            IpAddr = new PortIpAddress("0.0.0.0");
        }
    }
}

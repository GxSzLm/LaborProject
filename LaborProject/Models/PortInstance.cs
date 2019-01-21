using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborProject.Models
{
    public static class PortInstance
    {
        public static TesterPort[] Ports = new TesterPort[4] { new TesterPort(0), new TesterPort(1), new TesterPort(2), new TesterPort(3) };
    }
}

using LaborProject.Modules.GePort.ViewModels;
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

        private bool _isAvailable;
        public bool IsAvailable {
            get
            {
                return _isAvailable;
            }
            set
            {
                _isAvailable = value;
            }
        }

        private bool _isConnected;
        public bool IsConnected
        {
            get
            {
                return IsConnected;
            }
            set
            {
                _isConnected = value;
            }
        }

        private PortMacAddress _macAddr;
        public PortMacAddress MacAddr
        {
            get
            {
                return _macAddr;
            }
            set
            {
                _macAddr = value;
                RaiseParameterChanged();
            }
        }

        private PortIpAddress _ipAddr;
        public PortIpAddress IpAddr
        {
            get
            {
                return _ipAddr;
            }
            set
            {
                _ipAddr = value;
                RaiseParameterChanged();
            }
        }

        public PortViewModel VMPort;

        public TesterPort(int id)
        {
            PortId = id;

            IsAvailable = false;
            IsConnected = false;

            MacAddr = new PortMacAddress("00-00-00-00-00-00");
            IpAddr = new PortIpAddress("0.0.0.0");
        }

        // 声明相关参数类型的事件
        public event EventHandler<ParaChangeEventArgs> ParameterChanged;

        // 触发参数变化这一事件
        protected virtual void RaiseParameterChanged()
        {
            EventHandler<ParaChangeEventArgs> parameterChanged = ParameterChanged;
            if(parameterChanged != null)
            {
                parameterChanged(this, new ParaChangeEventArgs());
            }
        }
    }

    // 定义参数变化相关事件参数
    public class ParaChangeEventArgs : EventArgs
    {
        public ParaChangeEventArgs()
        {

        }
    }
}

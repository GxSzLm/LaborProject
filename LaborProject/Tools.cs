using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LaborProject
{
    // 存放工具方法的一个临时处所
    class Tools
    {
        // 没地方放先放在这儿 计划稍后写一个工具类来存放这样的方法吧
        // 应该是还需要若干string2ipAddr，string2macAddr这样的函数
        public static byte[] StructToBytes(object structObj)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(structObj);
            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return bytes;
        }
    }


    public class PortIpAddress
    {
        public byte[] _addressInBytes;
        public byte[] AddressInBytes
        {
            get
            {
                return _addressInBytes;
            }
            set
            {
                _addressInBytes = value;
                if (_addressInString != ConvertToString(AddressInBytes))
                {
                    _addressInString = ConvertToString(AddressInBytes);
                }
            }
        }
        public string _addressInString;
        public string AddressInString
        {
            get
            {
                return _addressInString;
            }
            set
            {
                _addressInString = value;
                if (_addressInBytes != ParseIp(AddressInString))
                {
                    _addressInBytes = ParseIp(AddressInString);
                }
            }
        }
        //public uint AddressInUint;

        // 构造函数
        public PortIpAddress(byte[] ip)
        {
            AddressInBytes = new byte[]
            {
                ip[0], ip[1], ip[2], ip[3]
            };
        }
        public PortIpAddress(string ip)
        {
            AddressInString = ip;
        }

        // 转换方法
        public string ConvertToString(byte[] ip)
        {
            return ip[0] + "." + ip[1] + "." + ip[2] + "." + ip[3];
        }
        //public string ToString(uint ip)
        //{
        //    string sOut;
        //    return;
        //}

        public byte[] ParseIp(string ip)
        {
            string tmp = "";
            byte[] addr = new byte[4];

            // 手动拆解字符串，转换为byte数组
            for (int i = 0, j = 0; i < addr.Length; ++i)
            {
                if(ip[i] != '.')
                {
                    tmp = tmp + ip[i];
                }
                else
                {
                    addr[j] = byte.Parse(tmp);
                    tmp = "";
                    ++j;
                }
            }

            return addr;
        }

    }

    public class PortMacAddress
    {
        public byte[] _addressInBytes;
        public byte[] AddressInBytes
        {
            get
            {
                return _addressInBytes;
            }
            set
            {
                _addressInBytes = value;
                if (_addressInString != ConvertToString(AddressInBytes))
                {
                    _addressInString = ConvertToString(AddressInBytes);
                }
            }
        }

        public string _addressInString;
        public string AddressInString
        {
            get
            {
                return _addressInString;
            }
            set
            {
                _addressInString = value;
                if (_addressInBytes != ParseMac(AddressInString))
                {
                    _addressInBytes = ParseMac(AddressInString);
                }
            }
        }
        //public uint AddressInUint;

        // 构造函数
        public PortMacAddress(byte[] mac)
        {
            AddressInBytes = new byte[]
            {
                mac[0], mac[1], mac[2], mac[3], mac[4], mac[5]
            };
        }
        public PortMacAddress(string mac)
        {
            AddressInString = mac;
        }

        // 转换方法
        public string ConvertToString(byte[] mac)
        {
            return mac[0].ToString("X2") + "-" + mac[1].ToString("X2") + "-" + mac[2].ToString("X2") + "-" + mac[3].ToString("X2") + "-" + mac[4].ToString("X2") + "-" + mac[5].ToString("X2");
        }
        //public string ToString(uint ip)
        //{
        //    string sOut;
        //    return;
        //}

        public byte[] ParseMac(string ip)
        {
            string tmp = "";
            byte[] addr = new byte[6];

            for (int i = 0, j = 0; i < addr.Length; ++i)
            {
                if (ip[i] != '-')
                {
                    tmp = tmp + ip[i];
                }
                else
                {
                    addr[j] = byte.Parse(tmp);
                    tmp = "";
                    ++j;
                }
            }

            return addr;
        }

    }
}

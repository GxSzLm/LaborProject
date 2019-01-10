using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LaborProject.ComFrames
{
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

        // 自定义几个键值对
        //public struct FMap
        //{
        //    public string key_en;
        //    public string ket_zh;
        //    public int value;

        //    public FMap(string a, string b, int c)
        //    {
        //        key_en = a;
        //        ket_zh = b;
        //        value = c;
        //    }
        //}

        public struct FMap
        {
            public string key_en;
            public string ket_zh;
            public string value;

            public FMap(string a, string b, string c)
            {
                key_en = a;
                ket_zh = b;
                value = c;
            }

        }
    }
}

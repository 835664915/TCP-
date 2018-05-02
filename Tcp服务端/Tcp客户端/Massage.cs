using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcp客户端
{
    class Massage
    {
        /// <summary>
        /// 用来把数据转变成字节数组.这就是将数据前面加上数据长杜
        /// </summary>
        /// <param name="date"></param>
        public static byte[] GetBytes(string date)
        {
            //得到字节数组
            byte[] dataBytes = Encoding.UTF8.GetBytes(date);
            //得到字节数组的长度
            int dataLeaght = dataBytes.Length;
            //将字节数组的长杜转换为4个字节的数组
            byte[] leanghtBytes = BitConverter.GetBytes(dataLeaght);
            //将字节数组和字节数组的长杜加在一起
            byte[] newBytes = leanghtBytes.Concat(dataBytes).ToArray();

            return newBytes;



        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 转换成字节数组
{
    class Program
    {
        static void Main(string[] args)
        {
            //数字和英文都是一个字节，汉字都是3个字节
            // byte[] data=     Encoding.UTF8.GetBytes("10000000000");

            //BitConverter.GetBytes全是值类型的
            int count = 104646;
            byte[] data = BitConverter.GetBytes(count);


            foreach (byte b in data)
            {

                Console.Write(b + ";");

            }
            Console.ReadKey();

        }
    }
}

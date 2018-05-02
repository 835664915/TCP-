using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Tcp客户端
{
    class Program
    {
        static void Main(string[] args)
        {

            Socket clickSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            clickSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.10.122"), 88));


           

            byte[] dataBuff = new byte[1024];
            //count接收到 的数据
            int count = clickSocket.Receive(dataBuff);
            //把接受到的字节数据，重0的位置开始转换到count接收到的位置
            string msgReceive = Encoding.UTF8.GetString(dataBuff, 0, count);
            Console.Write(msgReceive);



            //while (true)
            //{
            //    string s = Console.ReadLine();
            //    if (s=="c")
            //    {

            //        clickSocket.Close();
            //        return;
            //    }


            //    byte[] data = Encoding.UTF8.GetBytes(s);
            //    clickSocket.Send(data);
            //}

            //-----粘包------------
            for (int i = 0; i < 100; i++)
            {
               // byte[] data = Encoding.UTF8.GetBytes(i.ToString());
                clickSocket.Send(Massage.GetBytes(i.ToString()+"长度"));
            }

          
            Console.ReadKey();
            clickSocket.Close();


        }

       
    }
}

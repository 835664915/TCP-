using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
namespace Tcp服务端
{
    class Program
    {
        static void Main(string[] args)
        {

            SatrtServerSync();
            Console.ReadKey();
        }

        /// <summary>
        /// 同步接受消息
        /// </summary>
        void StartServerAsync()
        {

            //AddressFamily =ip地址,//SocketType.Stream流比较稳定tcp，SocketType.Dgram 报容易丢失udp//ProtocolType.Tcp协议
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //192.168.10.22；


            //ipAddress xx,xx,xx,xxip地址,ipEndPoint xxx，xx，xx，信息，：port 

            //IPAddress ipAddress = new IPAddress(new byte[] {192,168,1,5 });
            IPAddress ipAddress = IPAddress.Parse("192.168.10.122");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 88);

            //绑定ip和端口号
            serverSocket.Bind(ipEndPoint);
            //监听客户端得链接，参数是处理链接得队列10个
            serverSocket.Listen(0);

            //serverSocket.Accept()接受客户端的链接,他会暂停，直到有一个客户端链接进来
            Socket clientSocket = serverSocket.Accept();
           
            
            
            
            //向客户端发送一条消息
            string msg = "Hello Click?你好";
            //网络传输只能传字节数组
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);
           
            
            //接受客户端一条消息buff缓存
            byte[] dataBuff = new byte[1024];
            //count接收到 的数据
            int count = clientSocket.Receive(dataBuff);
            //把接受到的字节数据，重0的位置开始转换到count接收到的位置
            string msgReceive = System.Text.Encoding.UTF8.GetString(dataBuff, 0, count);


            Console.WriteLine(msgReceive);
            Console.ReadKey();
            //关闭客户端的链接，客户端关闭要看自己，
            clientSocket.Close();
            serverSocket.Close();



        }
        /// <summary>
        ///异步
        /// </summary>
    static    void SatrtServerSync()
        {

            //AddressFamily =ip地址,//SocketType.Stream流比较稳定tcp，SocketType.Dgram 报容易丢失udp//ProtocolType.Tcp协议
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //192.168.10.22；


            //ipAddress xx,xx,xx,xxip地址,ipEndPoint xxx，xx，xx，信息，：port 
            //IPAddress ipAddress = new IPAddress(new byte[] {192,168,1,5 });
            IPAddress ipAddress = IPAddress.Parse("192.168.1.102");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 88);
            //绑定ip和端口号
            serverSocket.Bind(ipEndPoint);
            //监听客户端得链接，参数是处理链接得队列10个
            serverSocket.Listen(0);
            //serverSocket.Accept()接受客户端的链接,他会暂停，直到有一个客户端链接进来
            Socket clientSocket = serverSocket.Accept();
           
            
            
            //向客户端发送一条消息
            string msg = "Hello Click?你好";
            //网络传输只能传字节数组
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);




            #region  接受客户端一条消息buff缓存
            //byte[] dataBuff = new byte[1024];
            ////count接收到 的数据
            //int count = clientSocket.Receive(dataBuff);
            ////把接受到的字节数据，重0的位置开始转换到count接收到的位置
            //string msgReceive = System.Text.Encoding.UTF8.GetString(dataBuff, 0, count);
            //     Console.WriteLine(msgReceive);
            //Console.ReadKey();
            ////关闭客户端的链接，客户端关闭要看自己，
            //clientSocket.Close();
            //serverSocket.Close(); 
            #endregion
            dataBuffer = new byte[1024];


            //开始异步接受数据dataBuffer,从零开始，一直到1024，SocketFlags.None没用到，接受到消息有一个回掉函数ReciveCallBack，回掉函数得参数就是最后clientSocket这个object类型
            clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None,ReciveCallBack, clientSocket);






        }

        static byte[] dataBuffer;


    static    void ReciveCallBack(IAsyncResult ar)
        {

            Socket clientSocket = ar.AsyncState as Socket;
            //接收了多少条数据
          int count=  clientSocket.EndReceive(ar);

          string mgs=  Encoding.UTF8.GetString(dataBuffer,0,count);

            Console.WriteLine("从客户端接收数据：" + mgs);


            clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, ReciveCallBack, clientSocket);

        }











    }
}

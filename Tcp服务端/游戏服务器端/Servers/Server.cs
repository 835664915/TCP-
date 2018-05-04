using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using GameServer.Controller;
using Common;
namespace GameServer.Servers
{


    /// <summary>
    /// 启动tcp服务端开启监听
    /// </summary>
    class Server
    {

        private IPEndPoint ipEndPoint;

        private Socket serverSocker;
        /// <summary>
        /// 在服务器里面管理所有的客户端
        /// </summary>
        private List<Client> clientList = new List<Client>();

        private ControllerManager controllerManager;

        public Server()
        {

           

        }
        /// <summary>
        /// 指定ip和端口号
        /// </summary>
        /// <param name="ipstr"></param>
        /// <param name="port"></param>
        public Server(string ipstr,int port)
        {

            controllerManager = new ControllerManager(this);
            SetIpAndPort(ipstr, port);


        }
        /// <summary>
        /// 设置ip和端口号
        /// </summary>
        public void SetIpAndPort(string ipstr, int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse(ipstr), port);

        }


        /// <summary>
        /// 启动监听
        /// </summary>
        public void Start()
        {
            //ProtocolType协议
             serverSocker = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            serverSocker.Bind(ipEndPoint);
            serverSocker.Listen(0);
            serverSocker.BeginAccept(AccepCallBack,null);



        }

        private void AccepCallBack(IAsyncResult ar)
        {

            Socket clientSocket = serverSocker.EndAccept(ar);

            Client client = new Client(clientSocket,this);
            client.Start();
            clientList.Add(client);


        }
        /// <summary>
        /// 移除客户端
        /// </summary>
        /// <param name="client"></param>
        public void RemoveClient(Client client)
        {
            //多个客户端访问clientList时候出现出现矛盾，锁定
            lock (clientList)
            {
                clientList.Remove(client);
            }
            



        }

        public void SendResponse(Client client, RequstCode requstCode,string data)
        {

            //给客户端响应



        }

    }
}

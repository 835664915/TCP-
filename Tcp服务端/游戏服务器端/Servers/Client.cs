using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Servers
{


    /// <summary>
    /// 跟客户端的通信问题
    /// </summary>
    class Client
    {
        private Socket clienSocket;

        private Server server;

        private Message msg = new Message();


        public Client()
        {

        }
        public Client(Socket clienSocket,Server server)
        {
           this.clienSocket = clienSocket;
            this.server = server;


        }

        public void Start()
        {
            clienSocket.BeginReceive(msg.Data,msg.StartIndex,msg.RemainSize,SocketFlags.None,ReciveCallback,null);


        }

        private void ReciveCallback(IAsyncResult ar)
        {

            try
            {
                int count = clienSocket.EndReceive(ar);
                if (count == 0)
                {
                    Close();
                }
                msg.ReadMessage(count);

                //------处理接受到的数据---------
                Start();


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               
                Close();
            }

        




        }
        /// <summary>
        /// 断开链接
        /// </summary>
        private void Close()
        {
            if (clienSocket!=null)
            {

                clienSocket.Close();
              

            }

            server.RemoveClient(this);

        }

    }
}

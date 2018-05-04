using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Reflection;
using GameServer.Servers;
namespace GameServer.Controller
{
    class ControllerManager
    {
        private Dictionary<RequstCode, BassController> controllorDict = new Dictionary<RequstCode, BassController>();

        private Server server;
        public  ControllerManager(Server server)
        {
            this.server = server;
            InitController();
        }

        void InitController()
        {

            DefaulController defaulController = new DefaulController();

            controllorDict.Add(defaulController.RequstCode,defaulController);


        }
        /// <summary>
        /// 处理请求的
        /// </summary>
        /// <param name="requstCode"></param>
        /// <param name=""></param>
        public void HandleRequst(RequstCode requstCode,ActionCode actionCode,string data,Client client)
        {

            BassController controller;
         bool isGet=   controllorDict.TryGetValue(requstCode, out controller);
            if (isGet==false)
            {
                Console.WriteLine("无法得到"+requstCode+"所对应的controller，无法处理请求");
                return;
            }
            string methodName = Enum.GetName(typeof(ActionCode), actionCode);
         MethodInfo mi=  controller.GetType().GetMethod(methodName);
            if (mi==null)
            {
                Console.WriteLine(controller.GetType() + "在controller没有对应的的处理方法" + methodName);
            }
            object[] parameters = new object[] { data, };
           object o= mi.Invoke(controller, parameters);
            if (o==null||string.IsNullOrEmpty(o as string))
            {
                return;
            }

            server.SendResponse(client, requstCode, o as string);

        }


    }
}

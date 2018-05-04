using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Servers;

namespace GameServer.Controller
{
    abstract class BassController
    {
         RequstCode _requstCode = RequstCode.None;
        
        public RequstCode RequstCode
        {
            get { return _requstCode; }

        }

        /// <summary>
        /// 处理消息
        /// </summary>
        public virtual string DefaultHandle(string data,Client client,Server server)
        {



            return null;
        }





    }
}

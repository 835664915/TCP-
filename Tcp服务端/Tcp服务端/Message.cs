using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcp服务端
{
    class Message
    {

        private byte[] _data = new byte[1024];
        public byte[] Data
        {
            get { return _data; }
        }
        /// <summary>
        /// 标志位，现在的数据存到什么位置了,
        /// </summary>
        private int _startIndex = 0;//我们存取了多少个字节数组里面的数据
        public int StartIndex
        {
            get
            {
                return _startIndex;
            }

        }

        /// <summary>
        /// 剩余的空间
        /// </summary>
        public int RemainSize
        {
            get { return Data.Length - StartIndex; }

        }
        /// <summary>
        /// 表示我门现在增加了多少数据
        /// </summary>
        public void AddCount(int count)
        {


            _startIndex += count;

        }

        /// <summary>
        /// 解析数据
        /// </summary>
        public  void ReadMessage()
        {

            while (true)
            {
                //首先数据长度大于4
                if (_startIndex <= 4)
                {
                    return;

                }
                //将byte数据转成值类型
                int count = BitConverter.ToInt32(_data, 0);
                if (_startIndex - 4 >= count)
                {
                    Console.WriteLine(_startIndex);
                    Console.WriteLine(count);
                    //从第四个开始都数据，因为0-3为数据长度
                    string s = Encoding.UTF8.GetString(_data, 4, count);
                    Console.WriteLine("解析出一条数据" + s);

                    //将剩余的数据移动到前面，更新数据,第一个参数是要复制的数组，第二个是说从什么位置开始复制，第三个是说复制到一个新的数组，第四个说从0开始，第5个是说数组的长度
                    Array.Copy(_data, count + 4, _data, 0, _startIndex - 4 - count); ;
                    _startIndex -= (count + 4);
                }
                else
                {
                    break;

                }

            }



        }


    }
}

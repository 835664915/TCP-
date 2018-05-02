using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MySQL数据库
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database,这是说mysql里面有多个数据库，要链接那个数据库,Data Source数据源说明数据库所在ip地址
            string connStr = "Database=test007;Data Source=127.0.0.1;port=3306;user id=root;password=root;";
            //跟数据库建立链接
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("select*from user",conn);
            //查询
           MySqlDataReader reader= cmd.ExecuteReader();
            if (reader.HasRows)//是否有数据
            {
       
                while (reader.Read())
                {
                    string username = reader.GetString("username");
                    string password = reader.GetString("password");
                    Console.WriteLine(username + ";" + password);
                }
        

            }
            reader.Close();
            conn.Close();
            Console.ReadKey();
        }
    }
}

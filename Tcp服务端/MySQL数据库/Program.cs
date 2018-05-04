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
            string connStr = "Database=test007;DataSource=127.0.0.1;port=3306;user=root;password=root;";
            //跟数据库建立链接
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();


            #region 查询
            //查询
            // MySqlCommand cmd = new MySqlCommand("select*from user", conn);
            //MySqlDataReader reader = cmd.ExecuteReader();
            //if (reader.HasRows)//是否有数据
            //{

            //    while (reader.Read())
            //    {
            //        string username = reader.GetString("username");
            //        string password = reader.GetString("password");
            //        Console.WriteLine(username + ";" + password);
            //    }


            //}
            //reader.Close(); 
            #endregion

            #region 插入
            //可以防止sql注入
            //string username = "1231"; string password = "lcker";

            //MySqlCommand cmd = new MySqlCommand("insert into user set username=@un,password=@pwd", conn);
            //cmd.Parameters.AddWithValue("un", username);
            //cmd.Parameters.AddWithValue("pwd", password);
            //cmd.ExecuteNonQuery(); 
            #endregion

            #region 删除
            //MySqlCommand cmd = new MySqlCommand("delete from user where id=@id", conn);
            //cmd.Parameters.AddWithValue("id", 1);
            //cmd.ExecuteNonQuery(); 
            #endregion

            #region 更新
            MySqlCommand cmd = new MySqlCommand("update user set password=@pwd where id=2", conn);
            cmd.Parameters.AddWithValue("pwd", "sddsdfsdfs");
            cmd.ExecuteNonQuery(); 
            #endregion



            conn.Close();
            Console.ReadKey();
        }
    }
}

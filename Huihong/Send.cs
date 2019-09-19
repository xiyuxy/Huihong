using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Data.Sql;

namespace Huihong
{
    class Send
    {
        [DllImport("TransferScale.dll", EntryPoint = "SendDataToScale", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
        public static extern int SendDataToScale(string ScaleNoList, int DataType, string DataFileName, int DataFormat);
    }
    class sql
    {
        void Writ()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection("database=hyl2015;server=127.0.0.1;uid=sa;");

            conn.Open();//打开数据连接

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select * from goods_inf where len(barcode)<=5;", conn);

            using (System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())

            {

                sb.AppendFormat("{0}-{1}", reader[0], reader[1]);//这里几列，写几列

            }

            conn.Dispose();//释放数据库连接资源(可以使用using字段，继承了IDispose接口类都可以使用using释放非托管资源）
            System.IO.File.WriteAllText("文件路径", sb.ToString());//写入文件
        }
    }
}

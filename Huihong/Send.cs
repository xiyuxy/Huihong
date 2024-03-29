﻿using System;
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
        public string Transmission()
        {
            string a;
            int s = Huihong.Send.SendDataToScale("1", 1207, "plu.txt", 0);
            if(System.IO.File.Exists("plu.txt") ||s!=0)
            {
                a = "传输失败";
                return a;
            }
            else
                a = "传输成功";
            return a;
        }
        public void Writ(string con,string scmd,string spath)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(con);

            conn.Open();//打开数据连接

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(scmd, conn);

            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int a = 0;
                if (reader[3].ToString().Trim() != "kg" && reader[3].ToString() != "公斤"&& reader[3].ToString() != "千克")
                    a = 1;
                sb.AppendFormat("{0},{0},,,{1},{2},,,,,,,,{3},,,,,,,,,,,,,,,,,,,,,,,,,,,\r\n", reader[0], reader[1], reader[2], a); //这里几列，写几列

            }

            //data.Text = reader.GetString(0);

            conn.Dispose();//释放数据库连接资源(可以使用using字段，继承了IDispose接口类都可以使用using释放非托管资源）
            System.IO.File.WriteAllText(spath, sb.ToString(),Encoding.GetEncoding("gb2312"));//写入文件
        }
    }
    
}

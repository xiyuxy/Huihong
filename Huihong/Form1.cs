using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huihong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
            int s = Huihong.Send.SendDataToScale("1", 1207, @"D:\MyCode\tld\tld\bin\x86\Debug\ppplu.txt", 0);
            if (s == 0)
            {
                state.Text = "传输成功";
            }
            else
                state.Text = "传输失败";
        }
        int a = 1;
        int LocationY = 126;
        
        private void Built_Click(object sender, EventArgs e)
        {
            
            LocationY += 30;
            for (int i = 0; i < 4; i++)
            {
                List<string> strname = new List<string> {"code","name","ipaddress","sending" };
                List<int> intx = new List<int> { code.Location.X,name.Location.X,ipaddress.Location.X,Sending.Location.X};
                List<Size> sizes = new List<Size> { code.Size,name.Size,ipaddress.Size,state.Size};
                TextBox textBox9 = new TextBox();
                textBox9.Name = strname[i]+ a;
                textBox9.Location = new Point(intx[i], LocationY);
                textBox9.Size = sizes[i];
                this.Controls.Add(textBox9);
                //textBox9.Text = "123456";
            }
            a += 1;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (LocationY > 126)
            {  List<Control> c = new List<Control>();
            foreach (Control ctr in this.Controls)
            {
                if (ctr.Location.Y == LocationY)
                {
                    c.Add(ctr);
                    
                }
            }
            foreach (Control cc in c)
            {
                this.Controls.Remove(cc);
                cc.Dispose();
            }
            
             LocationY -= 30;
            }
        }

        private void code_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection("database=hyl2015;server=127.0.0.1;uid=sa;");

            conn.Open();//打开数据连接

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select * from goods_inf where len(barcode)<=5;", conn);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
             sb.AppendFormat("{0},{1},{3},{3}\r\n", reader[0], reader[1],reader[2],reader[3]); //这里几列，写几列
            
            //data.Text = reader.GetString(0);
              
                conn.Dispose();//释放数据库连接资源(可以使用using字段，继承了IDispose接口类都可以使用using释放非托管资源）
                System.IO.File.WriteAllText("plu.txt", sb.ToString());//写入文件
            
        }
    }
}

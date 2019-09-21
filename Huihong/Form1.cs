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

            var ss = new Send();
            state.Text=ss.Transmission();
            
            
        }
        int a = 1;
        int LocationY = 126;
        
        private void Built_Click(object sender, EventArgs e)
        {
            List<Control> Ctrs = new List<Control> ();
            foreach (Control ctr in this.Controls)
            {
                if (ctr.Location.Y ==126)
                {
                    Ctrs.Add(ctr);

                }
            }
            


            LocationY += 30;
            for (int i = 0; i < Ctrs.Count; i++)
            {
               
                TextBox textBox = new TextBox
                {
                    Name = Ctrs[i].Name + a,
                    Location = new Point(Ctrs[i].Location.X, LocationY),
                    Size = Ctrs[i].Size
                };
                this.Controls.Add(textBox);
                //textBox9.Text = "123456";
            }
            a += 1;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
             if(LocationY>126)
            foreach (Control ctr in this.Controls.Cast<Control>().ToList())
            {
                if (ctr.Location.Y ==LocationY )
                {
                    
                    this.Controls.Remove(ctr);
                    ctr.Dispose();
                }
            }
            LocationY -= 30;
        }

        private void code_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var ss = new Send();
            ss.Writ("DataBase=jh2015;server=127.0.0.1;uid=sa","select * from goods where len(barcode)<6","plu.txt");
            
        }

        private void Save_Click(object sender, EventArgs e)
        {

            
            List<string> key = new List<string> { "IP","NAME","PORT","RESULT"};
            for (int i = 0; i < a; i++)
            {
                List<Control> Ctrs = new List<Control>();
                foreach (Control ctr in this.Controls)
                {
                    if (i != 0)
                    {
                        if (ctr.Name == (name.Name + i).ToString() || ctr.Name == (ipaddress.Name + i).ToString())
                        {
                            Ctrs.Add(ctr);

                        }
                    }
                   else if (ctr.Name == "name" || ctr.Name == "ipaddress")
                    {
                        Ctrs.Add(ctr);

                    }

                }
                for (int j= 2;j > 0;j--)
                config.Conwr((i+1).ToString(), key[j-1], Ctrs[j-1].Text, @"E:\program\Huihong\Huihong\bin\x86\Debug\ScaleAddress.ini");
            }
            
        }
    }
}

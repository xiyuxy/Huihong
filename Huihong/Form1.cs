﻿using System;
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
            //List<Control> Ctrs = new List<Control> { code,name,ipaddress,state};
            //foreach (Control ctr in this.Controls)
            //{
            //    if (ctr.Location.Y == LocationY)
            //    {
            //        Ctrs.Add(ctr);

            //    }
            //}
            //Ctrop Sctrop = new Ctrop();
            //Sctrop.Newctr(LocationY,Ctrs);


            LocationY += 30;
            for (int i = 0; i < 4; i++)
            {
                List<string> strname = new List<string> { "code", "name", "ipaddress", "state" };
                List<int> intx = new List<int> { code.Location.X, name.Location.X, ipaddress.Location.X, Sending.Location.X };
                List<Size> sizes = new List<Size> { code.Size, name.Size, ipaddress.Size, state.Size };
                TextBox textBox9 = new TextBox();
                textBox9.Name = strname[i] + a;
                textBox9.Location = new Point(intx[i], LocationY);
                textBox9.Size = sizes[i];
                this.Controls.Add(textBox9);
                //textBox9.Text = "123456";
            }
            a += 1;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            List<Control> Ctrs = new List<Control>();
            foreach (Control ctr in this.Controls)
            {
                if (ctr.Location.Y == LocationY)
                {
                    Ctrs.Add(ctr);

                }
            }
            Ctrop Dctrop = new Ctrop();
            Dctrop.Delctr(LocationY, Ctrs);
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

        }
    }
}

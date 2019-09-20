using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huihong
{
    class Ctrop
    {
        public void Newctr(int LocationY,List<Control> controls)
        {
            //CtrAmount = controls.Count;
            LocationY += 25;
            for (int i=0; i<controls.Count; i++)
            {
                TextBox textBox = new TextBox
                {
                    Location = new System.Drawing.Point(LocationY, controls[i].Location.X),
                    Size = controls[i].Size,
                    Name = controls[i].Name + i
                };
                Form1.Controls.Add(textBox);

            }
        }
        public void Delctr(int DelLocationY,List<Control> controls)
        {
            foreach (var Delctr in controls)
            {
                controls.Remove(Delctr);
                Delctr.Dispose();
            }
            DelLocationY -= 25;
        }
    }
}

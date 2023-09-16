using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public class OutputLamp : Gate
    {
        // width and height of the main part of the gate
        protected override int WIDTH => 52;
        protected override int HEIGHT => 50;


        public OutputLamp(int x, int y)
        {
            //Add the two input pins to the gate
            pins.Add(new Pin(this, true, 20));
            
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }

        protected bool on = false;

        public override void Draw(Graphics paper) //i think dont add this to gate class because every draw method will be different anyway, what do u think?
        {
            
            SolidBrush br1 = new SolidBrush(Color.Yellow);

            //Draw each of the pins
            foreach (Pin p in pins)
                p.Draw(paper);

            //Check if the gate has been selected
            if (selected)
            {
                on = !on;
            }
            if (on == true)
            {
                paper.DrawImage(Properties.Resources.OutputIcon, Left, Top);
                paper.FillRectangle(br1, Left + 3, Top + 6, 4, 4);
            }
            else
            {
                paper.DrawImage(Properties.Resources.InputIcon, Left, Top);
            }
        }
    }
}

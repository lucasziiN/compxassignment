using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public class InputSource : Gate
    {
        // width and height of the main part of the gate
        protected override int WIDTH => 52;
        protected override int HEIGHT => 50;


        public InputSource(int x, int y)
        {
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }

        protected bool highVoltage = false;

        public override void Draw(Graphics paper) //i think dont add this to gate class because every draw method will be different anyway, what do u think?
        {
            
            SolidBrush br1 = new SolidBrush(Color.Yellow);
            SolidBrush br2 = new SolidBrush(Color.Black);
            SolidBrush br3 = new SolidBrush(Color.Gray);
            //Draw each of the pins
            foreach (Pin p in pins)
                p.Draw(paper);

            //Check if the gate has been selected
            if (selected)
            {
                highVoltage = !highVoltage;
            }
            if (highVoltage == true)
            {
                paper.FillRectangle(br2, Left, Top, 30, 30);
                paper.FillRectangle(br1, Left + 10, Top + 10, 10, 10);

            }
            else
            {
                paper.FillRectangle(br2, Left, Top, 30, 30);
                paper.FillRectangle(br3, Left + 10, Top+ 10, 10, 10);
                
            }
        }
    }
}

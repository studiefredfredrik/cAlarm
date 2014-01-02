using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace cAlarm
{
    class ColorGenerator
    {
        public Color newRandomColor()
        {
            Random RandomClass = new Random();

            int rndRed = RandomClass.Next(0, 255);
            int rndGreen = RandomClass.Next(0, 255);
            int rndBlue = RandomClass.Next(0, 255);

            return Color.FromArgb(rndRed, rndGreen, rndBlue);
        }
    }
}

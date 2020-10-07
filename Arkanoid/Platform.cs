using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    public class Platform
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Bitmap texture { get; }
        public  Platform(int x,int y,Bitmap texture)
        {
            X = x;
            Y = y;
            this.texture = texture;
        }

    }
}

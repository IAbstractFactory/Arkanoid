using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    public class Platform : GameObject
    {

        public Platform(int x,int y,Bitmap texture) : base(x, y, texture)
        {
            Width = 300;
            Height = 30;
        }
        public void Follow(int x)
        {
            X = x;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    public class Block : GameObject
    {
        public Block(int x, int y, Bitmap texture) : base(x, y, texture)
        {
            Width = 150;
            Height = 150;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid
{
    public class Ball : GameObject
    {
        Form1 Form1;
        Platform Platform;
        public Block Block;

        private int x = 0;
        private int y = 0;
        int speed = 10;

        public bool IsFlying { get; private set; } = false;
        public Ball(int x, int y, Bitmap texture, Form1 form1, Platform platform) : base(x, y, texture)
        {
            Width = Height = 30;
            Form1 = form1;
            Platform = platform;
        }
        public void Waiting()
        {
            if (!IsFlying)
            {

                X = Platform.X;
                Y = 1000 - 30;
            }
        }
        public void Move()
        {
            if (IsFlying)
            {

                if (X >= Form1.Width || X <= 0 || (IsCrossed(Block) && Math.Abs(Block.X - X) > Math.Abs(Block.Y-Y)))
                {
                    x = -x;
                }
                if ((IsCrossed(Block) && Math.Abs(Block.X - X) < Math.Abs(Block.Y - Y) )|| Y <= 0 || (Y >= Platform.Y && X >= Platform.X - 150 && X <= Platform.X + 150))
                {
                    y = -y;
                }

                X -= speed * x;
                Y -= speed * y;
                if (Y > Form1.Height)
                {
                    IsFlying = false;
                }
            }
        }
        public void Fly()
        {
            if (!IsFlying)
            {
                IsFlying = true;
                Random random = new Random();
                x = 0; //random.Next(-5, 5);
                y = 4;// random.Next(1, 5);

            }
        }
    }
}

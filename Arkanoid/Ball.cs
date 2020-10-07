using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid
{
    public class Ball
    {
        Form1 Form1;
        Platform Platform;
        public int X { get; set; }
        public int Y { get; set; }
        private int x = 0;
        private int y = 0;
        int speed = 10;
        public Bitmap texture { get; }
        private bool IsFlying = false;
        public Ball(int x, int y, Bitmap texture, Form1 form1, Platform platform)
        {
            Form1 = form1;
            X = x;
            Y = y;
            this.texture = texture;
            Platform = platform;
        }
        public void Move()
        {
            if (!IsFlying)
            {
                X = Cursor.Position.X - 15;
            }
            else
            {
                if (X >= Form1.Width || X <= 0)
                {
                    x = -x;
                }
                if (Y <= 0 || (Y >= Platform.Y && X >= Cursor.Position.X - 150 && x <= Cursor.Position.X + 150))
                {
                    y = -y;
                }

                X -= speed * x;
                Y -= speed * y;
            }
        }
        public void Fly()
        {
            if (!IsFlying)
            {
                IsFlying = true;
                Random random = new Random();
                x = random.Next(-5, 5);
                y = random.Next(1, 5);

            }
        }
    }
}

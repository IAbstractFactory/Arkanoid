using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    public abstract class GameObject
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public Bitmap Texture { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public GameObject(int x, int y, Bitmap texture)
        {
            X = x;
            Y = y;
            Texture = texture;


        }

        protected bool IsCrossed(GameObject gameObject)
        {
            return gameObject.X >= X - 75 && gameObject.X <= X + 75 && gameObject.Y >= Y - 75 && gameObject.Y <= Y + 75;
        }
    }
}

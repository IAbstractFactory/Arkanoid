using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Form1 : Form
    {
        Platform platform;
        Ball ball;
        public Form1()
        {
            InitializeComponent();
            platform = new Platform(10, 1000 - 20, Resource1.platform);
            ball = new Ball(10, 1000 - 45, Resource1.ball,this,platform);

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            var g = e.Graphics;
            g.DrawImage(platform.texture, new Rectangle(Cursor.Position.X - 150, platform.Y, 300, 30));
            g.DrawImage(ball.texture, new Rectangle(ball.X, ball.Y, 30, 30));

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ball.Move();
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ball.Fly();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Move();
            Refresh();
        }
    }
}

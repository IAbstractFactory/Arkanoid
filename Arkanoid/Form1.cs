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
        Block block;
        int k = 0;
        public Form1()
        {
            InitializeComponent();
            block = new Block(300, 150, Resource1.Wall);
            platform = new Platform(10, 1000 - 20, Resource1.platform);
            ball = new Ball(0, 1000 - 30, Resource1.ball, this, platform);
            ball.Block = block;



            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            var g = e.Graphics;
            g.DrawImage(platform.Texture, new Rectangle(platform.X - platform.Width / 2, platform.Y, platform.Width, platform.Height));
            g.DrawImage(ball.Texture, new Rectangle(ball.X - ball.Width / 2, ball.Y - ball.Height / 2, ball.Width, ball.Height));
            g.DrawImage(block.Texture, new Rectangle(block.X - block.Width / 2, block.Y - block.Height / 2, block.Width, block.Height));

            g.DrawLine(new Pen(Color.Red, 5), Cursor.Position.X - 150, Cursor.Position.Y, Cursor.Position.X - 150, Cursor.Position.Y - 30);
            g.DrawLine(new Pen(Color.Red, 5), Cursor.Position.X + 150, Cursor.Position.Y, Cursor.Position.X + 150, Cursor.Position.Y - 30);
            g.DrawEllipse(new Pen(Color.Red, 1), ball.X, ball.Y, 1, 1);
            g.DrawEllipse(new Pen(Color.Blue, 10), block.X, block.Y, 1, 1);
            g.DrawEllipse(new Pen(Color.Green, 2), Cursor.Position.X - 5, Cursor.Position.Y - 30, 10, 10);
            g.DrawEllipse(new Pen(Color.Red, 10), platform.X, platform.Y, 1, 1);



            g.DrawLine(new Pen(Color.Green, 2), block.X - 1000, block.Y + block.Height/2, block.X +1000, block.Y+ block.Height / 2);
            g.DrawLine(new Pen(Color.Green, 2), block.X - 1000, block.Y - block.Height/2, block.X +1000, block.Y- block.Height / 2);
            g.DrawLine(new Pen(Color.Green, 2), block.X-block.Width/2, 0, block.X - block.Width / 2, 1000);
            g.DrawLine(new Pen(Color.Green, 2), block.X+block.Width/2, 0, block.X + block.Width / 2, 1000);

        }

        async private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            await Task.Run(() =>
            {

                platform.Follow(Cursor.Position.X);


            });

            ball.Waiting();

        }



        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = k.ToString();
            ball.Move();
            Refresh();
            k++;

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ball.Fly();
        }
    }
}

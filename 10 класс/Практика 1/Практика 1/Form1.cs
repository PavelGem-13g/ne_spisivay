using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Практика_1
{
    public partial class Form1 : Form
    {
        Point A;
        Point B;
        Point C;

        int delta;

        SoundPlayer soundPlayer;
        public Form1()
        {
            InitializeComponent();
            A = new Point(containers.Panel2.Width / 4, containers.Panel2.Height / 5 * 4);
            B = new Point(containers.Panel2.Width / 4 * 3, containers.Panel2.Height / 5 * 4);
            C = new Point(containers.Panel2.Width / 2, containers.Panel2.Height / 5);
            Lable_Update();
            soundPlayer  = new SoundPlayer();
            soundPlayer.Stream = Properties.Resources.s;
            delta = 5;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Point[] points = new Point[] { A, B, C };
            e.Graphics.FillPolygon(new SolidBrush(Color.Green), points);
            ;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Increase_triangle();
            soundPlayer.Play();
        }

        void Lable_Update() 
        {
            lable_A.Location = new Point(A.X,A.Y-lable_A.Size.Height);
            label_B.Location = new Point(B.X-label_B.Size.Width, B.Y-label_B.Size.Height);
            label_C.Location = new Point(C.X-label_C.Size.Width/2, C.Y);
        }

        void Increase_triangle()
        {
            if (A.X > 0)
            {
                A = new Point(A.X - delta, A.Y);
            }
            if (A.Y < containers.Panel2.Height)
            {
                A = new Point(A.X, A.Y + delta);
            }
            if (B.X < containers.Panel2.Width)
            {
                B = new Point(B.X + delta, B.Y);
            }
            if (B.Y < containers.Panel2.Height)
            {
                B = new Point(B.X, B.Y + delta);
            }
            if (C.Y > 0)
            {
                C = new Point(C.X, C.Y - delta);
            }

            Lable_Update();
            containers.Panel2.Invalidate();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (A.Y > containers.Panel2.Height)
            {
                A = new Point(A.X,containers.Panel2.Height);
            }            
            if (B.Y > containers.Panel2.Height)
            {
                B = new Point(B.X,containers.Panel2.Height);
            }            
            if (B.X > containers.Panel2.Width)
            {
                B = new Point(containers.Panel2.Width,B.Y);
            }

            containers.Panel2.Invalidate();
            Lable_Update();
        }
    }
}

using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Практика_1
{
    public partial class Form1 : Form
    {
        Point[] points;
        //SoundPlayer soundPlayer = new SoundPlayer();
        public Form1()
        {
            InitializeComponent();
            points = new Point[] {
                new Point(containers.Panel2.Width / 4, containers.Panel2.Height / 5 * 4),
                new Point(containers.Panel2.Width / 4 * 3, containers.Panel2.Height / 5 * 4),
                new Point(containers.Panel2.Width / 2, containers.Panel2.Height / 5) };
            //soundPlayer  = new SoundPlayer();
            //soundPlayer.Stream = Properties.Resources.music;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPolygon(new SolidBrush(Color.Green), points);
        }

        private void button_Click(object sender, EventArgs e)
        {
            Increase_triangle();
            //soundPlayer.Play();
        }

        void Increase_triangle()
        {
            if (points[0].X > 0)
            {
                points[0] = new Point(points[0].X - 5, points[0].Y);
            }
            if (points[0].Y < containers.Panel2.Height)
            {
                points[0] = new Point(points[0].X, points[0].Y + 5);
            }
            if (points[1].X < containers.Panel2.Width)
            {
                points[1] = new Point(points[1].X + 5, points[1].Y);
            }
            if (points[1].Y < containers.Panel2.Height)
            {
                points[1] = new Point(points[1].X, points[1].Y + 5);
            }
            if (points[2].Y > 0)
            {
                points[2] = new Point(points[2].X, points[2].Y - 5);
            }

            containers.Panel2.Invalidate();
        }
    }
}

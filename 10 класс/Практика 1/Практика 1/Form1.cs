using System;
using System.Drawing;
using System.Windows.Forms;

namespace Практика_1
{
    public partial class Form1 : Form
    {
        Point[] points;
        public Form1()
        {
            InitializeComponent();
            points = new Point[] { 
                new Point(containers.Panel2.Width / 4, containers.Panel2.Height / 5 * 4), 
                new Point(containers.Panel2.Width / 4 * 3, containers.Panel2.Height / 5 * 4), 
                new Point(containers.Panel2.Width / 2, containers.Panel2.Height / 5) };

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPolygon(new SolidBrush(Color.Green), points);
        }

        private void button_Click(object sender, EventArgs e)
        {
            Increase_triangle();
            Invalidate();
        }

        void Increase_triangle()
        {
            points[0] = new Point(points[0].X - 5, points[0].Y + 5);
            points[1] = new Point(points[1].X + 5, points[1].Y + 5);
            points[2] = new Point(points[2].X - 5, points[2].Y - 5);
        }
    }
}

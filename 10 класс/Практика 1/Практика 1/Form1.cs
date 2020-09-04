using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_1
{
    public partial class Form1 : Form
    {
        Point[] points;
        public Form1()
        {
            InitializeComponent();
            points = new Point[]{new Point(containers.Panel2.Width/3, containers.Panel2.Height/2),new Point(containers.Panel2.Width/3*2, containers.Panel2.Height/2),new Point(200, 5)
            };
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPolygon(new SolidBrush(Color.Green),points);
        }

        private void button_Click(object sender, EventArgs e)
        {

        }
    }
}

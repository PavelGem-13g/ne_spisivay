using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace mnogougolniki
{
    public partial class Form1 : Form
    {
        Collection<Shape> shapes;
        int shapeType;
        public Form1()
        {
            InitializeComponent();
            shapes = new Collection<Shape>();
            DoubleBuffered = true;
            shapeType = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var item in shapes)
            {
                if (item.IsMovable)
                {
                    item.Location = new Point(e.Location.X + item.MoveShift.X, e.Location.Y + item.MoveShift.Y);
                    Refresh();
                }
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                bool flagAddShape = true;
                foreach (var item in shapes)
                {
                    if (item.IsInside(e.Location))
                    {
                        item.IsMovable = true;
                        item.MoveShift = new Point(item.X - e.X, item.Y - e.Y);
                        flagAddShape = false;
                    }
                }
                if (flagAddShape)
                {
                    if (shapeType==0)
                    {
                        shapes.Add(new Sqare(e.Location));
                    }
                    if (shapeType==1)
                    {
                        shapes.Add(new Circle(e.Location));
                    }
                    if (shapeType==2)
                    {
                        shapes.Add(new Triangle(e.Location));
                    }
                }
            }
            if (MouseButtons.Right == e.Button)
            {
                foreach (var item in shapes)
                {
                    if (item.IsInside(e.Location))
                    {
                        shapes.Remove(item);
                        break;
                    }
                }
            }
            Refresh();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                foreach (var item in shapes)
                {
                    item.IsMovable = false;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in shapes)
            {
                item.Draw(e.Graphics);
            }
        }

        private void sqareToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            shapeType = 0;
        }

        private void circleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            shapeType = 1;
        }

        private void triangleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            shapeType = 2;
        }
    }
}

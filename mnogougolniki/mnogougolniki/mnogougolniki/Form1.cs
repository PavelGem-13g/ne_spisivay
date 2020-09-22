using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace mnogougolniki
{
    public partial class Form1 : Form
    {
        Collection<Shape> shapes;
        public Form1()
        {
            InitializeComponent();
            shapes = new Collection<Shape>();
            DoubleBuffered = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var item in shapes)
            {
                if (item.IsMovable)
                {
                    item.Location = new Point(e.Location.X-item.MoveShift.X, e.Location.Y - item.MoveShift.Y);
                    Refresh();
                }
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                ushort k = 0;
                foreach (var item in shapes)
                {
                    if (item.IsInside(e.Location))
                    {
                        item.IsMovable = true;
                        item.MoveShift = new Point(e.X-item.X, e.Y-item.Y);
                        //MessageBox.Show(item.MoveShift.X + " " + item.MoveShift.Y);
                        k++;
                    }
                }
                if (shapes.Count == 0 || k == 0)
                {
                    shapes.Add(new Sqare(e.Location));
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
    }
}

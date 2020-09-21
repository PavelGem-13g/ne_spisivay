using System.Collections.ObjectModel;
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
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var item in shapes)
            {
                if (item.IsMovable)
                {
                    item.Location = e.Location;
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
                        k++;
                        //чтоб захватывалась только одна вершина
                        break;
                    }
                }
/*              Наработка для обработки 2-ух и более точек за 1 drag&drop 1 точки
                bool end = false;
                foreach (var item in shapes)
                {
                    foreach (var item2 in shapes)
                    {
                        if (item.IsMovable && item2.IsMovable && item.Location==item2.Location)
                        {
                            end = true;
                            shapes.Remove(item2);
                        }
                        if (end) break;
                    }
                    if (end) break;
                }*/
                if (shapes.Count == 0 || k == 0)
                {
                    shapes.Add(new Circle(e.Location.X, e.Location.Y));
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

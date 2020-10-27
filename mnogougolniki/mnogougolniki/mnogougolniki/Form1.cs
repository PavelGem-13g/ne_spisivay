using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace mnogougolniki
{
    public partial class Form1 : Form
    {
        List<Shape> shapes;
        int shapeType;
        int drawningType;
        public Form1()
        {
            InitializeComponent();
            shapes = new List<Shape>();
            DoubleBuffered = true;

            shapeType = 0;
            drawningType = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].IsMovable)
                {
                    shapes[i].X = e.Location.X + shapes[i].MoveShift.X;
                    shapes[i].Y = e.Location.Y + shapes[i].MoveShift.Y;
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
                    if (shapeType == 0)
                    {
                        shapes.Add(new Sqare(e.Location));
                    }
                    if (shapeType == 1)
                    {
                        shapes.Add(new Circle(e.Location));
                    }
                    if (shapeType == 2)
                    {
                        shapes.Add(new Triangle(e.Location));
                    }
                }
            }
            if (MouseButtons.Right == e.Button)
            {
                for (int i = shapes.Count - 1; 0 <= i; i--)
                {
                    if (shapes[i].IsInside(e.Location))
                    {
                        shapes.Remove(shapes[i]);
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
            if (shapes.Count > 2)
            {
                for (int i = shapes.Count - 1; i > 0; i--)
                {
                    if (!shapes[i].IsShell)
                    {
                        shapes.Remove(shapes[i]);
                    }
                }
                Refresh();
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (shapes.Count > 2)
            {
                foreach (var item in shapes)
                {
                    item.IsShell = false;
                }

                if (drawningType == 0)
                {
                    definitionDrawning(e.Graphics);
                }
                if (drawningType == 1)
                {
                    jarvisDrawning(e.Graphics);
                }
            }
            foreach (var item in shapes)
            {
                item.Draw(e.Graphics);
            }
        }
        bool polygonIsInside()
        {
            bool result = false;
            return result;
        }
        void definitionDrawning(Graphics g)
        {
            double b;
            double k;
            bool right;
            bool left;
            bool up;
            bool down;

            foreach (var first in shapes)
            {
                foreach (var second in shapes)
                {
                    if (first != second)
                    {
                        if (first.X == second.X)
                        {
                            right = false;
                            left = false;
                            foreach (var third in shapes)
                            {
                                if (third != first && third != second)
                                {
                                    if (first.X >= third.X)
                                    {
                                        left = true;
                                    }
                                    else
                                    {
                                        right = true;
                                    }
                                }
                            }
                            if (right != left)
                            {
                                first.IsShell = true;
                                second.IsShell = true;
                                g.DrawLine(new Pen(new SolidBrush(Shape.LineColor)), new Point(first.X, first.Y), new Point(second.X, second.Y));
                            }
                        }
                        else
                        {
                            k = (first.Y - second.Y + .0) / (first.X - second.X + .0);
                            b = first.Y - (k * first.X);
                            up = false;
                            down = false;
                            foreach (var third in shapes)
                            {
                                if (third != first && third != second)
                                {
                                    if (third.Y >= (k * third.X + b))
                                    {
                                        down = true;
                                    }
                                    else
                                    {
                                        up = true;
                                    }
                                }
                            }
                            if (up != down)
                            {
                                first.IsShell = true;
                                second.IsShell = true;
                                g.DrawLine(new Pen(new SolidBrush(Shape.LineColor)), new Point(first.X, first.Y), new Point(second.X, second.Y));
                            }
                        }
                    }
                }
            }

        }
        void jarvisDrawning(Graphics g)
        {
            int p0 = 0;
            for (int i = 0; i < shapes.Count - 1; i++)
            {
                if (shapes[i].X < shapes[i + 1].X && shapes[i].Y > shapes[i + 1].Y)
                {
                    p0 = i;
                }
            }
            int pi = 0;
            pi = p0;
            int k = 0;
            do
            {
                k++;
                if (k == 1)
                {
                    pi = 
                }
                else
                {
                    for (int i = 0; i < shapes.Count - 1; i++)
                    {
                        if (i != k)
                        {

                        }
                    }
                }
                pi = k;


            } while (pi != p0);

        }
        private void sqareToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            shapeType = 0;
            sqareToolStripMenuItem.Checked = true;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
        }

        private void circleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            shapeType = 1;
            sqareToolStripMenuItem.Checked = false;
            circleToolStripMenuItem.Checked = true;
            triangleToolStripMenuItem.Checked = false;
        }

        private void triangleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            shapeType = 2;
            sqareToolStripMenuItem.Checked = false;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = true;
        }

        private void lineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            Shape.LineColor = colorDialog.Color;
            Refresh();
        }

        private void fillColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            Shape.FillColor = colorDialog.Color;
            Refresh();
        }

        private void dtfenitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawningType = 0;
            dtfenitionToolStripMenuItem.Checked = true;
            jarvisToolStripMenuItem.Checked = false;
        }

        private void jarvisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawningType = 1;
            dtfenitionToolStripMenuItem.Checked = false;
            jarvisToolStripMenuItem.Checked = true;
        }
    }
}

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
                for (int i = shapes.Count - 1; i >= 0; i--)
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
            int iA = 0, iP = 0;
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[iA].Y < shapes[i].Y)
                {
                    iA = i;
                }
            }
            /// create M, that to the left of A
            Point M = shapes[iA].Location;
            M.X -= 1000;
            ///finding max angle
            double minCos = 100000d;
            for (int i = 0; i < shapes.Count; i++)
            {
                if (i != iA)
                {
                    //расчет косинуса
                    if (CosCounting(shapes[i].Location, shapes[iA].Location, M) < minCos)
                    {
                        minCos = CosCounting(shapes[i].Location, shapes[iA].Location, M);
                        iP = i;
                    }

                }
            }
            ///drawinig and switch to isShell
            g.DrawLine(new Pen(new SolidBrush(Shape.LineColor)), shapes[iA].Location, shapes[iP].Location);
            shapes[iA].IsShell = true;
            shapes[iP].IsShell = true;
            //cycled finding
            int iA_copy = iA;
            int iM = 0;
            do
            {
                minCos = double.MaxValue;
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (i != iA)
                    {
                        //расчет косинуса
                        if (CosCounting(shapes[iA].Location, shapes[iP].Location, shapes[i].Location) < minCos)
                        {
                            minCos = CosCounting(shapes[iA].Location, shapes[iP].Location, shapes[i].Location);
                            iM = i;
                        }
                    }
                }
                g.DrawLine(new Pen(new SolidBrush(Shape.LineColor)), shapes[iP].Location, shapes[iM].Location);
                shapes[iM].IsShell = true;
                iA = iP;
                iP = iM;
            } while (iP != iA_copy);
        }
        double CosCounting(Point a, Point b, Point c)
        {
            Point VectorA = new Point(b.X - a.X, b.Y - a.Y);
            Point VectorB = new Point(b.X - c.X, b.Y - c.Y);
            return ((VectorA.X * VectorB.X) + (VectorA.Y * VectorB.Y)) / (Math.Sqrt(VectorA.X * VectorA.X + VectorA.Y * VectorA.Y) * Math.Sqrt(VectorB.X * VectorB.X + VectorB.Y * VectorB.Y));
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

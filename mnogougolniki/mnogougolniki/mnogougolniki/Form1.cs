using mnogougolniki.UndoRedo;
using MnogugolnikiShapeLibrary;
using MnogugolnikiShapeLibrary.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace mnogougolniki
{
    public partial class Form : System.Windows.Forms.Form
    {
        public static Form instance;
        public List<Shape> shapes;
        public int shapeType;
        int drawningType;
        Timer timer;
        static int t;
        long time;
        Random random;
        bool isDrag;
        public Radius radiusForm;
        Dynamics dynamicsForm;
        string fileName;
        bool isChanged;
        public Stack<Change> undo;
        public Stack<Change> redo;
        public static int T
        {
            get
            {
                return t;
            }
            set
            {
                t = value;
            }
        }

        public Form()
        {
            instance = this;
            InitializeComponent();
            shapes = new List<Shape>();
            DoubleBuffered = true;
            timer = new Timer();
            timer.Tick += Timer_Tick;
            time = 0;
            shapeType = 0;
            drawningType = 0;
            t = 99;
            random = new Random();
            isDrag = false;
            radiusForm = new Radius();
            dynamicsForm = new Dynamics();
            Radius.RC += this.OnRadiusChanged;
            Dynamics.TC += this.OnTimeChanged;
            fileName = "";
            isChanged = false;
            KeyPreview = true;
            undo = new Stack<Change>();
            redo = new Stack<Change>();
            Change.shapes = shapes;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time += timer.Interval;
            if (time > t)
            {
                ShakeShell();
                if (!isDrag) ClearShell();
                time = 0;
                Refresh();
            }
        }
        void ShakeShell()
        {
            foreach (var item in shapes)
            {
                item.X += random.Next(-2, 3);
                item.Y += random.Next(-2, 3);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].IsMovable)
                {
                    shapes[i].X = e.Location.X + shapes[i].MoveShift.X;
                    shapes[i].Y = e.Location.Y + shapes[i].MoveShift.Y;
                }
            }
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (MouseButtons.Left == e.Button)
            {
                bool flagAddShape = true;
                if (shapes.Count > 2 && PolygonIsInside(e.Location))
                {
                    foreach (var item in shapes)
                    {
                        item.IsMovable = true;
                        item.MoveShift = new Point(item.X - e.X, item.Y - e.Y);
                        item.StartPositionX = item.X;
                        item.StartPositionY = item.Y;
                        flagAddShape = false;
                        isDrag = true;
                    }
                }
                else
                {
                    foreach (var item in shapes)
                    {
                        if (item.IsInside(e.Location))
                        {
                            item.IsMovable = true;
                            item.MoveShift = new Point(item.X - e.X, item.Y - e.Y);
                            item.StartPositionX = item.X;
                            item.StartPositionY = item.Y;
                            flagAddShape = false;
                            isDrag = true;
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
                        redo.Clear();
                        undo.Push(new ChangeAddShape(shapes[shapes.Count-1]));
                    }
                }
                isChanged = true;

            }
            if (MouseButtons.Right == e.Button)
            {
                
                for (int i = shapes.Count - 1; 0 <= i; i--)
                {
                    if (shapes[i].IsInside(e.Location))
                    {
                        redo.Clear();
                        undo.Push(new ChangeDeleteShape(shapes[i]));
                        shapes.Remove(shapes[i]);
                        break;
                    }
                }
                isChanged = true;
            }
            Refresh();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                ClearRedoStack();
                undo.Push(new ChangeFigureMove());
            }
            isDrag = false;
            if (MouseButtons.Left == e.Button)
            {
                foreach (var item in shapes)
                {
                    item.IsMovable = false;
                    item.StartPositionX = item.X;
                    item.StartPositionY = item.Y;
                }
            }
            ClearShell();
            Refresh();
        }
        void ClearShell()
        {
            if (shapes.Count > 2)
            {
                for (int i = shapes.Count - 1; i >= 0; i--)
                {
                    if (!shapes[i].IsShell)
                    {
                        shapes.Remove(shapes[i]);
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (shapes.Count > 2)
            {
                //DrawPolygon(e.Graphics);
                foreach (var item in shapes)
                {
                    item.IsShell = false;
                }

                if (drawningType == 0)
                {
                    DefinitionDrawning(e.Graphics);
                }
                if (drawningType == 1)
                {
                    JarvisDrawning(e.Graphics);
                }
            }
            foreach (Shape item in shapes)
            {
                item.Draw(e.Graphics);
            }
        }

        void DrawPolygon(Graphics g)
        {
            Point[] pointMass = new Point[shapes.Count];
            for (int i = 0; i < shapes.Count; i++)
            {
                pointMass[i] = shapes[i].Location;
            }
            g.FillPolygon(new SolidBrush(Shape.LineColor), pointMass);
        }

        bool PolygonIsInside(Point point)
        {
            bool result = false;
            int iA = 0, iP = 0;
            List<Point> points = new List<Point>();
            for (int i = 0; i < shapes.Count; i++)
            {
                points.Add(shapes[i].Location);
            }
            points.Add(point);
            for (int i = 0; i < points.Count; i++)
            {
                if (points[iA].Y < points[i].Y)
                {
                    iA = i;
                }
            }
            /// create M, that to the left of A
            Point M = points[iA];
            M.X -= 1000;
            ///finding max angle
            double minCos = double.MaxValue;
            for (int i = 0; i < points.Count; i++)
            {
                if (i != iA)
                {
                    //расчет косинуса
                    if (CosCounting(points[i], points[iA], M) < minCos)
                    {
                        minCos = CosCounting(points[i], points[iA], M);
                        iP = i;
                        if (points.Count - 1 == iP)
                        {
                            result = true;
                        }
                    }

                }
            }
            ///drawinig and switch to isShell
            //cycled finding
            int iA_copy = iA;
            int iM = 0;
            do
            {
                minCos = double.MaxValue;
                for (int i = 0; i < points.Count; i++)
                {
                    if (i != iA)
                    {
                        //расчет косинуса
                        if (CosCounting(points[iA], points[iP], points[i]) < minCos)
                        {
                            minCos = CosCounting(points[iA], points[iP], points[i]);
                            iM = i;
                            if (points.Count - 1 == iM)
                            {
                                result = true;
                            }
                        }
                    }
                }
                iA = iP;
                iP = iM;
            } while (iP != iA_copy);
            return !result;
        }

        void DefinitionDrawning(Graphics g)
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

        void JarvisDrawning(Graphics g)
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
            } while (iP != iA_copy) ;
        }

        double CosCounting(Point a, Point b, Point c)
        {
            Point VectorA = new Point(b.X - a.X, b.Y - a.Y);
            Point VectorB = new Point(b.X - c.X, b.Y - c.Y);
            return ((VectorA.X * VectorB.X) + (VectorA.Y * VectorB.Y)) / (Math.Sqrt(VectorA.X * VectorA.X + VectorA.Y * VectorA.Y) * Math.Sqrt(VectorB.X * VectorB.X + VectorB.Y * VectorB.Y));
        }

        private void sqareToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ClearRedoStack();
            undo.Push(new ChangeShapeType(shapeType, 0));
            shapeType = 0;
            sqareToolStripMenuItem.Checked = true;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
        }

        private void circleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ClearRedoStack();
            undo.Push(new ChangeShapeType(shapeType, 1));
            shapeType = 1;
            sqareToolStripMenuItem.Checked = false;
            circleToolStripMenuItem.Checked = true;
            triangleToolStripMenuItem.Checked = false;
        }

        private void triangleToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ClearRedoStack();
            undo.Push(new ChangeShapeType(shapeType, 2));
            shapeType = 2;
            sqareToolStripMenuItem.Checked = false;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = true;
        }

        private void lineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            ClearRedoStack();
            undo.Push(new ChangeColor(Shape.FillColor, colorDialog.Color, 1));
            Shape.LineColor = colorDialog.Color;
            isChanged = true;
            Refresh();
        }

        private void fillColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            ClearRedoStack();
            undo.Push(new ChangeColor(Shape.FillColor, colorDialog.Color, 0));
            Shape.FillColor = colorDialog.Color;
            isChanged = true;
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

        private void radiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radiusForm.IsDisposed)
            {
                radiusForm = new Radius();
            }
            if (!radiusForm.IsAccessible)
            {
                radiusForm.Activate();
            }
            if (radiusForm.WindowState == FormWindowState.Minimized)
            {
                radiusForm.WindowState = FormWindowState.Normal;
            }
            if (radiusForm.WindowState == FormWindowState.Maximized)
            {
                radiusForm.WindowState = FormWindowState.Normal;
            }
            radiusForm.Show();
        }
        public void OnRadiusChanged(object sender, RadiusEventArgs e)
        {
            Shape.R = e.R;
            isChanged = true;
            Refresh();
        }

        public void OnTimeChanged(object sender, TimeEventArgs e)
        {
            t = e.T;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            foreach (var item in shapes)
            {
                item.StartPositionX = item.X;
                item.StartPositionY = item.Y;
            }
            timer.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            ClearRedoStack();
            undo.Push(new ChangeFigureMove());
            timer.Stop();
            time = 0;
        }

        private void changeTimeButton_Click(object sender, EventArgs e)
        {
            if (dynamicsForm.IsDisposed)
            {
                dynamicsForm = new Dynamics();
            }
            if (!dynamicsForm.IsAccessible)
            {
                dynamicsForm.Activate();
            }
            if (dynamicsForm.WindowState == FormWindowState.Minimized)
            {
                dynamicsForm.WindowState = FormWindowState.Normal;
            }
            if (dynamicsForm.WindowState == FormWindowState.Maximized)
            {
                dynamicsForm.WindowState = FormWindowState.Normal;
            }
            dynamicsForm.Show();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                if (MessageBox.Show("Save file?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ShapeData.Save(ref shapes, ref fileName, ref isChanged);
                }
                isChanged = false;
            }
            string tempText = "";
            ShapeData.New(ref shapes, ref fileName, ref tempText);
            Text = tempText;
            Refresh();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShapeData.Save(ref shapes, ref fileName, ref isChanged);
            UpdateTopPanel();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShapeData.LoadFile(ref shapes, ref fileName, ref isChanged);
            UpdateTopPanel();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShapeData.SaveAsFile(ref shapes, ref fileName, ref isChanged);
            UpdateTopPanel();
        }

        void UpdateTopPanel()
        {
            if (fileName.Length > 0)
            {
                string nameOfFile = fileName;
                int i = nameOfFile.Length - 1;
                while (nameOfFile[i] != '\\')
                {
                    i--;
                }
                nameOfFile = nameOfFile.Substring(i + 1);
                Text = "Mnogugolniki - " + nameOfFile;
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                ShapeData.Save(ref shapes, ref fileName, ref isChanged);
            }

            if (e.Control && e.KeyCode == Keys.O)
            {
                ShapeData.LoadFile(ref shapes, ref fileName, ref isChanged);
            }
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
            }
            if (e.Control && e.KeyCode == Keys.Y)
            {
                Redo();
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                if (MessageBox.Show("Save file?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ShapeData.Save(ref shapes, ref fileName, ref isChanged);
                }
            }
        }
        void Undo()
        {
            if (undo.Count > 0)
            {
                Console.WriteLine("undo " + undo.Peek().GetType().Name);
                Change change = undo.Pop();
                change.Undo();
                redo.Push(change);
            }
            Refresh();
        }
        void Redo()
        {
            if (redo.Count > 0)
            {
                Console.WriteLine("redo " + redo.Peek().GetType().Name);
                Change change = redo.Pop();
                change.Redo();
                undo.Push(change);
            }
            Refresh();
        }
        public void ClearRedoStack()
        {
            Console.WriteLine("redo cleared");
            redo.Clear();
            ClearShell();
        }
    }
}

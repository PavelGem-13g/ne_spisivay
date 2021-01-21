using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace mnogougolniki
{
    public partial class Form : System.Windows.Forms.Form
    {
        List<Shape> shapes;
        int shapeType;
        int drawningType;
        Timer timer;
        static int t;
        long time;
        Random random;
        bool isDrag;
        Radius radiusForm;
        Dynamics dynamicsForm;
        string fileName;
        bool isChanged;
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
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time += timer.Interval;
            if (time > t)
            {
                //timer.Stop();
                ShakeShell();
                if (!isDrag) ClearShell();
                time = 0;
                Refresh();
                //timer.Start();
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
                        flagAddShape = false;
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
            isDrag = false;
            if (MouseButtons.Left == e.Button)
            {
                foreach (var item in shapes)
                {
                    item.IsMovable = false;
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
            foreach (var item in shapes)
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
            Refresh();
        }
        public void OnTimeChanged(object sender, TimeEventArgs e)
        {
            t = e.T;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
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
        void SaveAsFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "poly files (*.poly)|*poly";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName.Contains(".poly"))
                {
                    fileName = saveFileDialog.FileName;
                }
                else
                {
                    fileName = saveFileDialog.FileName + ".poly";
                }
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                binaryFormatter.Serialize(fileStream, shapes);
                binaryFormatter.Serialize(fileStream, Shape.R);
                binaryFormatter.Serialize(fileStream, Shape.FillColor);
                binaryFormatter.Serialize(fileStream, Shape.LineColor);
                UpdateTopPanel();
            }
        }
        void SaveFile()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            binaryFormatter.Serialize(fileStream, shapes);
            binaryFormatter.Serialize(fileStream, Shape.R);
            binaryFormatter.Serialize(fileStream, Shape.FillColor);
            binaryFormatter.Serialize(fileStream, Shape.LineColor);
            fileStream.Close();
            UpdateTopPanel();
        }
        void LoadFile()
        {
            if (isChanged)
            {
                if (MessageBox.Show("Save file?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save();
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "poly files (*.poly)|*poly";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                shapes = (List<Shape>)binaryFormatter.Deserialize(fileStream);
                Shape.R = (int)binaryFormatter.Deserialize(fileStream);
                Shape.FillColor = (Color)binaryFormatter.Deserialize(fileStream);
                Shape.LineColor = (Color)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
                fileName = openFileDialog.FileName;
                isChanged = false;  
                UpdateTopPanel();
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged) 
            {
                if (MessageBox.Show("Save file?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save();
                }
                isChanged = false;
            }
            New();
            Refresh();
        }
        public void New() 
        {
            shapes = new List<Shape>();
            Shape.FillColor = Color.Black;
            Shape.LineColor = Color.Black;
            Shape.R = 50;
            fileName = "";
            Text = "Mnogugolniki";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        void Save() 
        {
            if (fileName.Length > 0)
            {
                SaveFile();
            }
            else
            {
                SaveAsFile();
            }
            isChanged = false;
        
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile();
            isChanged = false;
        }
        void UpdateTopPanel()
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

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) 
            {
                if (fileName.Length > 0)
                {
                    SaveFile();
                }
                else
                {
                    LoadFile();
                }
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                if (fileName.Length > 0)
                {
                    SaveFile();
                }
                else
                {
                    SaveAsFile();
                }
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged) 
            {
                if (MessageBox.Show("Save file?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save();
                }
            }
        }
    }
}

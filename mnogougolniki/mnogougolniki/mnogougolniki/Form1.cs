using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mnogougolniki
{
    public partial class Form1 : Form
    {
        Collection<Shape> shapes;
        //Sqare circle;
        public Form1()
        {
            InitializeComponent();
            shapes = new Collection<Shape>();
            //circle = new Sqare(ClientSize.Width/2,ClientSize.Height/2);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            /*if (circle.IsMovable) 
            {
                circle.X = e.X;
                circle.Y = e.Y;
            }*/
            foreach (var item in shapes)
            {
                if (item.IsMovable) 
                {
                    item.X = e.X;
                    item.Y = e.Y;
                }
            }
            Refresh();
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {/*
            if (circle.IsInside(e.Location)) 
            {
                circle.IsMovable = true;
            }*/
            //наработки для коллекцией 
            foreach (var item in shapes)
            {
                if (item.IsInside(e.Location))
                {
                    item.IsMovable = true;
                }
            }
            if (shapes.Count == 0) 
            {
                shapes.Add(new Circle(e.Location.X, e.Location.Y));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //circle.IsMovable = false;
            //наработка для коллекции
            int k = 0;
            foreach (var item in shapes)
            {
                if (item.IsMovable) 
                {
                    k++;
                }
            }
            if (k.Equals(0)) 
            {
                shapes.Add(new Circle(e.X, e.Y));
            }
            foreach (var item in shapes)
            {
                item.IsMovable = false;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //circle.Draw(e.Graphics);
            //наработки для коллекций
            foreach (var item in shapes)
            {
                item.Draw(e.Graphics);
            }
        }
    }
}

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
        public Form1()
        {
            InitializeComponent();
            shapes = new Collection<Shape>();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var item in shapes)
            {
                if (item.IsInside(e.Location))
                {
                    foreach (var changer in shapes)
                    {
                        changer.IsMovable = true;
                    }
                    break;
                }
                else 
                {
                    //TODO shapes.Add(new Shape(e.Location.X, e.Location.Y));
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (var changer in shapes)
            {
                changer.IsMovable = false;
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

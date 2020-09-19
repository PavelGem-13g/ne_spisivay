using System.Drawing;
using System.Windows.Forms;

namespace mnogougolniki
{
    abstract class Shape
    {
        static int r;
        static Color lineColor;
        static Color fillColor;
        int x;
        int y;
        public int X 
        {
            get 
            {
                return x;
            }
        }
        public int Y 
        {
            get 
            {
                return y;
            }
        }
        public int R 
        {
            get 
            {
                return r;
            }
        }
        public Color LineColor
        {
            get 
            {
                return lineColor;
            }
        }
        public Color FillColor
        {
            get 
            {
                return fillColor;
            }
        }
        static Shape()
        {
            r = 1;
        }
        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public abstract void Draw(Graphics g);
        public abstract bool IsInside(Point mousePosition);
    }
}

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

        protected int X 
        {
            get 
            {
                return x;
            }
        }
        protected Color LineColor
        {
            get 
            {
                return lineColor;
            }
        }
        protected Color FillColor
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
        protected int Y 
        {
            get 
            {
                return y;
            }
        }
        protected int R 
        {
            get 
            {
                return r;
            }
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

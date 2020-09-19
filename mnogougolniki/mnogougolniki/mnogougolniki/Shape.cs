using System.Drawing;
using System.Windows.Forms;

namespace mnogougolniki
{
    abstract class Shape
    {
        static int r;
        static Color lineColor;
        static Color fillColor;
        bool isMovable;
        int x;
        int y;
        public int X 
        {
            get 
            {
                return x;
            }
            set 
            {
                x = value;
            }
        }
        public int Y 
        {
            get 
            {
                return y;
            }
            set 
            {
                y = value;
            }
        }
        public int R 
        {
            get 
            {
                return r;
            }
        }
        public bool IsMovable
        {
            get 
            {
                return isMovable;
            }
            set 
            {
                isMovable = value;
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
            r = 10;
            lineColor = Color.Black;
            fillColor = Color.Black;
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

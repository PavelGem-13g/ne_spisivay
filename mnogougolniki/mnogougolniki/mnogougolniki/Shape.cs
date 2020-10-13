using System.Drawing;

namespace mnogougolniki
{
    abstract class Shape
    {
        static int r;
        static Color lineColor;
        static Color fillColor;
        bool isMovable;
        bool isDrawable;
        int x;
        int y;
        int xShift;
        int yShift;
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
        public int YShift
        {
            get
            {
                return yShift;
            }
        }
        public int XShift
        {
            get
            {
                return xShift;
            }
        }
        public Point MoveShift
        {
            get
            {
                return new Point(XShift, YShift);
            }
            set
            {
                xShift = value.X;
                yShift = value.Y;
            }
        }
        public bool IsDrawable 
        {
            get 
            {
                return isDrawable;
            }
            set 
            {
                isDrawable = value;
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
        public Point Location
        {
            get
            {
                return new Point(x, y);
            }
            set
            {
                x = value.X;
                y = value.Y;
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
            r = 50;
            lineColor = Color.Black;
            fillColor = Color.Black;
        }
        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Shape(Point position)
        {
            this.x = position.X;
            this.y = position.Y;
        }
        public abstract void Draw(Graphics g);
        public abstract bool IsInside(Point mousePosition);
    }
}

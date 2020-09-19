using System.Drawing;
using System.Windows.Forms;

namespace mnogougolniki
{
    abstract class Shape
    {
        static int R;
        static Color lineColor;
        static Color fillColor;
        int x;
        int y;
        static Shape()
        {
            R = 1;
        }
        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual void Draw(Graphics g)
        {
            g.Dispose();
        }
        public virtual bool IsInside(Point mousePosition)
        {
            return true;
        }
    }
}

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
            lineColor = Color.Black;
            fillColor = Color.Black;
        }
        public Shape(int x, int y, int R, Color lineColor, Color fillColor)
        {
            this.x = x;
            this.y = y;
            this.R = R;

        }
        public virtual void Draw(Graphics g)
        {
            Application.Exit();
        }
        public virtual bool IsInside(Point pos)
        {
            return true;
        }
    }
}

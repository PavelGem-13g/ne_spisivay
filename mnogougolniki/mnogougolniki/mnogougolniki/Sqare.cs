using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnogougolniki
{
    class Sqare : Shape
    {
        public Sqare(int x, int y) : base(x, y)
        {

        }
        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Blue), X - R, Y - R, (int)(R * Math.Sqrt(2)), (int)(R * Math.Sqrt(2)));
        }
        public override bool IsInside(Point mousePosition)
        {
            Point A = new Point(X - (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2));
            Point B = new Point(X - (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2));
            Point C = new Point(X + (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2));
            Point D = new Point(X + (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2));

            return (A.X >= mousePosition.X) && (C.X <= mousePosition.X) && (B.Y <= mousePosition.Y) && (D.Y >= mousePosition.Y);
        }
    }
}

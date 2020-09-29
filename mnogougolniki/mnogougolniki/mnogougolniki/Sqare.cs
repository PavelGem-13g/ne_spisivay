using System;
using System.Drawing;

namespace mnogougolniki
{
    class Sqare : Shape
    {
        public Sqare(int x, int y) : base(x, y)
        {

        }
        public Sqare(Point position) : base (position)
        {
        
        }
        public override void Draw(Graphics g)
        {
            Point[] points = new Point[]
            {
            new Point(X - (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2)),
            new Point(X - (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2)),
            new Point(X + (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2)),
            new Point(X + (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2))
        };

            g.FillPolygon(new SolidBrush(FillColor), points);
        }
        public override bool IsInside(Point mousePosition)
        {
            Point A = new Point(X - (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2));
            Point B = new Point(X - (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2));
            Point C = new Point(X + (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2));
            Point D = new Point(X + (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2));

            return (A.X <= mousePosition.X) && (mousePosition.X <= C.X) && (B.Y <= mousePosition.Y) && (mousePosition.Y <= D.Y);
        }
    }
}

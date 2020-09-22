using System;
using System.Drawing;

namespace mnogougolniki
{
    class Triangle : Shape
    {
        public Triangle(int x, int y) : base(x, y)
        {

        }
        public Triangle(Point position) : base(position)
        {

        }

        public override void Draw(Graphics g)
        {
            Point[] points = new Point[]{
            new Point(X-R*(int)Math.Sqrt(3)/2,Y+R/2),
            new Point(X,Y-R),
            new Point(X+R*(int)Math.Sqrt(3)/2,Y+R/2)};

            g.FillPolygon(new SolidBrush(FillColor), points);
        }

        public override bool IsInside(Point mousePosition)
        {
            Point A = new Point(X - R * (int)Math.Sqrt(3) / 2, Y + R / 2);
            Point B = new Point(X, Y - R);
            Point C = new Point(X + R * (int)Math.Sqrt(3) / 2, Y + R / 2);

            int a = (A.X - mousePosition.X) * (B.Y - A.Y) - (B.X - A.X) * (A.Y - mousePosition.Y);
            int b = (B.X - mousePosition.X) * (C.Y - B.Y) - (C.X - B.X) * (B.Y - mousePosition.Y);
            int c = (C.X - mousePosition.X) * (A.Y - C.Y) - (A.X - C.X) * (C.Y - mousePosition.Y);

            return ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0));
        }
    }
}

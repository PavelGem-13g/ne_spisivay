using System;
using System.Drawing;

namespace mnogougolniki
{
    class Circle : Shape
    {
        public Circle(int x, int y) : base(x, y)
        {

        }
        public Circle(Point position) : base(position)
        {

        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(FillColor), X-R, Y-R, R * 173 / 100, R * 173 / 100);
        }

        public override bool IsInside(Point mousePosition)
        {
            return Math.Pow(X - mousePosition.X, 2) + Math.Pow(Y - mousePosition.Y, 2) <= R * R;
        }
    }
}

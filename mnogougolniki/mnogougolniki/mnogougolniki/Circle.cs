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
            g.FillEllipse(new SolidBrush(FillColor), X -R/2, Y -R/2, R, R);
        }

        public override bool IsInside(Point mousePosition)
        {
            return Math.Sqrt(Math.Pow(X - mousePosition.X, 2) + Math.Pow(Y - mousePosition.Y, 2)) <= R;
        }
    }
}

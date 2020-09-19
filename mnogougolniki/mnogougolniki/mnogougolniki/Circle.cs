using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnogougolniki
{
    class Circle:Shape
    {
        public Circle(int x, int y):base(x,y)
        {
            
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(FillColor), X - R, Y - R, R, R);
        }

        public override bool IsInside(Point mousePosition)
        {
            return Math.Sqrt(Math.Pow(X - mousePosition.X, 2) + Math.Pow(Y - mousePosition.Y, 2)) <= R;
        }
    }
}

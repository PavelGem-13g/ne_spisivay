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
            g.FillRectangle(new SolidBrush(LineColor), X - R, Y - R, R, R);
        }
        public override bool IsInside(Point mousePosition)
        {
            Point one = new Point(X-)

/*            int a = (x[1] - x[0]) * (y[2] - y[1]) - (x[2] - x[1]) * (y[1] - y[0]);
            int b = (x[2] - x[0]) * (y[3] - y[2]) - (x[3] - x[2]) * (y[2] - y[0]);
            int c = (x[3] - x[0]) * (y[1] - y[3]) - (x[1] - x[3]) * (y[3] - y[0]);*/
        }
    }
}

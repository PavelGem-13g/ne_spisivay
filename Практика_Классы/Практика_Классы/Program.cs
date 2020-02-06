using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_Классы
{
    class Point3D
    {
        public int x;
        public int y;
        public int z;
        public void startZerPos()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public void startUserPos(int userX, int userY, int userZ)
        {
            x = userX;
            y = userY;
            z = userZ;
        }
        public void movig(int moveX,int moveY, int moveZ)
        {
            x += moveX;
            y += moveY;
            z += moveZ;
        }
        public void output()
        {
            Console.WriteLine("x={0} y={1} z={2}",x,y,z);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Point3D point = new Point3D();
            int x=0, y=0, z=0;
            point.startZerPos();
            point.output();
            Console.WriteLine("Введите начальное x");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите начальное y");
            y = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите начальное z");
            z = int.Parse(Console.ReadLine());
            point.startUserPos(x, y, z);
            point.output();

            point.movig(5,0,0);
            point.output();
            Console.ReadKey();
        }
    }
}

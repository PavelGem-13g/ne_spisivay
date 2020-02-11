using System;

namespace Практика_Классы
{
    class Point3D
    {
        public int x;
        public int y;
        public int z;
        public void startPos()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public void startPos(int userX, int userY, int userZ)
        {
            x = userX;
            y = userY;
            z = userZ;
        }
        public void movig(int moveX, int moveY, int moveZ)
        {
            x += moveX;
            y += moveY;
            z += moveZ;
        }
        public void output()
        {
            Console.WriteLine("x={0} y={1} z={2}", x, y, z);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Point3D point = new Point3D();
            int x = 0, y = 0, z = 0, createPoint = 0, direct = 0, delta = 0;
            do
            {
                Console.Write("Введите способ создания точки: 1 - точка находится в пересечении координат, 2 - Вы сами вводите координату ");
                createPoint = int.Parse(Console.ReadLine());
            } while (!(0 < createPoint && createPoint < 3));
            if (createPoint == 1) point.startPos();
            else
            {
                Console.Write("Введите начальное x ");
                x = int.Parse(Console.ReadLine());
                Console.Write("Введите начальное y ");
                y = int.Parse(Console.ReadLine());
                Console.Write("Введите начальное z ");
                z = int.Parse(Console.ReadLine());
                point.startPos(x, y, z);
            }
            point.output();
            while (true)
            {
                Console.Write("Введите ось, по которой будет совершаться перемещение: 1 - x, 2 - y, 3 - z. Введите 0 для выхода из программы ");
                direct = int.Parse(Console.ReadLine());
                if (0 < direct && direct < 4)
                {
                    Console.Write("Введите насколько передвинется точка ");
                    delta = int.Parse(Console.ReadLine());
                }
                if (direct == 0) break;
                if (direct == 1) point.movig(delta, 0, 0);
                if (direct == 2) point.movig(0, delta, 0);
                if (direct == 3) point.movig(0, 0, delta);
                point.output();
            }
        }
    }
}

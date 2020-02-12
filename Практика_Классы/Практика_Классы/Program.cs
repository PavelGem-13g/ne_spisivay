using System;

namespace Практика_Классы
{
    class Point3D
    {
        private int x;
        private int y;
        private int z;
        public Point3D()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void movig(int direction, int delta)
        {
            switch (direction)
            {
                case 1: this.x += delta; break;
                case 2: this.y += delta; break;
                case 3: this.z += delta; break;
            }
        }
        public void output(int direction)
        {
            switch (direction)
            {
                case 1: Console.WriteLine("x={0}", x); break;
                case 2: Console.WriteLine("y={0}", y); break;
                case 3: Console.WriteLine("z={0}", z); break;
                default: Console.WriteLine("x={0} y={1} z={2}", x, y, z); ; break;
            }
        }
        public double rad()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        public Point3D sum(Point3D obj)
        {
            return new Point3D(obj.x + this.x, obj.y + this.y, obj.z + this.z);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Point3D point;
            int x, y, z, createPoint;
            do
            {
                Console.Write("Введите способ создания точки: 1 - точка находится в пересечении координат, 2 - Вы сами вводите координату (первая точка) ");
                createPoint = int.Parse(Console.ReadLine());
            } while (!(0 < createPoint && createPoint < 3));
            if (createPoint == 1) point = new Point3D();
            else
            {
                Console.Write("Введите начальное x ");
                x = int.Parse(Console.ReadLine());
                Console.Write("Введите начальное y ");
                y = int.Parse(Console.ReadLine());
                Console.Write("Введите начальное z ");
                z = int.Parse(Console.ReadLine());
                //point.startPos(x, y, z);
                point = new Point3D(x, y, z);
            }
            Console.Write("Первая точка "); point.output(0);


            Point3D point2;
            do
            {
                Console.Write("Введите способ создания точки: 1 - точка находится в пересечении координат, 2 - Вы сами вводите координату (вторая точка) ");
                createPoint = int.Parse(Console.ReadLine());
            } while (!(0 < createPoint && createPoint < 3));
            if (createPoint == 1) point2 = new Point3D();
            else
            {
                Console.Write("Введите начальное x ");
                x = int.Parse(Console.ReadLine());
                Console.Write("Введите начальное y ");
                y = int.Parse(Console.ReadLine());
                Console.Write("Введите начальное z ");
                z = int.Parse(Console.ReadLine());
                //point.startPos(x, y, z);
                point2 = new Point3D(x, y, z);
            }
            Console.Write("Вторая точка "); point2.output(0);

            Point3D sumPoint;
            int outdirect, direct, delta = 0;
            while (true)
            {
                Console.Write("Введите ось, по которой будет совершаться перемещение: 1 - x, 2 - y, 3 - z. Введите 0 для выхода из программы (первая точка)");
                direct = int.Parse(Console.ReadLine());
                if (direct == 0) break;
                if (0 < direct && direct < 4)
                {
                    Console.Write("Введите насколько передвинется точка ");
                    delta = int.Parse(Console.ReadLine());
                }
                point.movig(direct, delta);

                Console.Write("Введите ось, по которой будет совершаться перемещение: 1 - x, 2 - y, 3 - z. Введите 0 для выхода из программы (вторая точка)");
                direct = int.Parse(Console.ReadLine());
                if (direct == 0) break;
                if (0 < direct && direct < 4)
                {
                    Console.Write("Введите насколько передвинется точка ");
                    delta = int.Parse(Console.ReadLine());
                }
                point2.movig(direct, delta);

                Console.Write("Введите ось для вывода: 1 - x, 2 - y, 3 - z. Введите 0 для вывода всех переменных (первая точка)");
                outdirect = int.Parse(Console.ReadLine());
                point.output(outdirect);

                Console.Write("Введите ось для вывода: 1 - x, 2 - y, 3 - z. Введите 0 для вывода всех переменных (вторая точка)");
                outdirect = int.Parse(Console.ReadLine());
                point2.output(outdirect);

                Console.WriteLine("Радиус-вектор от начала координат {0} (первая точка)",point.rad());

                Console.WriteLine("Суммирование точек (вывод координат новой точки)");
                sumPoint = point.sum(point2);
                sumPoint.output(0);
            }

        }
    }
}

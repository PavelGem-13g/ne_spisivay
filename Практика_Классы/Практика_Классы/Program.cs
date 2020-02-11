using System;

namespace Практика_Классы
{
    class Point3D
    {
        private int x;
        private int y;
        private int z;
        public void startPos()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public void startPos(int x, int y, int z)
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
                case 1: Console.WriteLine("x={0}", x);break;
                case 2: Console.WriteLine("y={0}", y); break;
                case 3: Console.WriteLine("z={0}", z); break;
                default: Console.WriteLine("x={0} y={1} z={2}", x, y, z); ; break;
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Point3D point = new Point3D();
            int x, y, z, createPoint;
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
            point.output(0);
            int outdirect, direct, delta=0;
            while (true)
            {
                Console.Write("Введите ось, по которой будет совершаться перемещение: 1 - x, 2 - y, 3 - z. Введите 0 для выхода из программы ");
                direct = int.Parse(Console.ReadLine());
                if (direct == 0) break;
                if (0 < direct && direct < 4)
                {
                    Console.Write("Введите насколько передвинется точка ");
                    delta = int.Parse(Console.ReadLine());
                }
                
                point.movig(direct, delta);
                Console.Write("Введите ось для вывода: 1 - x, 2 - y, 3 - z. Введите 0 для вывода всех переменных ");
                outdirect = int.Parse(Console.ReadLine());
                point.output(outdirect);
            }
        }
    }
}

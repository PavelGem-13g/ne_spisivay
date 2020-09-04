using System;

namespace Практика_Наследование
{
    class DemoPoint
    {
        protected int x;
        protected int y;
        public DemoPoint()
        {
            x = 0;
            y = 0;
        }
        public DemoPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Show()
        {
            Console.WriteLine($"({x}, {y})");
        }
    }
    class DemoLine : DemoPoint
    {
        int x1;
        int y1;
        public DemoLine(int x, int y, int x1, int y1) : base(x, y)
        {
            this.x1 = x1;
            this.y1 = y1;
        }
        public DemoLine() : base()
        {
            this.x1 = 0;
            this.y1 = 0;
        }
        new public void Show()
        {
            Console.WriteLine($"({base.x}, {base.y})*({x1},{x1})");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int choose;
            Console.WriteLine("1-создать свою точку, другое число - конструктор по умолчанию");
            choose = int.Parse(Console.ReadLine());
            DemoPoint point;
            int x, y;
            if (choose == 1)
            {
                Console.WriteLine("Введите x");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите y");
                y = int.Parse(Console.ReadLine());

                point = new DemoPoint(x, y);
            }
            else
            {
                point = new DemoPoint();
                x = 0;
                y = 0;
            }
            Console.Write("Значение первой точки ");
            point.Show();

            Console.WriteLine("1-создать свою линию, другое число - конструктор по умолчанию");
            choose = int.Parse(Console.ReadLine());
            DemoLine line;
            int x1, y1;
            if (choose == 1)
            {
                Console.WriteLine("Введите x");
                x1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите y");
                y1 = int.Parse(Console.ReadLine());
                line = new DemoLine(x, y, x1, y1);
            }
            else line = new DemoLine();
            Console.Write("Значение линии ");
            line.Show();
            Console.ReadKey();
        }
    }
}

using System;
namespace Фоновая_4._1_вар7
{
    class Eleps
    {
        private double a;
        private double b;
        public Eleps(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public Eleps()
        {
            this.a = 5;
            this.b = 2;
        }
        private double excantiatet()
        {
            return Math.Sqrt(1 - ((b / 2 * b / 2) / (a / 2 * a / 2)));
        }
        public double focalParam()
        {
            return (b / 2 * b / 2) / a / 2;
        }
        public double S()
        {
            return Math.PI * a * b;
        }
        public double P()
        {
            return 4 * (Math.PI * a * b + (a - b) * (a - b) / (a + b));
        }
        public double A()
        {
            return a;
        }
        public double B()
        {
            return b;
        }
        public double radius(double z)
        {
            return b / Math.Sqrt(1 - excantiatet() * excantiatet() * Math.Cos(z) * Math.Cos(z));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            Eleps oval;
            Console.Write("Использовать стандартный конструктор, 1-да, другая цифра-нет ");
            int construction = int.Parse(Console.ReadLine());
            if (construction != 1)
            {
                Console.Write("Введите длину оси a ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Введите длину оси b ");
                b = double.Parse(Console.ReadLine());
                oval = new Eleps(a, b); 
            }
            else oval = new Eleps();

            Console.WriteLine("Фокальный параметр эллипса {0:F3}", oval.focalParam());
            Console.WriteLine("Площадь  {0:F3}", oval.S());
            Console.WriteLine("Периметр  {0:F3}", oval.P());
            Console.Write("Введите угол (для радиуса) ");
            double ugol = double.Parse(Console.ReadLine());
            Console.WriteLine("Радиус  {0:F3}", oval.radius(ugol));
            int choseAB;
            do
            {
                Console.WriteLine("Получить a-1 или b-2");
                choseAB = int.Parse(Console.ReadLine());
            } while (!(0< choseAB && choseAB<3));
            if (choseAB == 1) Console.WriteLine("а = {0}",oval.A());
            if (choseAB == 2) Console.WriteLine("b = {0}", oval.B());
            Console.ReadKey();
        }
    }
}

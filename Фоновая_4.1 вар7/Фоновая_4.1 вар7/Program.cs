using System;
namespace Фоновая_4._1_вар7
{
    class Eleps
    {
        private double a;
        private double b;
        public Eleps(double fullA, double fullB)
        {
            this.a = fullA / 2;
            this.b = fullB / 2;
        }
        public Eleps()
        {
            this.a = 5;
            this.b = 2;
        }
        public double A
        {
            set
            {
                try { a = value; }
                catch (FormatException)
                {
                    Console.WriteLine("Введено не число");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введено слишком большое число");
                }
            }
            get { return a - 2; }
        }
        public double B
        {
            set
            {
                try
                {
                    if (value > 100) throw new Exception("Введено слишком большое значение");
                    b = value;
                }
                catch (Exception error) { Console.WriteLine("Ошибка: {0}", error.Message); }
            }
            get { return b - 2; }
        }
        private double excantiatet
        {
            get { return Math.Sqrt(1 - ((b * b) / (a * a))); }
        }
        public double focalParam()
        {
            return (b * b) / a;
        }
        public double S
        {
            get { return Math.PI * a * b; }
        }
        public double P
        {
            get { return (4 * (Math.PI * a * b + (a - b) * (a - b))) / (a + b); }
        }
        public double szhatie
        {
            get { return b / a; }
        }
        public double focalL
        {
            get { return a * excantiatet; }
        }
        public double preF
        {
            get { return a * (1 - excantiatet); }
        }
        public double apoF
        {
            get { return a * (1 + excantiatet); }
        }
        public double radius(double z)
        {
            try
            {
                if ((b) / Math.Sqrt(1.00 - excantiatet * excantiatet * Math.Cos(z) * Math.Cos(z)) > 0) return (b) / Math.Sqrt(1.00 - excantiatet * excantiatet * Math.Cos(z) * Math.Cos(z));
                else throw new Exception("Радиус не существует, значение равно 0");
            }
            catch (Exception error) { Console.WriteLine("Ошибка: {0}", error.Message); return 0; }
        }
        public bool crug
        {
<<<<<<< HEAD
            get { return a == b; }
=======
            get{return a==b;}
            
        }
>>>>>>> 073f9008829745271e9ab2a8473be84da0c4200a

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, construction = 1;
            Eleps oval;
            Console.Write("Использовать стандартный конструктор, да-1, нет-другая цифра ");
            try { construction = int.Parse(Console.ReadLine()); }
            catch (FormatException)
            {
<<<<<<< HEAD
                Console.WriteLine("Введено не число, используется стандартный конструктор");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введено слишком большое число, используется стандартный конструктор");
=======
                double a, b,construction=1;
                Eleps oval;
                Console.Write("Использовать стандартный конструктор, да-1, нет-другая цифра ");
                 try{construction= int.Parse(Console.ReadLine());}
                 catch (FormatException)
                {
                    Console.WriteLine("Введено не число, используется стандартный конструктор");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введено слишком большое число, используется стандартный конструктор");
                }
                if (construction != 1)
                {
                    Console.Write("Введите длину (большей) оси a ");
                    a = double.Parse(Console.ReadLine());
                    Console.Write("Введите длину (меньшей) оси b ");
                    b = double.Parse(Console.ReadLine());
                    oval = new Eleps(a, b);
                }
                else oval = new Eleps();

                Console.WriteLine("Фокальный параметр эллипса {0:F3}", oval.focalParam());
                Console.WriteLine("Площадь  {0:F3}", oval.S());
                Console.WriteLine("Периметр  {0:F3}", oval.P());
                Console.Write("Введите угол (для радиуса) ");
                double ugol = double.Parse(Console.ReadLine());
                // 57.2958)
                Console.WriteLine("Радиус  {0:F3}", oval.radius(ugol * Math.PI / 180));
                int choseAB;
                do
                {
                    Console.WriteLine("Получить a-1 или b-2");
                    choseAB = int.Parse(Console.ReadLine());
                } while (!(0 < choseAB && choseAB < 3));
                if (choseAB == 1) Console.WriteLine("а = {0}", oval.A());
                if (choseAB == 2) Console.WriteLine("b = {0}", oval.B());
                if (oval.crug==true)Console.WriteLine("Элипс - круг");
                else Console.WriteLine("Элипс не круг");
                Console.WriteLine("Коэффицен сжатия {0}",oval.szhatie);
                Console.WriteLine("Фокальная длина {0}",oval.focalL);
                Console.WriteLine("Перифокусное расстояние {0}",oval.preF);
                Console.WriteLine("Апофокусное расстояние {0}",oval.apoF);
                Console.ReadKey();
>>>>>>> 073f9008829745271e9ab2a8473be84da0c4200a
            }
            if (construction != 1)
            {
                Console.Write("Введите длину (большей) оси a ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Введите длину (меньшей) оси b ");
                b = double.Parse(Console.ReadLine());
                oval = new Eleps(a, b);
            }
            else oval = new Eleps();

            Console.WriteLine("Фокальный параметр эллипса {0:F3}", oval.focalParam());
            Console.WriteLine("Площадь  {0:F3}", oval.S);
            Console.WriteLine("Периметр  {0:F3}", oval.P);
            Console.Write("Введите угол (для радиуса) ");
            double ugol = double.Parse(Console.ReadLine());
            // 57.2958)
            Console.WriteLine("Радиус  {0:F3}", oval.radius(ugol * Math.PI / 180));
            int choseAB;
            do
            {
                Console.WriteLine("Получить a-1 или b-2");
                choseAB = int.Parse(Console.ReadLine());
            } while (!(0 < choseAB && choseAB < 3));
            if (choseAB == 1) Console.WriteLine("а = {0}", oval.A);
            if (choseAB == 2) Console.WriteLine("b = {0}", oval.B);
            if (oval.crug == true) Console.WriteLine("Элипс - круг");
            else Console.WriteLine("Элипс не круг");
            Console.WriteLine("Коэффицен сжатия {0}", oval.szhatie);
            Console.WriteLine("Фокальная длина {0}", oval.focalL);
            Console.WriteLine("Перифокусное расстояние {0}", oval.preF);
            Console.WriteLine("Апофокусное расстояние {0}", oval.apoF);
            Console.ReadKey();
        }
    }
}

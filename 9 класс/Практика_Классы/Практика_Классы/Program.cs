using System;

namespace Практика_Классы
{
    class Point3D
    {
        private double x;
        private double y;
        private double z;
        public Point3D()
        {
            x = 5;
            y = 5;
            z = 5;
        }
        public Point3D(double x, double y, double z)
        {

            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static Point3D dot(int x, int y, int z)
        {
            Console.WriteLine("Создайте точку, у которой хотя бы одна координата кратна 5");
            //point.startPos(x, y, z);               
            try
            {
                if (!(x % 5 == 0 || y % 5 == 0 || z % 5 == 0)) throw new Exception("Введены числа некратные 5, использован конструктор по умолчанию");
            }
            catch(Exception error)
            {
                Console.WriteLine("Ошибка: {0}", error.Message);
                return new Point3D();
            }
            catch
            {
                Console.WriteLine("Ошибка, использован конструктор по умолчанию");
                return new Point3D();
            }
            return new Point3D(x, y, z);
        }
    public void movig(int direction, int delta)
    {
        switch (direction)
        {
            case 1: this.X += delta; break;
            case 2: this.Y += delta; break;
            case 3: this.Z += delta; break;
        }
    }
    public double X
    {
        get { return this.x; }

        set
        {
            try { if (value > 0) throw new Exception("Значение меньше нуля!"); this.x += value; }
            catch (Exception error) { Console.WriteLine("Ошибка: {0}", error.Message); }
        }
    }
    public double Y
    {
        get { return this.y; }
        set
        {

            try
            {
                if (!(0 < value && value <= 100))
                {
                    y = 100;
                    throw new Exception("Значение не воходит диапазон 0-100? установлено максимальное значение");

                }
                this.y += value;
            }
            catch (Exception error) { Console.WriteLine("Ошибка: {0}", error.Message); }

                try{if (!(0 < value && value <= 100)) throw new Exception("Значение не воходит диапазон 0-100? установлено максимальное значение");this.y += value;}
                catch(Exception error){Console.WriteLine("Ошибка: {0}", error.Message);y = 100;} 

            }
        }
        public double Z
        {
            get { return this.z; }
            set
            {
                try { if (!(this.x + this.y > value)) throw new Exception("Значение не воходит больше суммы x и y, значение не изменено"); this.z += value; }
                catch (Exception error) { Console.WriteLine(error.Message); }
                try{if(!(this.x + this.y > value))throw new Exception("Значение не воходит больше суммы x и y, значение не изменено");this.z += value;}
                catch(Exception error){Console.WriteLine(error.Message);}
            }
        }
        public double multiplication
        {
            set
            {
                this.x *= value;
                this.y *= value;
                this.z *= value;
            }
        }

        public void output()
        {
            Console.WriteLine("x={0} y={1} z={2}", x, y, z);
        }
        public double rad()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        public Point3D sum(Point3D obj)
        {
            return new Point3D(obj.x + this.x, obj.y + this.y, obj.z + this.z);
        }
        public Point3D sum(int delta)
        {
            return new Point3D(this.x + delta, this.y + delta, this.z + delta);
        }
        public Point3D sum(double delta)
        {
            return new Point3D(x + delta, this.y + delta, this.z + delta);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Point3D point;
            int x, y, z, createPoint = 0;
            do
            {
                try
                {
                    Console.Write("Введите способ создания точки: 1 - точка находится в пересечении координат, 2 - Вы сами вводите координату (первая точка) ");
                    createPoint = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено не число");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введено слишком большое число");
                }
            } while (!(0 < createPoint && createPoint < 3));
            if (createPoint == 1) point = new Point3D();
            else
            {
                Console.WriteLine("Создайте точку, у которой хотя бы одна координата кратна 5");
                Console.Write("Введите начальное x ");
                x = int.Parse(Console.ReadLine());
                Console.Write("Введите начальное y ");
                y = int.Parse(Console.ReadLine());
                Console.Write("Введите начальное z ");
                z = int.Parse(Console.ReadLine());
                //point.startPos(x, y, z);               
                try
                {
                    if (!(x % 5 == 0 || y % 5 == 0 || z % 5 == 0)) throw new Exception("Введены числа некратные 5, все числа умножаны на 5");
                }
                catch (Exception error)
                {
                    Console.WriteLine("Ошибка: {0}", error.Message);
                    x = x * 5;
                    y = y * 5;
                    z = z * 5;
                }
                point = new Point3D(x, y, z);
            }
            Console.Write("Первая точка "); point.output();

            Point3D point2;
            createPoint = 0;
            do
            {
                try
                {
                    Console.Write("Введите способ создания точки: 1 - точка находится в пересечении координат, 2 - Вы сами вводите координату (вторая точка) ");
                    createPoint = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено не число");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введено слишком большое число");
                }

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
                try
                {
                    if (!(x % 5 == 0 && y % 5 == 0 && z % 5 == 0)) throw new Exception("Введены числа некратные 5, все числа умножаны на 5");
                }
                catch (Exception error)
                {
                    Console.WriteLine("Ошибка: {0}", error.Message);
                    x = x * 5;
                    y = y * 5;
                    z = z * 5;
                }
                point2 = new Point3D(x, y, z);
            }
            Console.Write("Вторая точка "); point2.output();

            Point3D sumPoint;
            int direct, delta = 0;
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
                point.output();

                Console.WriteLine("Введите в сколько раз умножить коордитану точки(точка 1)");
                int multi = int.Parse(Console.ReadLine());
                point.multiplication = multi;
                point.output();

                Console.Write("Введите ось, по которой будет совершаться перемещение: 1 - x, 2 - y, 3 - z. Введите 0 для выхода из программы (вторая точка)");
                direct = int.Parse(Console.ReadLine());
                if (direct == 0) break;
                if (0 < direct && direct < 4)
                {
                    Console.Write("Введите насколько передвинется точка ");
                    delta = int.Parse(Console.ReadLine());
                }
                point2.movig(direct, delta);
                point2.output();

                Console.WriteLine("Радиус-вектор от начала координат {0} (первая точка)", point.rad());

                Console.WriteLine("Введите метод суммирования точек: 1-сложение двух точек, другое число - сложение кооодинат с определенным числом, 2 - сложение с целочисленным чилом");
                int chooseSum = int.Parse(Console.ReadLine());
                if (chooseSum == 1)
                {
                    Console.WriteLine("Суммирование точек (вывод координат новой точки)");
                    sumPoint = point.sum(point2);
                }
                else if (chooseSum == 2)
                {
                    double deltaSumDouble = int.Parse(Console.ReadLine());
                    sumPoint = point.sum(deltaSumDouble);

                }
                else
                {
                    Console.WriteLine("Введите на какое число сместить все координаты");
                    int deltaSum = int.Parse(Console.ReadLine());
                    sumPoint = point.sum(deltaSum);
                }
                Console.WriteLine();

                sumPoint.output();
            }

        }
    }
}

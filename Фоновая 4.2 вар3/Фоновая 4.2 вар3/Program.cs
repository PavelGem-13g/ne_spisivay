using System;

namespace Фоновая_4._2_вар3
{
    class MatrixWeather
    {
        int month;
        int day;
        int[,] temperature;
        static int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public MatrixWeather()
        {
            day = 1;
            month = 1;
            temperature = new int[6, 7];
            temperature = rndArr();
        }

        public MatrixWeather(int day, int month)
        {
            this.day = day;
            this.month = month;
            temperature = new int[6, 7];
            temperature = rndArr();
        }
        public static MatrixWeather creating(int day, int month)
        {
            MatrixWeather weather;
            if (day > 0 && month > 0)
            {
                weather = new MatrixWeather(day, month);
            }
            else weather = new MatrixWeather();
            return weather;
        }
        int[,] rndArr(MatrixWeather weather)
        {
            int[,] Arr = weather.temperature;
            Random rnd = new Random();
            for (int j = 0; j < Arr.GetLength(0); j++)
            {
                for (int i = 0; i < Arr.GetLength(1); i++)
                {
                    Arr[i, j] = rnd.Next();
                }

            }
            return Arr;
        }
        int[,] rndArr()
        {
            int[,] Arr = new int[6,7];
            Random rnd = new Random();
            for (int j = 0; j < Arr.GetLength(0); j++)
            {
                for (int i = 0; i < Arr.GetLength(1); i++)
                {
                    Arr[i, j] = rnd.Next();
                }

            }
            return Arr;
        }
        public void output()
        {
            int k = 0;
            Months mon = (Months)month;
            Console.WriteLine(mon);
            Console.WriteLine("Пн\tВт\tСр\tЧт\tПт\tСб\tВс\t");
            for (int i = 0; i < day - 1; i++, k++) Console.WriteLine();
            for (int i = 0; i < months[month]; i++, k++)
            {
                for (int j = 0; j <= months[month]; i++, k++)
                {
                    if (k % 7 == 0 && i != 1) Console.Write("\n");
                    Console.Write("{0:D2}", i);
                    Console.Write("  {0}\t", this.temperature[k / 7, k % 7]);
                }
                Console.Write("\n");
            }
        }
        void moveR()
        {
            int temp1 = temperature[0, temperature.GetLength(1) - 1], temp2;
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                temp2 = temperature[i, temperature.GetLength(1) - 1];
                for (int j = temperature.GetLength(0); j > 0; j--) temperature[i, j] = temperature[i, j - 1];
                temperature[i, 0] = temp1;
                temp1 = temp2;
            }
        }
        void moveL()
        {
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                if (i != 0) temperature[i - 1, temperature.GetLength(1) - 1] = temperature[i, 0];
                for (int j = 0; j < temperature.GetLength(0); j++) temperature[i, j] = temperature[i, j + 1];
            }
        }
        public int skach(out int num, out int temp)
        {
            int max = 0, k = 0;
            num = 0;
            temp = 0;
            for (int i = 0; i < temperature.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < temperature.GetLength(1) - 1; j++)
                {
                    k++;
                    if (i == 0 && j == 0) j = day - 1;
                    if (k > months[month]) break;
                    if (j == temperature.GetLength(1) - 1)
                    {
                        if (Math.Abs(temperature[i, j] - temperature[i + 1, 0]) > max)
                        {
                            max = Math.Abs(temperature[i, j] - temperature[i + 1, 0]);
                            temp = temperature[i, j];
                            num = k;
                        }
                    }
                    else
                    {
                        if (Math.Abs(temperature[i, j] - temperature[i, j + 1]) > max)
                        {
                            max = Math.Abs(temperature[i, j] - temperature[i, j + 1]);
                            temp = temperature[i, j];
                            num = k;
                        }
                    }
                }
            }
            return max;
        }
        public int Day
        {
            set
            {
                int t = day;
                int[,] newArr = new int[temperature.GetLength(1), temperature.GetLength(1)];
                Array.Copy(temperature, 0, newArr, 0, temperature.Length);
                temperature = newArr;
                day = value;
                if (day > t) for (; t < day; t++) moveR();
                else for (; t > day; t--) moveL();
                if (day + months[month] - 1 == 28)
                {
                    newArr = new int[4, 7];
                    Array.Copy(temperature, 0, newArr, 0, temperature.Length);
                    temperature = newArr;
                }
                if (day + months[month] - 1 > 28 && day + months[month] - 1 <= 35)
                {
                    newArr = new int[5, 7];
                    Array.Copy(temperature, 0, newArr, 0, temperature.Length);
                    temperature = newArr;
                }
                if (day + months[month] - 1 > 35)
                {
                    newArr = new int[6, 7];
                    Array.Copy(temperature, 0, newArr, 0, temperature.Length);
                    temperature = newArr;
                }
            }
            get { return day; }
        }
        public int Month
        { 
            set
            {
                try
                {
                    if (value < 1 || value > 12) throw new Exception("Не существует такого месяца");
                    else
                    {
                        month = value;
                        temperature = rndArr();
                    }
                }
                catch (Exception error) { Console.WriteLine("Ошибка : {0}",error.Message); }
            }
            get { return month; }
        }
        public int[,] Temperature
        {
            get { return temperature; }
        }
        public int SchoolDay
        {
            get
            {
                return months[month] - (months[month] + day - 1) / 7;
            }
        }
        public int NullDays
        {
            get
            {
                int k = 0, l = 0;
                for (int i = 0; i < (this.day - 1); i++) k++;
                for (int i = 1; i <= months[this.month]; i++, k++) if (this.temperature[k / 7, k % 7] == 0) l++;
                return l;
            }
        }
    }
    enum Months { январь = 0, февраль, март, апрель, май, июнь, июль, август, сенябрь, октябрь, ноябрь, декабрь };

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}


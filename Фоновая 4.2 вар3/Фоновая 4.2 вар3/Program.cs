using System;

namespace Фоновая_4._2_вар3
{
    class MatrixWeather
    {
        int month;
        int day;
        int[,] temperature;
        static int[] months = { 0, 29, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public MatrixWeather()
        {
            day = 2;
            month = 2;
            temperature = new int[6, 7];
        }

        public MatrixWeather(int day, int month)
        {

            this.day = day;
            this.month = month;
            temperature = new int[6, 7];
        }
        public static MatrixWeather creating(int day, int month)
        {
            MatrixWeather weather;
            if (day > 0 && month > 0) weather = new MatrixWeather(day, month);
            else weather = new MatrixWeather();
            weather.temperature = rndArr(weather);
            return weather;
        }
        /*        static MatrixWeather rndTemp()
                {
                    MatrixWeather weather;
                    if (day > 0 && month > 0)
                    {
                        weather = new MatrixWeather(day, month);
                    }
                    else weather = new MatrixWeather();
                    return weather;
                }*/
        static int[,] rndArr(MatrixWeather weather)
        {
            int[,] Arr = weather.temperature;
            Random rnd = new Random();
            for (int j = 0; j < Arr.GetLength(0) - 1; j++)
            {
                for (int i = 0; i < Arr.GetLength(1) - 1; i++)
                {
                    Arr[i, j] = rnd.Next(1, 20);
                }

            }
            return Arr;
        }
        int[,] rndArr()
        {
            int[,] Arr = new int[6, 7];
            Random rnd = new Random();
            for (int j = 0; j < Arr.GetLength(0) - 1; j++)
            {
                for (int i = 0; i < Arr.GetLength(1) - 1; i++)
                {
                    Arr[i, j] = rnd.Next(1, 20);
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
            for (int i = 0; i < day - 1; i++) { Console.Write("\t"); k++; };
            for (int i = 1; i < months[month]; i++, k++)
            {
                for (int j = 0; j <= months[month] + 1; i++, k++)
                {
                    if (k % 7 == 0 && i != 1) Console.Write("\n");
                    Console.Write("{0:D2}", i);
                    Console.Write("  {0}\t", this.temperature[k / 7, k % 7]);
                    if (k - 1 > months[month] - 1) break;
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
                for (int j = temperature.GetLength(0) - 1; j > 0; j--) temperature[i, j] = temperature[i, j - 1];
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
        public int skach(out int dayNum, out int t)
        {
            int max = 0, k = 0;
            dayNum = 0;
            t = 0;
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
                            t = temperature[i, j];
                            dayNum = k;
                        }
                    }
                    else
                    {
                        if (Math.Abs(temperature[i, j] - temperature[i, j + 1]) > max)
                        {
                            max = Math.Abs(temperature[i, j] - temperature[i, j + 1]);
                            t = temperature[i, j];
                            dayNum = k;
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
                /*                if (day + months[month] - 1 == 28)
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
                                {*/
                newArr = new int[6, 7];
                Array.Copy(temperature, 0, newArr, 0, temperature.Length - 1);
                temperature = newArr;
                //}
            }
            get { return day; }
        }
        public int Month
        {
            set
            {
                month = value;
            }
            get { return month; }
        }
        public int[,] Temperature
        {
            get { return temperature; }
        }
        public int WorkDay
        {
            get
            {
                return months[month] - (months[month] + day - 1) / 7;
            }
        }
        /* public void output()
         {
             int k=0;
             for (int j = 0; j < temperature.GetLength(1); j++) 
             { 
                 for (int i = 0; i < 8; i++) 
                 {
                     if(temperature[i,j]>Int32.MinValue)
                     {
                     k++;
                         Console.WriteLine(k);
                     }
                     Console.WriteLine(temperature[i,j]);
                 }

             }

         }*/
        public int WaterToIceDays
        {
            get
            {
                int k = 0, l = 0;
                for (int i = 0; i < (this.day - 1); i++) k++;
                for (int i = 1; i <= months[this.month]; i++, k++) if (this.temperature[k / 7, k % 7] == 0) l++;
                return l;
            }
        }

        /*        public int scach()
                {
                    int max = 0, maxTemp = 0; ;
                    for (int j = 0; j < temperature.GetLength(1) - 2; j++)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            maxTemp = Math.Abs(Math.Abs(temperature[i, j]) - Math.Abs(temperature[i + 1, j + 1]));
                        }
                        if (maxTemp > max) max = maxTemp;
                    }
                    return max;
                }*/
        public static bool operator >(MatrixWeather a, MatrixWeather b)
        {
            if (a.Month > b.Month) return true;
            else return false;
        }
        public static bool operator <(MatrixWeather a, MatrixWeather b)
        {
            if (a.Month < b.Month) return true;
            else return false;
        }
        public static MatrixWeather operator ++(MatrixWeather weather)
        {
            if (weather.Day == 7) weather.Day = 1;
            else weather.Day++;
            return weather;
        }
        public static MatrixWeather operator --(MatrixWeather weather)
        {
            if (weather.Day == 1) weather.Day = 7;
            else weather.Day--;
            return weather;
        }
        public static bool operator true(MatrixWeather weather)
        {
            if (weather.WaterToIceDays > 0) return true;
            else return false;
        }
        public static bool operator false(MatrixWeather weather)
        {
            if (weather.WaterToIceDays == 0) return true;
            else return false;
        }
        public static bool operator &(MatrixWeather a, MatrixWeather b)
        {
            int k = 0;
            if (a.Month != b.Month) return false;
            if (a.Day != b.Day) return false;
            for (int i = 0; i < a.temperature.Length - 1; i++)
            {
                for (int j = 0; j < a.temperature.Length - 1; j++)
                    if (a.temperature[i, j] == a.temperature[i, j]) k++;
            }
            if (k == 42) return true;
            else return false;
        }
        public int this[int i, int j]
        {
            get
            {
                try
                {
                    if (Day < i && j == 1) throw new Exception("Ошибка: день не существует");
                    if (i * j - day > months[Month]) throw new Exception("Ошибка: день не существует");
                    if (i * j - day <= months[Month]) return temperature[i, j];
                    return -1000;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    return -1000;
                }
            }
        }

    }
    enum Months { январь = 1, февраль, март, апрель, май, июнь, июль, август, сенябрь, октябрь, ноябрь, декабрь };

    class Program
    {
        static void Main(string[] args)
        {
            MatrixWeather weather;
            int day = 0, month = 0;
            Console.Write("Создать свою сетку погоды - 1, стандартный конструктор - 0: ");
            int cooseWeather = Convert.ToInt32(Console.ReadLine());
            if (cooseWeather == 1)
            {
                Console.Write("Введите день ");
                day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите месяц ");
                month = Convert.ToInt32(Console.ReadLine());

            }
            weather = MatrixWeather.creating(day, month);
            weather.output();
            int dayNum, t;
            int maxSkach = weather.skach(out dayNum, out t);
            Console.WriteLine("Самый большой суточный скачок температуры — {0}, он произошел в {1} день, температура которго составляла {2}", maxSkach, dayNum, t);
            Console.WriteLine("Кол-во дней в дневнике {0}", weather.WorkDay);
            Console.WriteLine("Кол-во дней c t=0", weather.WaterToIceDays);
            int chooseChange = 1;
            int chooseDay=0;
            int chooseMonth=0;
            while (0 < chooseChange && chooseChange < 5)
            {
                Console.Write("Изменить месяц - 1, изменить день - 2, вывод календаря - 3, вывести температурное значение - 5, выход из программы - любое число ");
                chooseChange = int.Parse(Console.ReadLine());
                if (chooseChange == 1)
                {
                    Console.Write("Введите месяц : ");
                    weather.Month = int.Parse(Console.ReadLine());
                    weather = MatrixWeather.creating(weather.Day, weather.Month);//так нельзя, но вроде должно работать
                }
                if (chooseChange == 2)
                {
                    Console.Write("Введите день : ");
                    weather.Day = int.Parse(Console.ReadLine());
                    weather = MatrixWeather.creating(weather.Day, weather.Month);
                }
                if (chooseChange == 3)
                {
                    weather.output();
                }
                if (chooseChange == 4)
                {
                    try
                    {
                        Console.Write("Введите день недели");
                        chooseDay = int.Parse(Console.ReadLine());
                        Console.Write("Введите неделю");
                        chooseDay = int.Parse(Console.ReadLine());
                        if (weather[chooseDay, chooseMonth] != -1000) Console.WriteLine("Значение дня {0}", weather[chooseDay, chooseMonth]);
                        else Console.WriteLine("Этот день не существует");
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
            }
            Console.ReadKey();
        }

    }
}


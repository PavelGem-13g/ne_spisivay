
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_6__2
{
    class Program
    {
        public static int kolich(int c)
        {
            int a;
            int k1 = 0;
            while (c > 0)
            {
                a = c % 10;
                if (a < 8 && (a % 3 != 0 && a % 4 != 0))k1++;
                c /= 10;
            }
            return k1;
        }

        static int chetsum(int c)
        {
            int a, b, S = 0;
            while (c > 0)
            {
                a = c % 10;
                b = (c / 10) % 10;
                if ((a + b) % 2 == 0) S += a + b;
                //Console.WriteLine($"{a} {b} {S}");
                c = c / 10;
                if (c < 10) break;
            }
            return S;
        }

        static int Schastie(int c)
        {

            int a, b, n = c, S1 = 0,S2=0, k1 = 0,z=c;
            while (n > 0)
            {
                n = n / 10;
                k1++;
            }

            int k = k1/2;

            for (int i = 0; k > i; i++)
            {
                a = c % 10;
                b = (c/10)% 10;
                 S1 += a + b;
                z = z/10;
                //Console.WriteLine($"{a} {b} {S}");
                //if ((a + b) % 2 == 0)
            }
            for (int i = 0; k > i; i++)
                { 
                a = c % 10;
                b = (c / 10) % 10;
                S2 += a + b;
                z = z / 10;
            //Console.WriteLine($"{a} {b} {S}");
            //if ((a + b) % 2 == 0)
                }
            int rezult = S1 - S2;
            if (k1 % 2 != 0) rezult = 1;
                return rezult;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число ");
            int N = int.Parse(Console.ReadLine());
            //задача 1 
            if (kolich(N) > 0) Console.WriteLine("Итог задачи №1 " + kolich(N));
            else Console.WriteLine("Итог задачи №1 No");
            //задача 2
            Console.WriteLine("Итог задачи №2 " + chetsum(N));
            //задача 3 
            if (Schastie(N) == 0) Console.WriteLine("Итог задачи №3 счастливое");
            else Console.WriteLine("Итог задачи №3 не счастливое");
            Console.ReadKey();

        }
    }
}

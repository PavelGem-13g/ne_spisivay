using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_6_3
{
    class Program
    {
        public static int soversh (int n)
            {
            int SUM = 0;
            for (int i = 1; i < n ; i++)
                {
                if (n % i == 0) SUM += i;
                }
            return SUM;
            }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int N = int.Parse(Console.ReadLine());
            int sum = soversh(N);
            if (N == sum) Console.WriteLine($"{N} совершенное число");
            else Console.WriteLine($"{N} не совершенное число");
            Console.ReadKey();
        }
    }
}

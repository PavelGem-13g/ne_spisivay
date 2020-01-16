using System;

namespace Фоновая_3_4_2
{
    class Program
    {
        static int[][] InputArray()
        {
            Console.Write("Введите количество строк ");
            int n = int.Parse(Console.ReadLine());
            int[][] mas;
            mas = new int[n][];
            string[] s;
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write("Введите кол-во элементов в {0} строке ", i+1);
                mas[i] = new int[int.Parse(Console.ReadLine())];

                Console.Write("Введите элементы через пробел: ");
                s = Console.ReadLine().Split(new char[] { ' ' });
                int j = 0;
                foreach (string index in s)
                {
                    mas[i][j] = int.Parse(index);
                    j++;
                }

            }
            return mas;
        }

        static void outPut(int[][] a)
        {
            foreach (int[] xx in a)
            {
                foreach (int x in xx) Console.Write("{0} ", x);
                Console.WriteLine();
            }
        }

        public static int maxLeng(int[][] mas)
        {
            int max = -1;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].Length > max) max = mas[i].Length;
            }
            return max;
        }
        public static void sumMas(int[][] mas)
        {
            int sum = 0;
            for (int j = 0; j < maxLeng(mas); j++)
            {
                for (int i = 0; i < mas.Length; i++) if (j < mas[i].Length) sum += mas[i][j];
                Console.WriteLine("Сумма элементов {0} столбца = {1}", j, sum);
                sum = 0;
            }
        }

        public static int[] mines(int[][] mas)
        {
            int Leng = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    if (mas[i][j] > 0) Leng++;
                }
            }
            int[] minmas;
            if (Leng > 2)
            {
                minmas = new int[Leng];
                for (int imas = 0; imas < Leng; imas++)
                {
                    for (int i = 0; i < mas.Length; i++)
                    {
                        for (int j = 0; j < mas[i].Length; j++)
                        {
                            if (mas[i][j] < 0) minmas[i] = mas[i][j];
                        }
                    }
                }
                Array.Sort(minmas);
            }
            else
            {
                minmas = new int[1];
                minmas[0] = 1;
            }
            return minmas;
        }
        public static void outOne(int[] mas)
        {
            Console.Write("\nЭлементы меньшие нуля :");
            for (int i = 0; i < mas.Length; i++) 
            {
                Console.Write(mas[i]+" ");
            }
        }
        static void Minus(int[][] mas)
        {
            int k = 0;
            foreach (int[] i in mas)for (int j = 0; j < i.Length; j++)if (0>i[j])k++;
            if (k == 0) Console.WriteLine("В массиве нет отрицательных элементов");
            if (k == 1)Console.WriteLine("В массиве только 1 отрицательный элемент");
            if (k != 0 && k != 1) 
            { 
                int[] arrayOfMinus = new int[k];
                k = 0;
                foreach (int[] i in mas)
                {
                    for (int j = 0; j < i.Length; j++)
                    {
                        if (i[j] < 0)
                        {
                            arrayOfMinus[k] = i[j];
                            k++;
                        }
                    }
                }
                Array.Sort(arrayOfMinus);
                Console.WriteLine();
                outOne(arrayOfMinus);
            }
        }
        static void Main(string[] args)
        {
            int[][] mas = InputArray();
            outPut(mas);
            sumMas(mas);
            Minus(mas);
            Console.ReadKey();
        }
    }
}

using System;
namespace Практика_Структуры
{

    public class Program
    {
        public struct TMovie
        {
            public string Author;
            public string Name;
            public int Year;
            public int PlayTime;
        }
        public static TMovie inputStruct()
        {
            TMovie input;
            input.Author = Console.ReadLine();
            input.Name = Console.ReadLine();
            input.Year = int.Parse(Console.ReadLine());
            input.PlayTime = int.Parse(Console.ReadLine());
            return input;
        }
        public static void outputStruct(TMovie output)
        {
            Console.WriteLine("Режисер:{0}\nНазвание:{1}\nГод выпуска:{2}\n", output.Author, output.Name, output.Year);
        }
        public static void outputTime(TMovie time)
        {
            int minutes = time.PlayTime % 60;
            int hors = (time.PlayTime - minutes) / 60;
            Console.Write("Время просмотра:{0}мин или {1}ч и {2}мин", time.PlayTime, hors, minutes);
        }
        public static void Main(string[] args)
        {
            TMovie film;
            film = inputStruct();
            outputStruct(film);
            outputTime(film);
            Console.ReadKey();
        }
    }
}
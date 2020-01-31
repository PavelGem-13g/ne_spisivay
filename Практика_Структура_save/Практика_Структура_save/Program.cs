using System;
using System.IO;

namespace Практика_Структура_save
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
            Console.Write("\nВведите имя автора: ");
            input.Author = Console.ReadLine();
            Console.Write("Введите название фильма: ");
            input.Name = Console.ReadLine();
            Console.Write("Введите год выпуска фильма: ");
            input.Year = int.Parse(Console.ReadLine());
            Console.Write("Введите продолжительность фильма: ");
            input.PlayTime = int.Parse(Console.ReadLine());
            return input;
        }
        public static string outputStruct(TMovie output)
        {
            return $"Режисер:{output.Author}\nНазвание:{output.Name}\nГод выпуска:{output.Year}\n";
        }
        public static string outputTime(TMovie time)
        {
            int minutes = time.PlayTime % 60;
            int hors = (time.PlayTime - minutes) / 60;
            string temp = $"Время просмотра: {time.PlayTime}мин или {hors}ч и {minutes}мин\n";
            if (time.PlayTime > 120) temp += "Фильм слишком длинный";
            if (time.PlayTime < 50) temp += "Фильм слишком короткий";
            return temp;
        }
        public static void Main(string[] args)
        {

            TMovie temp;
            string endResult = "";
            StreamWriter save = new StreamWriter("C:\\Users\\Павел\\Documents\\GitHub\\ne_spisivay\\Практика_Структуры\\Практика_Структуры\\Save\\save.txt");
            Console.Write("Введите кол-во фильмов: ");
            int a = int.Parse(Console.ReadLine());
            TMovie[] film = new TMovie[a];
            for (int i = 0; i < a; i++)
            {
                temp = inputStruct();
                endResult += outputStruct(temp);
                endResult += outputTime(temp);

                film[i] = temp;
            }          
            Console.Write(endResult);
            save.WriteLine(endResult);
            save.Close();
            Console.ReadKey();
        }
    }
}

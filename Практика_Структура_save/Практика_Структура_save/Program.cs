using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.Write("Введите имя автора ");
            input.Author = Console.ReadLine();
            Console.Write("Введите название фильма ");
            input.Name = Console.ReadLine();
            Console.Write("Введите год выпуска фильма ");
            input.Year = int.Parse(Console.ReadLine());
            Console.Write("Введите продолжительность фильма ");
            input.PlayTime = int.Parse(Console.ReadLine());
            return input;
        }
        public static string outputStruct(TMovie output)
        {
            return$"Режисер:{output.Author}\nНазвание:{output.Name}\nГод выпуска:{output.Year}\n";
        }
        public static string outputTime(TMovie time)
        {
            int minutes = time.PlayTime % 60;
            int hors = (time.PlayTime - minutes) / 60;
            string temp = $"Время просмотра:{time.PlayTime}мин или {hors}ч и {minutes}мин\n";
            if (time.PlayTime > 120) temp += "Фильм слишком длинный";
            if (time.PlayTime < 50) temp += "Фильм слишком короткий";
            return temp;
        }
        public static void Main(string[] args)
        {
            TMovie film;
            string endResult="";
            StreamWriter save = new StreamWriter("C:\\Users\\pashe\\source\\repos\\Практика_Структура_save\\Практика_Структура_save\\Save\\save.txt");
            film = inputStruct();
            endResult += outputStruct(film);
            endResult += outputTime(film);
            Console.Write(endResult);
            save.WriteLine(endResult);
            save.Close();
            Console.ReadKey();
        }
    }
}

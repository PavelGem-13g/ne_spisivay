using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_Перечисления_Практика_3_4
{
    class Program
    {
        enum days {Понедельник=1,Вторник,Среда,Четверг,Пятница,Суббота,Воскресенье };
        public static int sdvig(int day, int sdvig) 
        {
            if (sdvig / 7 >= 0) sdvig = sdvig - (sdvig / 7) * 7;
            day = day + sdvig;           
            return day;
        }
        static void Main(string[] args)
        {
            for (days i=days.Понедельник; i <= days.Воскресенье; i++) Console.WriteLine("День недели:\"{0}\" соответствует числу {1}",i,(int)i);
            Console.WriteLine("Введите день недели ");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во дней ");
            int sdvignumber = int.Parse(Console.ReadLine());
            day = sdvig(day, sdvignumber);
            days result = (days)day;
            Console.WriteLine("Черз введённое кол-во дней наступит : {0}, {1} день недели",result,(int)result);
            Console.ReadKey();
        }
    }
}

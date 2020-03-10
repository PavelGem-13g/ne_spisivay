using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Фоновая_4._2_вар3
{
    class MatrixWeather
    {
        int month;
        int day;
        int[,] temperature;
        public MatrixWeather() 
        {
            day = 1;
            month = 1;
            temperature = new int[6,7];
        }

        public MatrixWeather(int day, int month, int week)
        {
            this.day = day;
            this.month = month;
            temperature = new int[week,7];
        }
        static void rndTemp() 
        {
            Random rnd = new Random();
            for (int j = 0; j < temperature.GetLength(1); j++) 
            { 
                for (int i = 0; i < 8; i++) 
                {
                    temperature[i, j] = rnd.Next();
                }
            
            }
        }
    }
    enum Months { январь = 1, февраль, март, апрель, май, июнь, июль, август, сенябрь, октябрь, ноябрь, декабрь };

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

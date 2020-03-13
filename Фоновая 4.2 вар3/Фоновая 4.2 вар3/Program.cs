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
            temperature = new int[5,7];
        }

        public MatrixWeather(int day, int month)
        {
            
            this.day = day;
            this.month = month;
            int week;
            temperature = new int[6,7];
        }
        static MatrixWeather rndTemp() 
        {
            Random rnd = new Random();
            for (int j = 0; j < temperature.GetLength(1); j++) 
            { 
                for (int i = 0; i < 8; i++) 
                {
                    temperature[i, j] = rnd.Next();
                }
            
            }
            return MatrixWeather;
        }
        public output()
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
            
        }
      public int scach() 
        {
            inr max=0,maxTemp=0;;
            for (int j = 0; j < temperature.GetLength(1)-2; j++) 
            { 
                for (int i = 0; i < 7; i++) 
                {
                    maxTemp=Math.Abs(Math.Abs(temperature[i, j])-Math.Abs(temperature[i+1, j+1]));
                }
            if(maxTemp>max)max=maxTemp;
            }
          return max;
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

using System;

namespace Игра_с_массивами_шарики
{
    class Program
    {
        public static void check(int[,] n, int Nx, int Ny,  int direct, ref int k, int color)
        {
            int tempX = Nx;
            int tempY = Ny;
            if ((n[Nx, Ny] == n[Nx + 1, Ny]) && direct == 1)
            {//tempX != n.GetLength(0) - 1 &&
                continueCheck1(n, ref tempX, ref tempY, ref direct, ref k, color);
            }

            if ((n[Nx, Ny] == n[Nx, Ny + 1]) && direct == 2)
            {//(tempY != n.GetLength(1) - 1) &&
                continueCheck2(n, ref tempX, ref tempY, ref direct, ref k, color);
            }

            if ((n[Nx, Ny] == n[Nx + 1, Ny + 1]) && direct==3)
            {//(tempX != 0 && tempY != 0) &&
                continueCheck3(n, ref tempX, ref tempY, ref direct, ref k, color);
            }

            if ((n[Nx, Ny] == n[Nx - 1, Ny + 1]) && direct == 4)
            {//(tempY != 0) &&
                continueCheck4(n, ref tempX, ref tempY, ref direct, ref k, color);
            }

            if ((n[Nx, Ny] == n[Nx + 1, Ny - 1]) && direct == 5)
            {//(tempX != n.GetLength(0) - 1 && tempY != 0) &&
                continueCheck5(n, ref tempX, ref tempY, ref direct, ref k, color);
            }

            if ((n[Nx, Ny] == n[Nx - 1, Ny - 1]) && direct == 6)
            {//(tempX != n.GetLength(0) - 1 && tempY != n.GetLength(1) - 1) &&
                continueCheck6(n, ref tempX, ref tempY, ref direct, ref k, color);
            }

            if ((n[Nx, Ny] == n[Nx - 1, Ny]) && direct == 7)
            {//(tempY != n.GetLength(1) - 1 && tempX != 0) &&
                continueCheck7(n, ref tempX, ref tempY, ref direct, ref k, color);
            }

            if ((n[Nx, Ny] == n[Nx, Ny - 1]) && direct == 8)
            {//tempX != 0 &&
                continueCheck8(n, ref tempX, ref tempY, ref direct, ref k, color);
            }
        }
        /*public static int reCheck(int[,] n, int direct,ref int k)
        {
            if(direct==1)

            return k;
        }*/
        public static int continueCheck1(int[,] n, ref int Nx, ref int Ny, ref int direct, ref int k, int color)
        {
            //if (n[Nx, Ny] == color)
            if (n[Nx, Ny] == color)
            {//(Nx != 0 && Ny != 0) &&
                k++;
                Nx++;
                return continueCheck1(n, ref Nx, ref Ny, ref direct, ref k, color);
            }
            else return k;
        }
        public static int continueCheck2(int[,] n, ref int Nx, ref int Ny, ref int direct, ref int k, int color)
        {
            if (n[Nx, Ny] == color )
            {//if ((Ny != 0)&& n[Nx, Ny] == color)
                k++;
                Ny++;
                return continueCheck2(n, ref Nx, ref Ny, ref direct, ref k, color);
            }
            else return k;
        }
        public static int continueCheck3(int[,] n, ref int Nx, ref int Ny, ref int direct, ref int k, int color)
        {
            //if (n[Nx, Ny] == color )
            if (n[Nx, Ny] == color)
            {//(Nx != n.GetLength(0) - 1 && Ny != 0)&&
                k++;
                Nx++;
                Ny++;
                return continueCheck3(n, ref Nx, ref Ny, ref direct, ref k, color);
            }
            else return k;
        }
        //
        public static int continueCheck4(int[,] n, ref int Nx, ref int Ny, ref int direct, ref int k, int color)
        {
            //if (n[Nx, Ny] == color )
            if (n[Nx, Ny] == color)
            {//Nx != n.GetLength(0) &&
                k++;
                Nx--;
                Ny++;
                return continueCheck4(n, ref Nx, ref Ny, ref direct, ref k, color);
            }
            else return 0;
        }
        public static int continueCheck5(int[,] n, ref int Nx, ref int Ny, ref int direct, ref int k, int color)
        {
            //if (n[Nx, Ny] == color) (Nx != n.GetLength(0) - 1 && Ny != n.GetLength(1) - 1) &&
            if (n[Nx, Ny] == color)
            {
                k++;
                Nx++;
                Ny--;
                return continueCheck5(n, ref Nx, ref Ny, ref direct, ref k, color);
            }
            else return k;
        }
        public static int continueCheck6(int[,] n, ref int Nx, ref int Ny, ref int direct, ref int k, int color)
        {
            //if (n[Nx, Ny] == color) Ny != n.GetLength(1)-1  &&
            if ( n[Nx, Ny] == color)
            {
                k++;
                Nx--;
                Ny--;
                return continueCheck6(n, ref Nx, ref Ny, ref direct, ref k, color);
            }
            else return k;
        }
        public static int continueCheck7(int[,] n, ref int Nx, ref int Ny, ref int direct, ref int k, int color)
        {

            if (n[Nx, Ny] == color)
            {//if (n[Nx, Ny] == color)(Ny != n.GetLength(1) - 1 && Nx != 0) &&
                k++;
                Nx--;
                return continueCheck7(n, ref Nx, ref Ny, ref direct, ref k, color);
            }
            else return k;
        }
        public static int continueCheck8(int[,] n, ref int Nx, ref int Ny, ref int direct, ref int k, int color)
        {

            if (n[Nx, Ny] == color)
            {//if (n[Nx, Ny] == color) Nx != 0 &&
                k++;
                Ny--;
                return continueCheck8(n, ref Nx, ref Ny, ref direct, ref k, color);
            }
            else return k;
        }
        public static void ClearMas(int[,] n, int Nx, int Ny, int k, int direct)
        {
            for (int i = 0; i < k; i++)
            {
                if ( direct == 1)
                {//Nx != n.GetLength(0) &&if (direct == 1)
                    n[Nx, Ny] = 0;
                    Nx++;
                }

                if ( direct == 2)
                {//Ny != n.GetLength(1)  &&if (direct == 2)
                    n[Nx, Ny] = 0;
                    Ny++;
                }

                if (direct == 3)
                {//(Nx != 0 && Ny != 0) && if (direct == 3 )
                    n[Nx, Ny] = 0;
                    Nx++;
                    Ny++;
                }

                if (direct == 4)
                {//(Ny != 0) && if (direct == 4)
                    n[Nx, Ny] = 0;
                    Nx--;
                    Ny++;
                }

                if (direct == 5)
                {//(Nx != n.GetLength(0)  && Ny != 0) &&  if (direct == 5)
                    n[Nx, Ny] = 0;
                    Nx++;
                    Ny--;
                }


                if (direct == 6)
                {//(Nx != n.GetLength(0)-1  && Ny != n.GetLength(1)) && if (direct == 6)
                    n[Nx, Ny] = 0;
                    Nx--;
                    Ny--;
                }


                if (direct == 7)
                {//(Ny != n.GetLength(1)  && Nx != 0) && if (direct == 7)
                    n[Nx, Ny] = 0;
                    Nx--;

                }

                if (direct == 8)
                {//Nx != 0 && if (direct == 8)
                    n[Nx, Ny] = 0;
                    Ny--;
                }
            }
        }
        public static void untitledFuction(int[,] n, ref int k)
        {
            int direct = 0,i2,j2,k1=0,color=0;
            for (int i = 0; i < n.GetLength(0)-2-1; i++)
            {
                for (int j = 0; j < n.GetLength(1)-1; j++)
                {

                    if (n[i,j] != 0)
                    {
                        color = n[i, j];
                        //это всё-таки надо делать
                        for (direct = 1; direct < 9; direct++)
                        {
                            i2 = i;
                            j2 = j;

                            check(n, i2, j2, direct, ref k1, color);
                            if (k1 > 2)
                            {
                                ClearMas(n, i, j, k1, direct);
                                k = k1 + k;
                            }
                        k1 = 0;
                        }
                    }
                }
            }
        }
        public static void workWithPeople(int[,] n)
        {
            int temp = 0;
            Console.Write("\nВведите координату шарика\n");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите координату поля, куда переставить шарик");
            int moveX = int.Parse(Console.ReadLine());
            int moveY = int.Parse(Console.ReadLine());
            if (haveItWays(n, x, y, moveX, moveY) == 1)
            {
                n[moveX, moveY] = n[x, y];
                n[x, y] = 0;
            }
        }
        public static int haveItWays(int[,] n,int x,int y, int moveX,int moveY)
        {/*
            int color = 0;
            for(int )
            if(check(n,x,y,,color))*/
            return 1;
        }
        public static void outField(int[,] n, int score)
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Колличество шариков:{howManyBalls(n)}\nКолличество очков: {score}");
            string c = Char.ConvertFromUtf32(9679);
            Console.Write("\n  ");
            for (int i = 0; i < n.GetLength(0)-2; i++) Console.Write(i + " ");
            Console.WriteLine();//можно вывести через Line
            for (int i = 1; i < n.GetLength(0)-1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(i-1);
                for (int j = 1; j < n.GetLength(1)-1; j++)
                {
                    switch (n[i, j])
                    {
                        case 0:Console.ForegroundColor = ConsoleColor.White;break;
                        case 1: Console.ForegroundColor = ConsoleColor.Yellow;break;
                        case 2:Console.ForegroundColor = ConsoleColor.Red;break;
                        case 3:Console.ForegroundColor = ConsoleColor.Green;break;
                        case 4:Console.ForegroundColor = ConsoleColor.Blue;break;
                        case 5:Console.ForegroundColor = ConsoleColor.Cyan;break;
                        case 6:Console.ForegroundColor = ConsoleColor.DarkMagenta;break;
                        default:Console.ForegroundColor = ConsoleColor.DarkGreen;break;
                    }
                  
                    Console.Write(c+c);
                }
                //

                Console.Write("\n");
            }
        }
        public static void createBallsOnField(int[,] n, int k, int BallsColors)
        {
            int i, j;
            Random rand = new Random();
            while (howManyBalls(n) != k)
            {
                i = rand.Next(1, n.GetLength(0)-1);
                j = rand.Next(1, n.GetLength(1)-1);
                if (n[i,j]==0)n[i,j] = rand.Next(1, BallsColors+1);
                //&&(i!=0 && j!=0)&&(i!=n.GetLength(0)-1 && j != n.GetLength(1)-1)
            }
        }
        public static int howManyBalls(int[,] n)
        {
            int Balls = 0;
            foreach (int cell in n) if (cell != 0) Balls++;
            return Balls;
        }
        static void Main(string[] args)
        {
            int Nx = 0, Ny = 0,score=0;
            Console.Write("Введите колличество строк : ");
            Nx = int.Parse(Console.ReadLine());
            Console.Write("Введите колличество столбцов : ");
            Ny = int.Parse(Console.ReadLine());
            int[,] n = new int[Nx+2, Ny+2];
            Console.Write("Введите колличество шариков : ");
            int BallsK = int.Parse(Console.ReadLine());
            Console.Write("Введите колличество цветов : ");
            int BallsCollor = int.Parse(Console.ReadLine());
            createBallsOnField(n, BallsK,BallsCollor);
            outField(n,score);
            untitledFuction(n, ref score);
            outField(n,score);
            Console.ReadKey();
        }
    }
}

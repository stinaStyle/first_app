using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static int _a = 0;
        static void Main(string[] args)
        {
            #region
            //            string fizz = "fizz";
            //            string buzz = "buzz";
            //            string say = "say hello";
            //            for (int i = 1; i <= 100500; i++)
            //            {
            //               
            //                if (i%15 == 0 && i >= 15) 
            //                {
            //                    Console.WriteLine(i + fizz + buzz);
            //                    
            //                }
            //                else if (i%5 == 0)
            //                {
            //                    Console.WriteLine(i + buzz);
            //                }
            //                else if (i%3 == 0)
            //                {
            //                    Console.WriteLine(i + fizz);
            //                }
            //                else
            //                {
            //                    Console.WriteLine(i + say);
            //                }
            //                
            //            }
            //            Console.ReadLine();
            #endregion

            int a = 1000;
            int[] generatedArray = BigArray(количествоЦиферок: 35, limit: a);
            
            
            //SortArr(generatedArray);
            DrawRand(generatedArray,10,5);

            //DrawArr(20, 5);
            string s = Console.ReadLine();
            int i = Int32.Parse(s);
            int found = FindSimple(generatedArray, i);
            Console.WriteLine(found);

            Console.ReadLine();
        }

        public static void SortArr(int[] SomeArr)
        {
            int c = 0;
            int timingMult = 4;
            for (int j = 0; j <= SomeArr.Length - 1; j++)
            {

                for (int i = 0; i <= SomeArr.Length - j - 2; i++)
                {
                    DrawRand(SomeArr, i + 1, i);
                    if (SomeArr[i] > SomeArr[i + 1])
                    {

                        c = SomeArr[i];
                        SomeArr[i] = SomeArr[i + 1];
                        SomeArr[i + 1] = c;
                        DrawRand(SomeArr, i, i + 1);
                        Thread.Sleep(2 * timingMult);
                    }

                    Thread.Sleep(1 * timingMult);
                    //Thread.Sleep(300);
                }
            }
            Console.WriteLine();
        }

        public static int FindSimple(int[] array, int h)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == h)
                    return i;
            }
            return -1;
        }

        public static int[] BigArray(int количествоЦиферок, int limit)
        {
            int[] sa = new int[количествоЦиферок];
            Random rnd = new Random();
            for (int i = 0; i < sa.Length; i++)
            {
                sa[i] = rnd.Next(limit);
            }

            return sa;
        }

        public static void DrawLine(int[] arr, char left, char centr, char right)
        {
            Console.Write(left);//"┌");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(new string('─', 5));

                if (i < arr.Length - 1)
                {
                    Console.Write(centr); //"┬");    
                }
            }
            Console.Write(right); //"┐");
        }

        public static void DrawRand(int[] arr, int idx, int point)
        {
            //            string vertLine = new string('─', arr.Length * 6 - 1);
            //            string drawLine = new string('┬', (arr.Length *  6 - 1)% 6 );

            //            Console.Write("┌" + vertLine + drawLine + "┐");

            Console.SetCursorPosition(0, 0);
            DrawLine(arr, '┌', '┬', '┐');
            Console.WriteLine();
            // 1 строка нарисована
            Console.Write("│");

            for (int i = 0; i < arr.Length; i++)
            {

                int f = arr[i].ToString().Length;
                if (idx == i) Console.BackgroundColor = ConsoleColor.Red;
                else if (i == point) Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(arr[i] + new string(' ', 5 - f));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("|");



            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            DrawLine(arr, '└', '┴', '┘');
            //Console.Write("└" + vertLine + "┘");

        }


        public static int[] DrawArr(int count, int point)
        {
            int[] qw = new int[count];
            for (int i = 0; i < qw.Length; i++)
            {
                qw[i] = i;
                Console.Write(i + " ");
                if (i == point) Console.ForegroundColor = ConsoleColor.Blue;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            return qw;
        }

        public static Поднос<Рататуй> СделатьРататуй(Баклажан вася, Помидор петя, Цукини абрам)
        {
            //....
            Поднос<Рататуй> подносец = new Поднос<Рататуй>();
            Рататуй рататуец = new Рататуй();
            подносец.Содержимое = рататуец;
            return подносец;
        }

    }

    class Рататуй
    {

    }

    class Поднос<TВсеЧтоУгодно>
    {
        public TВсеЧтоУгодно Содержимое;
    }

    class Баклажан
    {

    }

    class Цукини
    {

    }

    class Помидор
    {

    }

}

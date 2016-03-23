﻿using System;
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
            int[] generatedArray = BigArray(количествоЦиферок: 10, limit: a);
            
            
            
            SortArr(generatedArray);
            //DrawRand(generatedArray,10,5);

            //DrawArr(20, 5);
//            string s = Console.ReadLine();
//            int i = Int32.Parse(s);
//            int found = FindSimple(generatedArray, i);
            int found = FindBinary(generatedArray, x:int.Parse(Console.ReadLine()), first:0, last:generatedArray.Length-1);
            Console.WriteLine(found);
            DrawRand(generatedArray,found,found);

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

        public static int FindBinary(int[] array, int x, int first, int last)
        {
//            int left = array[0];
//            first = left;
//            int right = array.Length - 1;
//            last = right;
            int m = first + (last - first)/2;
//            x = int.Parse(Console.ReadLine());
            if (array[m] == x)
            {
                return m;
            }
            else if (array[m] > x)
            {
                return FindBinary(array, x, first, m);
            }
            else
            {
                return FindBinary(array, x, m + 1, last);
            }

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

      

    }

   

}

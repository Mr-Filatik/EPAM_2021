using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 2 };

            Console.WriteLine("Sum " + arr.SumArray());
            Console.WriteLine("Aver " + arr.AverArray());
            Console.WriteLine("MaxVis " + arr.MaxVisArray());

            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            arr.ElementPlusPlus(2);

            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            arr.ElementSquare(1);

            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        //public delegate void Act(this int[] input, int number);
        //public delegate void Act(int number);
    }
}

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
            DinamicArray<int> array = new DinamicArray<int>();
            array.Add(11);
            array.Add(2);
            array.Add(6);
            Console.WriteLine("(" + array.Length + ")" + "(" + array.Capacity + ")");
            Getting(array);
            Console.ReadKey();

            Console.Clear();
            array.Insert(3, 1);
            Console.WriteLine("(" + array.Length + ")" + "(" + array.Capacity + ")");
            Getting(array);
            Console.ReadKey();

            Console.Clear();
            array.Remove(array[1]);
            Console.WriteLine("(" + array.Length + ")" + "(" + array.Capacity + ")");
            Getting(array);
            Console.ReadKey();

            Console.Clear();
            array.AddRange(new int[] { 3, 4, 5, 6, 7, 7, 8});
            Console.WriteLine("(" + array.Length + ")" + "(" + array.Capacity + ")");
            Getting(array);
            Console.ReadKey();
        }

        static void Getting(DinamicArray<int> array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}

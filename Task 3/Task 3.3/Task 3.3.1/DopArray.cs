using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public static class DopArray
    {
        public static void ElementSquare(this int[] input, int number)
        {
            if (number >= 0 && number < input.Length)
            {
                input[number] *= input[number];
            }
            else
            {
                Console.WriteLine("EXSEPTION");
            }
        }

        public static void ElementPlusPlus(this int[] input, int number)
        {
            if (number >= 0 && number < input.Length)
            {
                input[number]++;
            }
            else
            {
                Console.WriteLine("EXSEPTION");
            }
        }

        public static int SumArray(this int[] input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
            }
            return sum;
        }

        public static float AverArray(this int[] input)
        {
            float aver = 0;
            aver = input.SumArray() / input.Length;
            return aver;
        }

        public static int MaxVisArray(this int[] input)
        {
            int number = 0;
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int c = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == input[i]) { 
                        c++; 
                    }
                }
                if (count < c)
                {
                    count = c;
                    number = i;
                }
            }
            return input[number];
        }
    }
}

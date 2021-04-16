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
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();
            string str_done = "";
            for (int i = 0; i < str.Length; i++)
            {
                str_done += char.ToLower(str[i]);
            }

            GetWord(str_done);

            Console.ReadKey();
        }

        public static void GetWord(string string_input)
        {
            char[] symbol = new char[] { ' ', ',', '.', '!', '?' };
            string[] words = string_input.Split(symbol);
            int number = 0;
            string[] words_done = new string[words.Length];
            for (int i = 0; i < words_done.Length; i++) { words_done[i] = ""; }
            for (int i = 0; i < words.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j <= number; j++)
                {
                    if (words[i] == words_done[j])
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    words_done[number] = words[i];
                    number++;
                }
            }
            int[] words_number = new int[words.Length];
            for (int i = 0; i < words_number.Length - 1; i++)
            {
                words_number[i] = 0;
            }
            for (int j = 0; j < words_done.Length; j++)
            {
                if (words_done[j] != "")
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] == words_done[j])
                        {
                            words_number[j]++;
                        }
                    }
                }
            }
            for (int i = 0; i < words_number.Length - 2; i++)
            {
                for (int j = i + 1; j < words_number.Length; j++)
                {
                    if (words_number[j] > words_number[i])
                    {
                        int k = words_number[j];
                        words_number[j] = words_number[i];
                        words_number[i] = k;
                        string s = words_done[j];
                        words_done[j] = words_done[i];
                        words_done[i] = s;
                    }
                }
            }
            for (int i = 0; i < words_done.Length; i++)
            {
                if (words_done[i] != "")
                {
                    Console.WriteLine(words_done[i] + " - " + words_number[i]);
                }
            }
        }
    }
}

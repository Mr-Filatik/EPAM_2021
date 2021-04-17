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
            SetGroup(str);
            Console.ReadKey();
        }

        public static void SetGroup(string string_input)
        {
            string mes = "Mixed";
            int rus = 0;
            int eng = 0;
            int num = 0;
            foreach (char item in string_input)
            {
                if ((item >= '0' && item <= '9') || item == ',' || item == '.')
                {
                    num++;
                }
                if ((item >= 'a' && item <= 'z') || (item >= 'A' && item <= 'Z'))
                {
                    eng++;
                }
                if ((item >= 'а' && item <= 'я') || (item >= 'А' && item <= 'Я'))
                {
                    rus++;
                }
                if ((rus != 0 && eng != 0) || (rus != 0 && num != 0) || (eng != 0 && num != 0))
                {
                    break;
                }
            }
            if (rus == string_input.Length)
            {
                mes = "Russian";
            }
            if (eng == string_input.Length)
            {
                mes = "English";
            }
            if (num == string_input.Length)
            {
                mes = "Number";
            }
            Console.WriteLine(mes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString string_1 = new MyString(new char[] { 'A', 'B', 'C' });
            MyString string_1_1 = new MyString(new char[] { 'A', 'B', 'C' });
            MyString string_1_2 = new MyString(new char[] { 'B', 'B', 'C' });

            Console.WriteLine("Первая строка " + string_1.ToString());
            Console.WriteLine("Вторая строка " + string_1_1.ToString());
            Console.WriteLine("Третья строка " + string_1_2.ToString());

            Console.WriteLine("Сравнение 1 и 2 " + string_1.Compare(string_1_1));
            Console.WriteLine("Сравнение 1 и 3 " + string_1.Compare(string_1_2));

            string_1.Concatenation(string_1_1);
            Console.WriteLine("Конкатенация строк " + string_1.ToString());
            string_1.Concatenation(string_1_2, 2);
            Console.WriteLine("Вставка строки в определённое место " + string_1.ToString());

            Console.WriteLine("Число символов D " + string_1.NumberOfCharacter('D'));
            Console.WriteLine("Число символов B " + string_1.NumberOfCharacter('B'));

            Console.Write("Индексы символа B ");
            int[] a = string_1.IndexOfCharacter('B');
            foreach (var i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Третий символ строки " + string_1.GetCharacter(3));

            string_1.DeleteCharacter(0);
            Console.WriteLine("Удаление нулевого символа " + string_1.ToString());
            string_1.DeleteCharacter('B');
            Console.WriteLine("Удаление символа B " + string_1.ToString());

            Console.ReadKey();
        }
    }
}

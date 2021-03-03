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
            Averages("Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате");
            Doubler("написать программу, которая", "описание");
            LowerCase("Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны", false);
            Validator("я плохо учил русский язык. забываю начинать предложения с заглавной. хорошо, что можно написать программу!");
            Console.ReadKey();
        }

        public static void Averages(string string_input)
        {
            Console.WriteLine("Averages");
            Console.WriteLine(string_input);
            char[] symbol = new char[] { ' ', ',', '.', '!', '?' };
            string[] words = string_input.Split(symbol);
            int words_length = 0;
            int word_number = 0;
            foreach (string word in words)
            {
                if (word != "")
                {
                    words_length += word.Length;
                    word_number++;
                }
            }
            Console.WriteLine("Целочисленное значение: " + words_length / word_number);
            Console.WriteLine("Дробное значение: " + (float)words_length / word_number);
        }

        public static void Doubler(string string_input, string string_word)
        {
            Console.WriteLine("Doubler");
            Console.WriteLine(string_input + ", " + string_word);
            string rezult = "";
            foreach (char char_1 in string_input)
            {
                foreach (char char_2 in string_word)
                {
                    if (char_1 == char_2)
                    {
                        rezult += char_1;
                        break;
                    }
                }
                rezult += char_1;
            }
            Console.WriteLine(rezult);
        }

        public static void LowerCase(string string_input, bool separator_only_space)
        {
            Console.WriteLine("LowerCase");
            Console.WriteLine(string_input + ", " + separator_only_space);
            char[] symbol = new char[] { ' ' };
            if (!separator_only_space) { symbol = new char[] { ' ', ',', '.', '!', '?' }; }
            string[] words = string_input.Split(symbol);
            int word_number = 0;
            foreach (string word in words)
            {
                if (word != "" && Char.IsLower(word[0])) { word_number++; }
            }
            Console.WriteLine("Число слов с маленькой буквы: " + word_number);
        }

        public static void Validator(string string_input)
        {
            Console.WriteLine("Validator");
            Console.WriteLine(string_input);
            StringBuilder stringBuilder = new StringBuilder(string_input);
            bool is_upper = true;
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                if (is_upper && Char.IsLower(stringBuilder[i]))
                {
                    stringBuilder[i] = Char.ToUpper(stringBuilder[i]);
                    is_upper = false;
                }
                if (stringBuilder[i] == '.' || stringBuilder[i] == '!' || stringBuilder[i] == '?')
                {
                    is_upper = true;
                    i++;
                }
            }
            Console.WriteLine(stringBuilder);
        }
    }
}

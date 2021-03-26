using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class MyString
    {
        public char[] Symbols { get; private set; }
        public int Length { get; private set; }

        public MyString(char[] input)
        {
            Length = input.Length;
            Symbols = new char[Length];
            Symbols = input;
        }

        public bool Compare(MyString input)
        {
            if (Length == input.Length)
            {
                bool is_equally = true;
                for (int i = 0; i < Length; i++)
                {
                    if (Symbols[i] != input.Symbols[i])
                    {
                        is_equally = false;
                        break;
                    }
                }
                if (is_equally)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Concatenation(MyString input)
        {
            Length += input.Length;
            char[] str = Symbols;
            Symbols = new char[Length];
            int number = 0;
            foreach (var i in str)
            {
                Symbols[number] = i;
                number++;
            }
            foreach (var i in input.Symbols)
            {
                Symbols[number] = i;
                number++;
            }
        }

        public void Concatenation(MyString input, int index)
        {
            if (index < Length)
            {
                Length += input.Length;
                char[] str = Symbols;
                Symbols = new char[Length];
                int number = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    if (index == number)
                    {
                        foreach (var item in input.Symbols)
                        {
                            Symbols[number] = item;
                            number++;
                        }
                    }
                    Symbols[number] = str[i];
                    number++;
                }
            }
            else
            {
                Concatenation(input);
            }
        }

        public int NumberOfCharacter(char input)
        {
            int number = 0;
            foreach (var i in Symbols)
            {
                if (i == input)
                {
                    number++;
                }
            }
            return number;
        }

        public int[] IndexOfCharacter(char input)
        {
            int[] numbers = new int[NumberOfCharacter(input)];
            int number = 0;
            for (int i = 0; i < Length; i++)
            {
                if (Symbols[i] == input)
                {
                    numbers[number] = i;
                    number++;
                }
            }
            return numbers;
        }

        public char GetCharacter(int input)
        {
            return Symbols[input];
        }

        public void DeleteCharacter(char input)
        {
            Length -= NumberOfCharacter(input);
            char[] str = Symbols;
            Symbols = new char[Length];
            int number = 0;
            foreach (var i in str)
            {
                if (i != input)
                {
                    Symbols[number] = i;
                    number++;
                }
            }
        }

        public void DeleteCharacter(int input)
        {
            if (input < Length)
            {
                Length -= 1;
                char[] str = Symbols;
                Symbols = new char[Length];
                int number = 0;
                for(int i = 0; i < str.Length; i++)
                {
                    if (i != input)
                    {
                        Symbols[number] = str[i];
                        number++;
                    }
                }
            }
        }

        public void ChangeCharacter(char input, int index)
        {
            if (index < Length)
            {
                Symbols[index] = input;
            }
        }

        public override string ToString()
        {
            return new string(Symbols);
        }
    }
}

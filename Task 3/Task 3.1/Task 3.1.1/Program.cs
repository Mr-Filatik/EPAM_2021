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
            Console.WriteLine("Введите количество человек");
            int numberOfPeople = 0;
            do { try { numberOfPeople = Convert.ToInt32(Console.ReadLine()); } catch { } }while (numberOfPeople < 1);
            Console.WriteLine("Введите, какой по счёту человек будет вычеркнут");
            int numberForDelete = 0;
            do { try { numberForDelete = Convert.ToInt32(Console.ReadLine()); } catch { } } while (numberForDelete < 1);

            Countdown(numberOfPeople, numberForDelete);

            Console.ReadKey();
        }

        static void Countdown(int numberOfPeople, int numberForDelete)
        {
            int number = numberOfPeople;
            bool[] people = new bool[number];
            for (int i = 0; i < number; i++) { people[i] = true; }

            bool is_game = true;
            int remainted = 0;
            while (is_game)
            {
                if (number < numberForDelete)
                {
                    is_game = false;
                }

                if (is_game)
                {
                    for (int i = 1; i <= numberForDelete;)
                    {
                        if (people[remainted])
                        {
                            if (i == numberForDelete)
                            {
                                number--;
                                people[remainted] = false;
                                remainted++;
                            }
                            else
                            {
                                remainted++;
                            }
                            i++;
                        }
                        else
                        {
                            remainted++;
                        }
                        if (remainted == numberOfPeople)
                        {
                            remainted = 0;
                        }
                    }
                    Console.Write("Осталось человек - " + number + " их первоначальные номера: ");
                    for (int i = 0; i < numberOfPeople; i++)
                    {
                        if (people[i])
                        {
                            Console.Write(i + 1 + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Дальнейшее вычёркивание невозможно");
                }
            }
        }
    }
}

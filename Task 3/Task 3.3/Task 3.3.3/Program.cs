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
            //вход для работника кнопка q в меню с выбором действий
            Pizzeria pizzeria = new Pizzeria();
            pizzeria.Run();
            Console.ReadKey();
        }
    }

    class Pizza
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Pizzeria
    {
        //вход для работника кнопка q в меню с выбором действий
        static int number_zacazov = 0;
        static bool menu = true;
        static Orders orders = new Orders();

        public void Run()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += TimerEvent;
            timer.AutoReset = true;
            timer.Start();

            while (true)
            {
                if (!menu)
                {
                    bool run = true;
                    do
                    {
                        ConsoleKey key;
                        Console.Clear();
                        Console.WriteLine("1 - Создать заказ");
                        Console.WriteLine("2 - Оплатить заказ");
                        Console.WriteLine("3 - Забрать заказ");
                        Console.WriteLine("0 - Выход");
                        key = Console.ReadKey().Key;
                        if (key == ConsoleKey.D0)
                        {
                            run = false;
                        }
                        if (key == ConsoleKey.D1)
                        {
                            Console.Clear();
                            Console.WriteLine("1 - Пицца пепероне");
                            Console.WriteLine("2 - Пицца вегетарианская");
                            Console.WriteLine("3 - Пицца мясная");
                            Console.WriteLine("4 - Пицца русская");
                            key = Console.ReadKey().Key;
                            string info = "";
                            bool next = false;
                            if (key == ConsoleKey.D1)
                            {
                                info = "Пицца пепероне";
                                next = true;
                            }
                            if (key == ConsoleKey.D2) 
                            {
                                info = "Пицца вегетарианская";
                                next = true;
                            }
                            if (key == ConsoleKey.D3)
                            {
                                info = "Пицца мясная";
                                next = true;
                            }
                            if (key == ConsoleKey.D4)
                            {
                                info = "Пицца русская";
                                next = true;
                            }
                            if (next)
                            {
                                orders.Create(new Order(number_zacazov, info));
                                number_zacazov++;
                                run = false;
                            }
                            break;
                        }
                        if (key == ConsoleKey.D2) 
                        {
                            Console.Clear();
                            if (orders.Get_Created().Count != 0)
                            {
                                Console.WriteLine("Введите номер заказа, а затем нажмите ввод");
                                int i = -1;
                                int number = 0;
                                bool flag = false;
                                do
                                {
                                    try
                                    {
                                        i = Int32.Parse(Console.ReadLine());
                                        for (int j = 0; j < orders.Get_Created().Count; j++)
                                        {
                                            if (orders.Get_Created()[j].GetId(i))
                                            {
                                                number = j;
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (flag)
                                        {
                                            orders.Cook(orders.Get_Created()[number]);
                                            Console.WriteLine("Оплачен заказ " + i);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Введён неверный номер заказа");
                                        }
                                    }
                                    catch
                                    {
                                        i = -1;
                                    }
                                } while (i < 0);
                            }
                            else
                            {
                                Console.WriteLine("Создайте заказ!");
                            }
                            Console.WriteLine("Нажмите любую кнопку для продолжения");
                            Console.ReadKey();
                            break;
                        }
                        if (key == ConsoleKey.D3) 
                        {
                            Console.Clear();
                            if (orders.Get_Ready().Count != 0)
                            {
                                Console.WriteLine("Введите номер заказа, а затем нажмите ввод");
                                int i = -1;
                                int number = 0;
                                bool flag = false;
                                do
                                {
                                    try
                                    {
                                        i = Int32.Parse(Console.ReadLine());
                                        for (int j = 0; j < orders.Get_Ready().Count; j++)
                                        {
                                            if (orders.Get_Ready()[j].GetId(i))
                                            {
                                                number = j;
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (flag)
                                        {
                                            orders.Done(orders.Get_Ready()[number]);
                                            Console.WriteLine("Приходите ещё");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Введён неверный номер заказа");
                                        }
                                    }
                                    catch
                                    {
                                        i = -1;
                                    }
                                } while (i < 0);
                            }
                            else
                            {
                                Console.WriteLine("Пока нет готовых заказов");
                            }
                            Console.WriteLine("Нажмите любую кнопку для продолжения");
                            Console.ReadKey();
                            break;
                        }
                        if (key == ConsoleKey.Q)
                        {
                            Console.Clear();
                            Console.WriteLine("1 - Заказ приготовлен");
                            Console.WriteLine("2 - Заказ упакован");
                            key = Console.ReadKey().Key;
                            if (key == ConsoleKey.D1)
                            {
                                Console.Clear();
                                if (orders.Get_Cooking().Count != 0)
                                {
                                    Console.WriteLine("Введите номер заказа, а затем нажмите ввод");
                                    int i = -1;
                                    int number = 0;
                                    bool flag = false;
                                    do
                                    {
                                        try
                                        {
                                            i = Int32.Parse(Console.ReadLine());
                                            for (int j = 0; j < orders.Get_Cooking().Count; j++)
                                            {
                                                if (orders.Get_Cooking()[j].GetId(i))
                                                {
                                                    number = j;
                                                    flag = true;
                                                    break;
                                                }
                                            }
                                            if (flag)
                                            {
                                                orders.Pack(orders.Get_Cooking()[number]);
                                                Console.WriteLine("Заказ отправлен на упаковку");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Введён неверный номер заказа");
                                            }
                                        }
                                        catch
                                        {
                                            i = -1;
                                        }
                                    } while (i < 0);
                                }
                                else
                                {
                                    Console.WriteLine("Нет заказов на готовке");
                                }
                                Console.WriteLine("Нажмите любую кнопку для продолжения");
                                Console.ReadKey();
                                break;
                            }
                            if (key == ConsoleKey.D2)
                            {
                                Console.Clear();
                                if (orders.Get_Packing().Count != 0)
                                {
                                    Console.WriteLine("Введите номер заказа, а затем нажмите ввод");
                                    int i = -1;
                                    int number = 0;
                                    bool flag = false;
                                    do
                                    {
                                        try
                                        {
                                            i = Int32.Parse(Console.ReadLine());
                                            for (int j = 0; j < orders.Get_Packing().Count; j++)
                                            {
                                                if (orders.Get_Packing()[j].GetId(i))
                                                {
                                                    number = j;
                                                    flag = true;
                                                    break;
                                                }
                                            }
                                            if (flag)
                                            {
                                                orders.Wait(orders.Get_Packing()[number]);
                                                Console.WriteLine("Заказ отправлен на ожидание");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Введён неверный номер заказа");
                                            }
                                        }
                                        catch
                                        {
                                            i = -1;
                                        }
                                    } while (i < 0);
                                }
                                else
                                {
                                    Console.WriteLine("Нет заказов на упаковке");
                                }
                                Console.WriteLine("Нажмите любую кнопку для продолжения");
                                Console.ReadKey();
                                break;
                            }
                        }
                    } while (run);
                    menu = true;
                    timer.Start();
                }
                else
                {
                    if (Console.ReadKey().Key == ConsoleKey.D0)
                    {
                        menu = false;
                        timer.Stop();
                    }
                }
            }
        }

        private static void TimerEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            WallOfOrders(orders);
        }

        private static void WallOfOrders(Orders z)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("0 - вызов меню (После оформления заказа необходимо провести оплату)");
            Console.WriteLine("----- Готово к выдаче:");
            if (z.Get_Ready().Count != 0)
            {
                foreach (Order i in z.Get_Ready()) { i.GetOrder(); }
            }
            Console.WriteLine("----- Упаковка заказа:");
            if (z.Get_Packing().Count != 0)
            {
                foreach (Order i in z.Get_Packing()) { i.GetOrder(); }
            }
            Console.WriteLine("----- Приготовление:");
            if (z.Get_Cooking().Count != 0)
            {
                foreach (Order i in z.Get_Cooking()) { i.GetOrder(); }
            }
            Console.WriteLine("----- Заказ создан:");
            if (z.Get_Created().Count != 0)
            {
                foreach (Order i in z.Get_Created()) { i.GetOrder(); }
            }
        }
    }

    class Orders
    {
        List<Order> ready = new List<Order>();
        public List<Order> Get_Ready() { return ready; }
        List<Order> packing = new List<Order>();
        public List<Order> Get_Packing() { return packing; }
        List<Order> cooking = new List<Order>();
        public List<Order> Get_Cooking() { return cooking; }
        List<Order> created = new List<Order>();
        public List<Order> Get_Created() { return created; }

        public void Create(Order z)
        {
            created.Add(z);
        }
        public void Cook(Order z)
        {
            created.Remove(z);
            cooking.Add(z);
        }
        public void Pack(Order z)
        {
            cooking.Remove(z);
            packing.Add(z);
        }
        public void Wait(Order z)
        {
            packing.Remove(z);
            ready.Add(z);
        }
        public void Done(Order z)
        {
            ready.Remove(z);
        }
    }

    class Order
    {
        int id;
        string type;

        public Order(int n, string t)
        {
            id = n;
            type = t;
        }
        public bool GetId(int n)
        {
            if (n == id)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void GetOrder()
        {
            Console.WriteLine("№ заказа: " + id + " (" + type + ") ");
        }
    }
}

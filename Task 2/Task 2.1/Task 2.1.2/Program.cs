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
            Programa p = new Programa();
            p.Main_Menu();
        }
    }

    public class Programa
    {
        Canvas canvas = new Canvas();

        public void Main_Menu()
        {
            int input = 0;
            do
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Добавить фигуру");
                Console.WriteLine("2. Вывести фигуры");
                Console.WriteLine("3. Очистить холст");
                Console.WriteLine("4. Выход");
                try
                {
                    input = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    input = 0;
                }
            } while (input < 1 || input > 4);
            switch (input)
            {
                case 1:
                    Select_Figure();
                    break;
                case 2:
                    canvas.Show_Figures();
                    Main_Menu();
                    break;
                case 3:
                    canvas.Clear_Canvas();
                    Main_Menu();
                    break;
                case 4: break;
                default: break;
            }
        }

        public void Select_Figure()
        {
            int input = 0;
            do
            {
                Console.WriteLine("Выберите фигуру");
                Console.WriteLine("1. Добавить линию");
                Console.WriteLine("2. Добавить окружность");
                Console.WriteLine("3. Добавить круг");
                Console.WriteLine("4. Добавить кольцо");
                Console.WriteLine("5. Добавить треугольник");
                Console.WriteLine("6. Добавить квадрат");
                Console.WriteLine("7. Добавить прямоугольник");
                Console.WriteLine("8. Выход");
                try
                {
                    input = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    input = 0;
                }
            } while (input < 1 || input > 8);
            switch (input)
            {
                case 1:
                    canvas.Add_Line();
                    Main_Menu();
                    break;
                case 2:
                    canvas.Add_Circumference();
                    Main_Menu();
                    break;
                case 3:
                    canvas.Add_Circle();
                    Main_Menu();
                    break;
                case 4:
                    canvas.Add_Ring();
                    Main_Menu();
                    break;
                case 5:
                    canvas.Add_Triangle();
                    Main_Menu();
                    break;
                case 6:
                    canvas.Add_Square();
                    Main_Menu();
                    break;
                case 7:
                    canvas.Add_Rectangle();
                    Main_Menu();
                    break;
                case 8:
                    Main_Menu();
                    break;
                default: break;
            }
        }
    }

    public class Canvas
    {
        private List<FigureWithoutArea> figures = new List<FigureWithoutArea>();

        public void Add_Line()
        {
            bool next = false;
            int input_x_1 = 0;
            int input_y_1 = 0;
            int input_x_2 = 0;
            int input_y_2 = 0;
            do
            {
                Console.WriteLine("Ввведите координату X начала прямой");
                try
                {
                    input_x_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату Y начала прямой");
                try
                {
                    input_y_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату X конца прямой");
                try
                {
                    input_x_2 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату Y конца прямой");
                try
                {
                    input_y_2 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            figures.Add(new Line(input_x_1, input_y_1, input_x_2, input_y_2));
            Console.WriteLine("Линия создана");
        }

        public void Add_Circumference()
        {
            bool next = false;
            int input_x_1 = 0;
            int input_y_1 = 0;
            int input_r = 0;
            do
            {
                Console.WriteLine("Ввведите координату X центра окружности");
                try
                {
                    input_x_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату X центра окружности");
                try
                {
                    input_y_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите радиус окружности");
                try
                {
                    input_r = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            figures.Add(new Circumference(input_x_1, input_y_1, input_r));
            Console.WriteLine("Окружность создана");
        }

        public void Add_Circle()
        {
            bool next = false;
            int input_x_1 = 0;
            int input_y_1 = 0;
            int input_r = 0;
            do
            {
                Console.WriteLine("Ввведите координату X центра круга");
                try
                {
                    input_x_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату X центра круга");
                try
                {
                    input_y_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите радиус круга");
                try
                {
                    input_r = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            figures.Add(new Circle(input_x_1, input_y_1, input_r));
            Console.WriteLine("Круг создан");
        }

        public void Add_Ring()
        {
            bool next = false;
            int input_x_1 = 0;
            int input_y_1 = 0;
            int input_r = 0;
            int input_r_s = 0;
            do
            {
                Console.WriteLine("Ввведите координату X центра кольца");
                try
                {
                    input_x_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату Y центра кольца");
                try
                {
                    input_y_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите больший радиус кольца");
                try
                {
                    input_r = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите меньший радиус кольца");
                try
                {
                    input_r_s = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            figures.Add(new Ring(input_x_1, input_y_1, input_r, input_r_s));
            Console.WriteLine("Кольцо создано");
        }

        public void Add_Triangle()
        {
            bool next = false;
            int input_x_1 = 0;
            int input_y_1 = 0;
            int input_x_2 = 0;
            int input_y_2 = 0;
            int input_x_3 = 0;
            int input_y_3 = 0;
            do
            {
                Console.WriteLine("Ввведите координату X первой точки");
                try
                {
                    input_x_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату Y первой точки");
                try
                {
                    input_y_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату X второй точки");
                try
                {
                    input_x_2 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату Y второй точки");
                try
                {
                    input_y_2 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату X третьей точки");
                try
                {
                    input_x_3 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату Y третьей точки");
                try
                {
                    input_y_3 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            figures.Add(new Triangle(input_x_1, input_y_1, input_x_2, input_y_2, input_x_3, input_y_3));
            Console.WriteLine("Треугольник создан");
        }

        public void Add_Square()
        {
            bool next = false;
            int input_x_1 = 0;
            int input_y_1 = 0;
            int input_a = 0;
            do
            {
                Console.WriteLine("Ввведите координату X левой нижней точки квадрата");
                try
                {
                    input_x_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату X левой нижней точки квадрата");
                try
                {
                    input_y_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите сторону квадрата");
                try
                {
                    input_a = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            figures.Add(new Square(input_x_1, input_y_1, input_a));
            Console.WriteLine("Квадрат создан");
        }

        public void Add_Rectangle()
        {
            bool next = false;
            int input_x_1 = 0;
            int input_y_1 = 0;
            int input_h = 0;
            int input_w = 0;
            do
            {
                Console.WriteLine("Ввведите координату X левой нижней точки прямоугольника");
                try
                {
                    input_x_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите координату Y левой нижней точки прямоугольника");
                try
                {
                    input_y_1 = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Ввведите высотц прямоугольника");
                try
                {
                    input_h = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            next = false;
            do
            {
                Console.WriteLine("Введите ширину прямоугольника");
                try
                {
                    input_w = Int32.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }
            } while (!next);
            figures.Add(new Rectangle(input_x_1, input_y_1, input_h, input_w));
            Console.WriteLine("Прямоугольник создан");
        }

        public void Show_Figures()
        {
            if (figures == null || figures.Count == 0)
            {
                Console.WriteLine("Холст пустой");
            }
            else
            {
                Console.WriteLine("Фигуры на холсте");
                for (int i = 0; i < figures.Count; i++)
                {
                    Console.WriteLine(i + 1 + " -----");
                    figures[i].Display();
                }
            }
        }

        public void Clear_Canvas()
        {
            Console.WriteLine("Холст очищен");
            figures = null;
        }
    }
}

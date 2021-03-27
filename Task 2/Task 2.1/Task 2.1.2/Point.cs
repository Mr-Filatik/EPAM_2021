using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Point
    {
        private int coordinate_x;
        private int coordinate_y;
        public int X { get { return coordinate_x; } }
        public int Y { get { return coordinate_y; } }

        public Point(int x, int y)
        {
            coordinate_x = x;
            coordinate_y = y;
        }
    }

    public abstract class FigureWithoutArea
    {
        private Point point_start;
        public Point Point_Start { get { return point_start; } }

        public FigureWithoutArea(int x, int y)
        {
            point_start = new Point(x, y);
        }

        public virtual double Perimeter_External()
        {
            return 0;
        }

        public virtual void Display()
        {
            
        }
    }

    public class Line : FigureWithoutArea
    {
        private Point point_end;
        public Point Point_End { get { return point_end; } }

        public Line(int x_s, int y_s, int x_e, int y_e) : base(x_s, y_s)
        {
            point_end = new Point(x_e, y_e);
        }

        public override double Perimeter_External()
        {
            return Math.Sqrt(Math.Pow(Point_Start.X - Point_End.X, 2) + Math.Pow(Point_Start.Y - Point_End.Y, 2));
        }

        public override void Display()
        {
            Console.WriteLine("Линия (" + Point_Start.X + ";" + Point_Start.Y + ") (" + point_end.X + ";" + point_end.Y + ")");
            Console.WriteLine("Длина " + Perimeter_External());
        }
    }

    public class Circumference : FigureWithoutArea
    {
        private int radius;
        public int Radius { get { return radius; } }

        public Circumference(int x_s, int y_s, int r) : base(x_s, y_s)
        {
            radius = r;
        }

        public override double Perimeter_External()
        {
            return 2 * Math.PI * radius;
        }

        public override void Display()
        {
            Console.WriteLine("Окружность с центром (" + Point_Start.X + ";" + Point_Start.Y + "), радиусом " + radius);
            Console.WriteLine("Длина окружности " + Perimeter_External());
        }
    }

    public abstract class FigureWithArea : FigureWithoutArea
    {
        public FigureWithArea(int x, int y) : base(x, y) 
        { 
        
        }

        public virtual double Area()
        {
            return 0;
        }
    }

    public class Circle : FigureWithArea
    {
        private int radius;
        public int Radius { get { return radius; } }

        public Circle(int x_s, int y_s, int r) : base(x_s, y_s)
        {
            radius = r;
        }

        public override double Perimeter_External()
        {
            return 2* Math.PI * radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public override void Display()
        {
            Console.WriteLine("Круг с центром (" + Point_Start.X + ";" + Point_Start.Y + "), радиусом " + radius);
            Console.WriteLine("Периметр круга " + Perimeter_External());
            Console.WriteLine("Площадь круга " + Area());
        }
    }

    public class Ring : Circle
    {
        private int radius_small;
        public int Radius_Small { get { return radius_small; } }

        public Ring(int x_s, int y_s, int r, int r_s) : base(x_s, y_s, r)
        {
            radius_small = r_s;
        }

        public override double Perimeter_External()
        {
            return 2 * Math.PI * Radius;
        }

        public double Perimeter_Interior()
        {
            return 2 * Math.PI * radius_small;
        }

        public double Perimeter_Full()
        {
            return Perimeter_External() + Perimeter_Full();
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2) - Math.PI * Math.Pow(radius_small, 2);
        }

        public override void Display()
        {
            Console.WriteLine("Кольцо с центром (" + Point_Start.X + ";" + Point_Start.Y + "), радиусами " + Radius + " и " + radius_small);
            Console.WriteLine("Больший периметр " + Perimeter_External());
            Console.WriteLine("Меньший периметр " + Perimeter_Interior());
            Console.WriteLine("Полный периметр " + Perimeter_Full());
            Console.WriteLine("Площадь кольца " + Area());
        }
    }

    public class Triangle : FigureWithArea
    {
        private Point point_two;
        private Point point_three;
        public Point Point_two { get { return point_two; } }
        public Point Point_three { get { return point_three; } }

        public Triangle(int x_1, int y_1, int x_2, int y_2, int x_3, int y_3) : base(x_1, y_1)
        {
            point_two = new Point(x_2, y_2);
            point_three = new Point(x_3, y_3);
        }

        public override double Perimeter_External()
        {
            return Math.Sqrt(Math.Pow(Point_Start.X - point_two.X, 2) + Math.Pow(Point_Start.Y - point_two.Y, 2)) +
                Math.Sqrt(Math.Pow(point_two.X - point_three.X, 2) + Math.Pow(point_two.Y - point_three.Y, 2)) +
                Math.Sqrt(Math.Pow(point_three.X - Point_Start.X, 2) + Math.Pow(point_three.Y - Point_Start.Y, 2));
        }

        public override double Area()
        {
            double semi_periemeter = Perimeter_External() / 2;
            return Math.Sqrt(semi_periemeter * 
                (semi_periemeter - Math.Sqrt(Math.Pow(Point_Start.X - point_two.X, 2) + Math.Pow(Point_Start.Y - point_two.Y, 2))) * 
                (semi_periemeter - Math.Sqrt(Math.Pow(point_two.X - point_three.X, 2) + Math.Pow(point_two.Y - point_three.Y, 2))) * 
                (semi_periemeter - Math.Sqrt(Math.Pow(point_three.X - Point_Start.X, 2) + Math.Pow(point_three.Y - Point_Start.Y, 2))));
        }

        public override void Display()
        {
            Console.WriteLine("Треугольник (" + Point_Start.X + ";" + Point_Start.Y + ") (" + point_two.X + ";" + point_two.Y + ") (" + point_three.X + ";" + point_three.Y + ")");
            Console.WriteLine("Периметр " + Perimeter_External());
            Console.WriteLine("Площадь " + Area());
        }
    }

    public class Square : FigureWithArea
    {
        private int side_height;
        public int Side_Height { get { return side_height; } }

        public Square(int x_s, int y_s, int s_h) : base(x_s, y_s)
        {
            side_height = s_h;
        }

        public override double Perimeter_External()
        {
            return 4 * side_height;
        }

        public override double Area()
        {
            return Math.Pow(side_height, 2);
        }

        public override void Display()
        {
            Console.WriteLine("Квадрат (нижняя левая точка (" + Point_Start.X + ";" + Point_Start.Y + ")), сторона квадрат" + side_height);
            Console.WriteLine("Периметр " + Perimeter_External());
            Console.WriteLine("Площадь " + Area());
        }
    }

    public class Rectangle : Square
    {
        private int side_width;
        public int Side_Width { get { return side_width; } }

        public Rectangle(int x_s, int y_s, int s_h, int s_w) : base(x_s, y_s, s_h)
        {
            side_width = s_w;
        }

        public override double Perimeter_External()
        {
            return 4 * (Side_Height + side_width);
        }

        public override double Area()
        {
            return side_width * Side_Height;
        }

        public override void Display()
        {
            Console.WriteLine("Прямоугольник (нижняя левая точка (" + Point_Start.X + ";" + Point_Start.Y + ")), высота " + Side_Height + ", ширина " + side_width);
            Console.WriteLine("Периметр " + Perimeter_External());
            Console.WriteLine("Площадь " + Area());
        }
    }
}

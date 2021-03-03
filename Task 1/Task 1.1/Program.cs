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
            Console.ForegroundColor = ConsoleColor.Green;


            Rectangle();
            //Triangle();
            //Another_Triangle();
            //X_Mas_Tree();
            //Sum_Of_Numbers();
            //Font_Adjustment();
            //Array_Processing();
            //No_Positive();
            //Non_Negative_Sum();
            //Array_2D();
        }

        public static void Rectangle()
        {
            try
            {
                Console.WriteLine("Enter the width of the rectangle");
                double width = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the height of the rectangle");
                double height = Convert.ToDouble(Console.ReadLine());
                if (width > 0 && height > 0)
                {
                    Console.WriteLine("The area of the rectangle is " + width * height);
                }
                else
                {
                    Console.WriteLine("Incorrect data entered");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect data entered");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void Triangle()
        {
            try
            {
                Console.WriteLine("Enter the number N");
                uint n = Convert.ToUInt32(Console.ReadLine());
                if (n > 0)
                {
                    string str = "*";
                    for (uint i = 1; i <= n; i++)
                    {
                        Console.WriteLine(str);
                        str += "*";
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect data entered");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect data entered");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void Another_Triangle()
        {
            try
            {
                Console.WriteLine("Enter the number N");
                uint n = Convert.ToUInt32(Console.ReadLine());
                if (n > 0)
                {
                    string str = "*";
                    for (uint i = 1; i <= n; i++)
                    {
                        for (uint j = n - i; j > 0; j--)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine(str);
                        str += "**";
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect data entered");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect data entered");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void X_Mas_Tree()
        {
            try
            {
                Console.WriteLine("Enter the number N");
                int n = Convert.ToInt32(Console.ReadLine());
                if (n > 0)
                {
                    string str;
                    for (int m = 1; m <= n; m++)
                    {
                        str = "*";
                        for (int i = 1; i <= m; i++)
                        {
                            for (int j = n - i; j > 0; j--)
                            {
                                Console.Write(" ");
                            }
                            Console.WriteLine(str);
                            str += "**";
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect data entered");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect data entered");
            }
            finally
            {
                Console.ReadKey();
            }
            
        }

        public static void Sum_Of_Numbers()
        {
            try
            {
                int min_3 = 3;
                int max_3 = 999;
                int min_5 = 5;
                int max_5 = 995;
                int min_15 = 15;
                int max_15 = 990;
                double sum = 0;
                sum += (min_3 + max_3) * (max_3 / (float)(2 * min_3));
                sum += (min_5 + max_5) * (max_5 / (float)(2 * min_5));
                sum -= (min_15 + max_15) * (max_15 / (float)(2 * min_3 * min_5));
                Console.WriteLine("The sum is " + sum);
            }
            catch
            {
                Console.WriteLine("Incorrect data entered");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void Font_Adjustment()
        {
            try
            {
                byte style = 0;
                byte i = 0;
                while (true)
                {
                    Console.Write("Signature options: ");
                    i = style;
                    bool flag = false;
                    if (i == 0)
                    {
                        Console.Write("None");
                    }
                    if (i % 2 == 1)
                    {
                        flag = true;
                        Console.Write("Bold");
                        i--;
                    }
                    if (i % 4 == 2)
                    {
                        if (flag) { Console.Write(", "); }
                        flag = true;
                        Console.Write("Italic");
                        i -= 2;
                    }
                    if (i % 8 == 4)
                    {
                        if (flag) { Console.Write(", "); }
                        Console.Write("Underline");
                        i -= 4;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Enter:");
                    Console.WriteLine("    1: Bold");
                    Console.WriteLine("    2: Italic");
                    Console.WriteLine("    3: Underline");
                    i = Convert.ToByte(Console.ReadLine());
                    if (i > 0 && i < 4)
                    {
                        if ((style % Math.Pow(2, i)) < Math.Pow(2, i - 1)) 
                        { 
                            style += (byte)Math.Pow(2, i - 1); 
                        } 
                        else 
                        { 
                            style -= (byte)Math.Pow(2, i - 1); 
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect data entered");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Incorrect data entered");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void Array_Processing()
        {
            try
            {
                Console.WriteLine("Enter the length of the array");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the maximum deviation of the spread of numbers");
                int max_random = Convert.ToInt32(Console.ReadLine());
                if (n > 0 && max_random > 0)
                {
                    int[] arr = new int[n];
                    Random random = new Random();
                    for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
                    {
                        arr[i] = random.Next(-max_random, max_random + 1);
                        Console.Write(arr[i] + ";");
                    }
                    Console.WriteLine();
                    int step_value;
                    int empty;
                    int number;
                    for (int i = arr.GetLowerBound(0) + 1; i <= arr.GetUpperBound(0); i++)
                    {
                        step_value = arr[i];
                        number = i;
                        while ((number >= 1) && (arr[number - 1] > step_value))
                        {
                            empty = arr[number - 1];
                            arr[number - 1] = arr[number];
                            arr[number] = empty;
                            number--;
                        }
                    }
                    for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
                    {
                        Console.Write(arr[i] + ";");
                    }
                    Console.WriteLine();
                    int min = arr[arr.GetLowerBound(0)];
                    int max = arr[arr.GetUpperBound(0)];
                    Console.WriteLine("Minimum value of the array is " + min);
                    Console.WriteLine("Maximum value of the array is " + max);
                }
                else
                {
                    Console.WriteLine("Incorrect data entered");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect data entered");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void No_Positive()
        {
            try
            {
                Console.WriteLine("Enter the length of the first array");
                int n_1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the length of the second array");
                int n_2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the length of the third array");
                int n_3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the maximum deviation of the spread of numbers");
                int max_random = Convert.ToInt32(Console.ReadLine());
                if (n_1 > 0 && n_2 > 0 && n_3 > 0 && max_random > 0)
                {
                    int[,,] arr = new int[n_1, n_2, n_3];
                    Random random = new Random();
                    for (int h = arr.GetLowerBound(0); h <= arr.GetUpperBound(0); h++)
                    {
                        for (int w = arr.GetLowerBound(1); w <= arr.GetUpperBound(1); w++)
                        {
                            for (int z = arr.GetLowerBound(2); z <= arr.GetUpperBound(2); z++)
                            {
                                arr[h, w, z] = random.Next(-max_random, max_random + 1);
                                Console.Write(arr[h, w, z] + ";");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    for (int h = arr.GetLowerBound(0); h <= arr.GetUpperBound(0); h++)
                    {
                        for (int w = arr.GetLowerBound(1); w <= arr.GetUpperBound(1); w++)
                        {
                            for (int z = arr.GetLowerBound(2); z <= arr.GetUpperBound(2); z++)
                            {
                                if (arr[h, w, z] > 0)
                                {
                                    arr[h, w, z] = 0;
                                }
                                Console.Write(arr[h, w, z] + ";");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect data entered");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect data entered");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void Non_Negative_Sum()
        {
            try
            {
                Console.WriteLine("Enter the length of the array");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the maximum deviation of the spread of numbers");
                int max = Convert.ToInt32(Console.ReadLine());
                if (n > 0 && max > 0)
                {
                    int[] arr = new int[n];
                    Random random = new Random();
                    for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
                    {
                        arr[i] = random.Next(-max, max + 1);
                        Console.Write(arr[i] + ";");
                    }
                    double sum = 0;
                    for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
                    {
                        if (arr[i] >= 0)
                        {
                            sum += arr[i];
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("The sum of the non-negative elements of the array is " + sum);
                }
                else
                {
                    Console.WriteLine("Incorrect data entered");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect data entered");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void Array_2D()
        {
            try
            {
                Console.WriteLine("Enter the length of the first array");
                int n_1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the length of the second array");
                int n_2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the maximum deviation of the spread of numbers");
                int max = Convert.ToInt32(Console.ReadLine());
                if (n_1 > 0 && n_2 > 0 && max > 0)
                {
                    int[,] arr = new int[n_1, n_2];
                    Random random = new Random();
                    for (int h = arr.GetLowerBound(0); h <= arr.GetUpperBound(0); h++)
                    {
                        for (int w = arr.GetLowerBound(1); w <= arr.GetUpperBound(1); w++)
                        {
                            arr[h, w] = random.Next(-max, max + 1);
                            Console.Write(arr[h, w] + ";");
                        }
                        Console.WriteLine();
                    }
                    double sum = 0;
                    for (int h = arr.GetLowerBound(0); h <= arr.GetUpperBound(0); h++)
                    {
                        for (int w = h % 2; w <= arr.GetUpperBound(1); w += 2)
                        {
                            sum += arr[h, w];
                        }
                    }
                    Console.WriteLine("The sum of the elements of the array is " + sum);
                }
                else
                {
                    Console.WriteLine("Incorrect data entered");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect data entered");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            int decision = 0;
            double a, b, c;
            string[] quadratics;
            string values = "";
            bool repeat = false;

            splashScreen();
            do
            {
                //getting variable values
                decision = choice(decision);
                values = value(values);
                quadratics = values.Split(' ');
                a = Convert.ToDouble(quadratics[0]);
                b = Convert.ToDouble(quadratics[1]);
                c = Convert.ToDouble(quadratics[2]);

                //deciding to find x-ints, vertex or discriminant
                if (decision == 1)
                {
                    Console.WriteLine($"The vertex is {vertex(a, b, c)}");
                }
                else if (decision == 2)
                {
                    Console.WriteLine($"The x-int(s) are, {x_int(a, b, c)}");
                }
                else
                {
                    Console.WriteLine($"The discriminant is {discriminant(a, b, c)}");
                }
                //asking if repeat or not
                repeat = again(repeat);
            } while (repeat);
        }
        public static bool again(bool repeat)
        {
            //variable
            bool invalid;
            int invalidNum = 0;
            //repeat or not
            do
            {
                try
                {
                    Console.WriteLine("Press 1 to repeat\nPress 2 to be done");
                    Int32.TryParse(Console.ReadLine(), out invalidNum);
                    invalid = false;
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine("Invalid");
                    invalid = true;
                }
                if (invalidNum < 1 || invalidNum > 2)
                {
                    Console.WriteLine("Invalid");
                }
            } while (invalid && invalidNum < 1 || invalidNum > 2);
            return repeat;
        }

        public static void splashScreen()
        {
            Console.WriteLine("Calculator");
            Console.WriteLine("--------------");
            Console.WriteLine("This program calculates your choice for quadratics using your a, b and c value.");
        }

        public static int choice(int decision)
        {
            //variables
            bool number;
            //decision with error checking
            do
            {
                Console.WriteLine("Press 1 if you want to find the vertex.\nPress 2 if you want to find the x-ints.\n" +
                    "Press 3 if you want to find the discriminant");
                try
                {
                    Int32.TryParse(Console.ReadLine(), out decision);
                    number = true;
                }
                catch (InvalidCastException e)
                {
                    number = false;
                    Console.WriteLine("Invalid");
                }
                if (decision < 1 || decision > 3)
                {
                    Console.WriteLine("Invalid");
                }
            } while (decision < 1 || decision > 3 && number);
            return decision;
        }

        public static string value(string values)
        {
            bool valid;
            double a = 0, b = 0, c = 0;

            //getting a, b and c value
            do
            {
                Console.WriteLine("What is your a value");
                try
                {
                    a = Convert.ToDouble(Console.ReadLine());
                    valid = true;
                }
                catch (InvalidCastException e)
                {
                    valid = false;
                    Console.WriteLine("Invalid");
                }
            } while (!valid);
            do
            {
                Console.WriteLine("What is your b value");
                try
                {
                    b = Convert.ToDouble(Console.ReadLine());
                    valid = true;
                }
                catch (InvalidCastException e)
                {
                    valid = false;
                    Console.WriteLine("Invalid");
                }
            } while (!valid);
            do
            {
                Console.WriteLine("What is your c value");
                try
                {
                    c = Convert.ToDouble(Console.ReadLine());
                    valid = true;
                }
                catch (InvalidCastException e)
                {
                    valid = false;
                    Console.WriteLine("Invalid");
                }
            } while (!valid);
            return ($"{a} {b} {c}");
        }

        public static string vertex(double a, double b, double c)
        {
            //variables
            double x, y;

            x = Math.Round(-b / (2.0 * a), 2);
            y = Math.Round(a * (x * x) + b * x + c, 2);

            return ($"{x}, {y}");
        }

        public static string x_int(double a, double b, double c)
        {
            //variables
            double x1, x2, d;

            //discriminant
            d = b * b - 4.0 * a * c;

            //how many x-ints
            if (d == 0)
            {
                x1 = (-b + Math.Sqrt(b * b - (4.0 * a * c))) / (2.0 * a);
                return ($"{x1}, 0");
            }
            else if (d > 0)
            {
                x1 = (-b + Math.Sqrt(b * b - (4.0 * a * c))) / (2.0 * a);
                x2 = (-b - Math.Sqrt(b * b - (4.0 * a * c))) / (2.0 * a);
                return ($"{x1}, 0 and {x2}, 0");
            }
            else
            {
                return ("There are no x-ints");
            }
        }

        public static double discriminant(double a, double b, double c)
        {
            //variables
            double d;

            //calculation discriminant
            d = Math.Round(b * b - 4.0 * a * c, 2);

            return d;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChM1
{
    class Program
    {
        static double eps = 0.001;
        static double delta = 0.001;
        static double xtemp = 0;
        static double function(double xn) //исходная функция
        {
            return Math.Exp(-xn) - Math.Asin(xn);
        }
        static double functionSecond(double xn) //вторая производная
        {
            return -2 * Math.Sin(xn) + 2;
        }
        static bool checkUO(double xn, double x0) //проверка условия
        {
            return (Math.Abs(xn - x0) <= eps && Math.Abs(function(xn)) <= delta);
        }
        static void MPI() //метод простых итерация
        {
            double c = 0.6;
            double x0 = xtemp, xn = 0.0;

            int n = 0;
            Console.WriteLine("Метод Простых Итераций");
            Console.WriteLine("n        xn          xn+1        delta");
            while (true)
            {
                xn = x0 + c * function(xn); //xn+1
                n++;

                Console.WriteLine("{0}  {1:0.0000000000}  {2:0.0000000000}  {3:0.0000000000}", n, x0, xn, Math.Abs(xn - x0));

                if (checkUO(xn, x0))
                {
                    break;
                }
                else
                {
                    x0 = xn;
                    continue;
                }
            }
        }
        static void MN() // метод Ньютона
        {
            double x0 = xtemp, xn = 0.0;

            int n = 0;
            Console.WriteLine("Метод Ньютона");
            Console.WriteLine("n        xn          xn+1        delta");
            while (true)
            {
                xn = x0 - (2 * Math.Sin(x0) + Math.Pow(x0, 2) - 1.5) / (2 * Math.Cos(x0) + 2 * x0); //xn+1
                n++;

                Console.WriteLine("{0}  {1:0.0000000000}  {2:0.0000000000}  {3:0.0000000000}", n, x0, xn, Math.Abs(xn - x0));

                if ((Math.Abs(xn - x0) <= eps || Math.Abs(function(xn)) <= delta))
                {
                    break;
                }
                else
                {
                    x0 = xn;
                    continue;
                }
            }
        }
        static void Main(string[] args)
        {
        label1:
            Console.WriteLine("Введите начальное приближение: ");
            xtemp = Convert.ToDouble(Console.ReadLine());

            if (function(xtemp) * functionSecond(xtemp) > 0)
            {
                MPI();
                MN();
                MMN();
            }
            else
            {
                goto label1;
            }

            Console.ReadKey();
        }
        static void MMN() // мод. метод Ньютона
        {
            double x0 = xtemp, xn = 0.0;

            int n = 0;
            Console.WriteLine("Модиф. Метод Ньютона");
            Console.WriteLine("n        xn          xn+1        delta");
            while (true)
            {
                xn = x0 - (2 * Math.Sin(x0) + Math.Pow(x0, 2) - 1.5) / (2 * Math.Cos(xtemp) + 2 * xtemp); //xn+1
                n++;

                Console.WriteLine("{0}  {1:0.0000000000}  {2:0.0000000000}  {3:0.0000000000}", n, x0, xn, Math.Abs(xn - x0));

                if ((Math.Abs(xn - x0) <= eps || Math.Abs(function(xn)) <= delta))
                {
                    break;
                }
                else
                {
                    x0 = xn;
                    continue;
                }
            }
        }
    }
}
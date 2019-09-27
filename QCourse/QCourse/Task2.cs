using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCourse
{
    class Task2
    {
        static void Main(string[] args)
        {
            int mint_a, mint_b;
            Console.Write("Задание #2.\nВведите 1-е целое число: ");
            string a = Console.ReadLine();
            Console.Write("Задание #2.\nВведите 2-е целое число: ");
            string b = Console.ReadLine();
            if (int.TryParse(a, out mint_a) && int.TryParse(b, out mint_b))
            {
                Console.WriteLine("НОД этих чисел равен: " + NOD(mint_a, mint_b));
                Console.WriteLine("НОК этих чисел равен: " + NOK(mint_a, mint_b));
            }
            else
            {
                Console.WriteLine("Числа не целочисленные или введены неверно!");
            }
        }
        public static int NOD(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * NOD(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return NOD(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return NOD(a, b / 2);
            return NOD(b, Math.Abs(a - b));
        }
        public static int NOK(int a, int b)
        {
            return Math.Abs(a * b) / NOD(a, b);
        }
    }
}

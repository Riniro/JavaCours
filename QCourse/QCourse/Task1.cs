using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCourse
{
    class Task1
    {
        static void Main(string[] args)
        {
            int mint;
            Console.Write("Задание #1.\nВведите целочисленное число: ");
            string a = Console.ReadLine();
            if (int.TryParse(a, out mint))
            {
                if (Even(mint)) Console.Write("Число чётное, ");
                else Console.Write("Число не чётное, ");
                if (Prime(mint)) Console.WriteLine("Простое.");
                else Console.WriteLine("Состовное.");
            }
            else
            {
                Console.WriteLine("Число не целочисленное или введено неверно!");
            }
        }
        public static bool Prime(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            var num_sqrt = (int)Math.Floor(Math.Sqrt(num));

            for (int i = 3; i <= num_sqrt; i += 2)
                if (num % i == 0)
                    return false;

            return true;
        }
        public static bool Even(int num)
        {
            return (num & 1) == 0;
        }
        
    }
}

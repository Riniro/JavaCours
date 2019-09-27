using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QCourse
{
    class Task4
    {
        static void Main(string[] args)
        {
            int b = 0;
            Console.WriteLine("Введите текст который будет использоваться:");
            string s = Console.ReadLine();
            Console.WriteLine("Введите слово, которое будем искать:");
            string w = Console.ReadLine();
            string pattern = String.Format(@"\b{0}\b", w);
            foreach (Match match in Regex.Matches(s, pattern, RegexOptions.IgnoreCase)) b++;
            Console.WriteLine("Количество слов в строке: " + b);
        }
    }
}

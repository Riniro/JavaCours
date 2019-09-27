using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QCourse
{
    class Task5
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Введите N: ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n < 1 && n > 100) throw new Exception();
            }
            catch { throw new Exception("Не верно введена цифра."); }
            string[] mas = new string[n];
            Console.WriteLine("Введите значения:");
            for (int a = 0; a < n; a++)
            {
                Console.Write("Введите {0} значение: ", a);
                mas[a] = Console.ReadLine();
            }
            //string pattern = String.Format(@"(?<N>.)+.?(?<-N>\k<N>)+(?(N)(?!))");
           // foreach (string st in mas) if (Regex.IsMatch(st, pattern)) Console.WriteLine("Палиндром найден! Это:" + st);
            foreach (string st in mas)
            {
                char[] obrst = st.ToCharArray();
                Array.Reverse(obrst);
                if(st == new string(obrst))
                {
                    Console.WriteLine("Палиндром найден! Это:" + st);
                }
            }
            Console.WriteLine("Программа завершила работу!");
        }
    }
}

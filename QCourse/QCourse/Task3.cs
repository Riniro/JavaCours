using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QCourse
{
    class Task3
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int b;
            Console.WriteLine("Введите текст который будет использоваться:");
            string s = Console.ReadLine();
            // Console.WriteLine(s);
            Console.WriteLine("Выберете необходимое действие:\n1. Подсчёт кол-во слов в тексте.\n2. Отсортировать\n3. Сделать первую букву каждого слова заглавной.");
            try
            {
                b = Convert.ToInt32(Console.ReadLine());
                if (b < 1 && b > 3) throw new Exception();
            }
            catch { throw new Exception("Не верно введена цифра."); }
            string[] st = MassStr(s);
            switch (b)
            {
                case 1:
                    Console.WriteLine("Кол-во слов в тексте: " + st.Length);
                    break;
                case 2:
                    Sort(st);
                    break;
                case 3:
                    Console.WriteLine(OneWord(s));
                    break;
            }
        }
        public static string[] MassStr(string s)
        {
            int k = 0;

            string[] textCount = s.Split(new char[] { ' ' });
            string[] buff = new string[textCount.Length];
            for (int i = 0; i < textCount.Length; i++)
            {
                textCount[i] = textCount[i].Trim(new char[] { '.', ',', '!', '?' });
                if (!string.IsNullOrEmpty(textCount[i]))
                {
                    buff[k] = textCount[i];
                    k++;
                }
            }
            textCount = new string[k];
            for (int i = 0; i < textCount.Length; i++)
            {
                textCount[i] = buff[i];
                //Console.WriteLine(textCount[i]);
            }
            return textCount;
        }
        public static string Sort(string[] s)
        {
            int a;
            Console.WriteLine("Вариант сортировки:\n 1. По количеству букв в слове \n 2. По алфавиту(воз) \n 3. По алфавиту(уб)");
            try
            {
                a = Convert.ToInt32(Console.ReadLine());
                if (a < 1 && a > 3) throw new Exception();
            }
            catch { throw new Exception("Не верно введена цифра."); }
            if (a == 1)
            {
                IEnumerable<string> auto = s.OrderBy(f => f.Length);
                foreach (string str in auto)
                    Console.WriteLine(str);
            }
            if (a == 2)
            {
                IEnumerable<string> auto = s.OrderBy(f => f.Length);
                foreach (string str in auto)
                    Console.WriteLine(str);
            }
            if (a == 3)
            {
                IEnumerable<string> auto = s.OrderByDescending(f => f.Length);
                foreach (string str in auto)
                    Console.WriteLine(str);
            }
            return null;
        }
        public static string OneWord(string str)
        {
            char[] charStr = str.ToCharArray();
            for (int i = 0; i < charStr.Length - 1; i++)
            {
                if (charStr[i] == ' ' && Regex.IsMatch(charStr[i + 1].ToString(), @"[a-z]$"))
                {
                    charStr[i + 1] = char.ToUpper(charStr[i + 1]);

                }
                else if (Regex.IsMatch(charStr[i + 1].ToString(), @"[a-z]$") && i == 0)
                {
                    charStr[0] = char.ToUpper(charStr[0]);
                }
            }

            return new string(charStr);
        }
    }
}

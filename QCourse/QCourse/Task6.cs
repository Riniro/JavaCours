using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCourse
{
    class Item
    {
        private string name;
        private double weight;
        private double price;
        public double otnos;
        public Item(string name, double weight, double price)
        {
            this.name = name;
            this.weight = weight;
            this.price = price;
            this.otnos = price / weight;
        }
        public double GetW()
        {
            return weight;
        }
        public double GetP()
        {
            return price;
        }
        public void getAll()
        {
            Console.WriteLine("{0} - {1} - {2}", name, weight, price);
        }

    }
    class BackPack
    {
        private List<Item> Best = null;
        private double maxWeight;
        private double maxPrice;
        public BackPack(double maxWeight)
        {
            this.maxWeight = maxWeight;
        }
        public double SumWe(List<Item> it)
        {
            double sum = 0;
            foreach (Item w in it)
            {
                sum += w.GetW();
            }
            return sum;
        }
        public double SumPr(List<Item> it)
        {
            double sum = 0;
            foreach (Item w in it)
            {
                sum += w.GetP();
            }
            return sum;
        }

        public List<Item> GetBestSet()
        {
            return Best;
        }
        private void CheckBest(List<Item> itm)
        {
            if ((Best == null) && (SumWe(itm) <= maxWeight))
            {
                Best = itm;
                maxPrice = SumPr(itm);
            }
            else
            {
                if ((SumWe(itm) <= maxWeight) && (SumPr(itm) > maxPrice))
                {
                    Best = itm;
                    maxPrice = SumPr(itm);
                }
            }
        }
        public void Sets(List<Item> it)
        {
            if (it.Count > 0) CheckBest(it);
            for (int i = 0; i < it.Count; i++)
            {
                List<Item> newSet = new List<Item>(it);
                newSet.RemoveAt(i);
                Sets(newSet);
            }
        }
        private void Sets2(List<Item> its)
        {
            if (SumWe(its) < maxWeight)
            {
                Best = its;
                maxPrice = SumPr(its);
            }
            else
            {
                List<Item> newSet = new List<Item>(its);
                newSet.RemoveAt(newSet.Count-1);
                Sets2(newSet);
            }
        }
        public void Sort(List<Item> it)
        {
            it.Sort(delegate (Item i1, Item i2)
            {
                return i2.otnos.CompareTo(i1.otnos);
            });
            Sets2(it);
        }
        public void getAl()
        {
            Console.WriteLine("Общее кол-во груза: {0} \nОбщая цена груза: {1}", SumWe(Best), maxPrice);
        }
    }
    class Task6
    {
        static void Main(string[] args)
        {
            int N,V;
            double M;
            List<Item> items = new List<Item>();
            Console.WriteLine("Добро пожаловать в программу решающую задачу о рюкзаке!\n Данная задача не имеет идеального решения. В данной программе реализовано 2 алгаритма:\n - Метод перебора(точный)\n - Жадный метод(приблеженный)");
            Console.Write("Введите кол-во предметов: ");
            try
            {
                N = Convert.ToInt32(Console.ReadLine());
                if (N < 1) throw new Exception();
                Console.Write("Введите макс вместимость рюкзака: ");
                M = Convert.ToDouble(Console.ReadLine());
                if (M < 1) throw new Exception();
                Console.Write("Каким алгоритмом вы хотели бы решить (1-перебор, 2-жадный): ");
                V = Convert.ToInt32(Console.ReadLine());
                if (V < 1 && V > 2) throw new Exception();
            }
            catch
            {
                throw new Exception("Неверно введено значение!");
            }
            BackPack bp = new BackPack(M);
            Console.WriteLine("Сейчас будет производится ввод всех предметов в виде (Имя - Вес - Цена)");
            for (int a = 0; a < N; a++)
            {
                Console.Write(a + ": ");
                Item it = Preob(Console.ReadLine());
                if (it == null)
                {
                    a--;
                }

                else items.Add(it);
            }
            Console.WriteLine("Все элементы добавлены!");
            Console.WriteLine("Лучшие items:");
            if (V == 1)
            {
                bp.Sets(items);
                foreach (Item it in bp.GetBestSet())
                {
                    it.getAll();
                }
                bp.getAl();
            }
            else
            {
                bp.Sort(items);
                foreach (Item it in bp.GetBestSet())
                {
                    it.getAll();
                }
            }

        }
        public static Item Preob(string s)
        {
            try
            {
                string name, wight, price;
                int a = s.IndexOf('-');
                if (a == -1) throw new Exception();
                name = s.Substring(0, a - 1);
                s = s.Remove(0, a + 2);
                a = s.IndexOf('-');
                if (a == -1) throw new Exception();
                wight = s.Substring(0, a - 1);
                s = s.Remove(0, a + 2);
                price = s.Substring(0, s.Length);
                return new Item(name, Convert.ToDouble(wight), Convert.ToDouble(price));
            }
            catch
            {
                Console.WriteLine("Введено не верно! Попробуйте ещё раз.");
                return null;
            }
        }
    }
}

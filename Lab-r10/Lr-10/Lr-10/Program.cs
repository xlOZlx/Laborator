using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lr_10
{
    class Student { }
    public class Psychic : IComparable, IComparer
    {
        public string Name { get; set; }
        public int CompareTo(object o)
        {
            if (o as Psychic != null)
                return Compare(this, o as Psychic);
            else
                throw new Exception("Impossible to compare 2 objects");
        }
        public int Compare(object x, object y)
        {
            if ((x as Psychic).Name.Length > (y as Psychic).Name.Length)
                return 1;
            else if ((x as Psychic).Name.Length < (y as Psychic).Name.Length)
                return -1;
            else
                return 0;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            //  ЗАДАНИЕ - 1
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nЗАДАНИЕ 1");
            Console.ResetColor();
            ///////////////////////////////
            Console.ForegroundColor = ConsoleColor.Yellow;
            ArrayList list = new ArrayList();
            Random random = new Random();
            list.AddRange(new int[] { random.Next(10), random.Next(10), random.Next(10), random.Next(10), random.Next(10) });
            list.AddRange(new string[] { "test1", "test2", "test3" });
            Student student = new Student();
            list.Add(student);
            list.Remove("test2");
            Console.WriteLine("Count of list elements " + list.Count + "\nMy arrayList: ");
            foreach (object obj in list)
            {
                Console.Write(obj + " ");
            }
            Console.WriteLine("\n" + list.Contains("test1"));
            Console.ResetColor();
            //
            //  ЗАДАНИЕ - 2
            //
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nЗАДАНИЕ 2");
            Console.ResetColor();
            //////////////////////////////////
            Console.ForegroundColor = ConsoleColor.Blue;
            LinkedList<double> list1 = new LinkedList<double>();
            for(int i = 0; i < 10; i++)
            {
                list1.AddFirst(random.Next(15)+0.5);
            }
            foreach (double i in list1)
            {
                Console.Write(i + "; ");
            }
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                list1.RemoveFirst();
            }
            Console.WriteLine("Теперь мой список выглядит так:");
            foreach (double i in list1)
            {
                Console.Write(i + "; ");
            }
            Console.WriteLine();
            int localCount = list1.Count;
            SortedList<int, double> keyValue = new SortedList<int, double>();
            for (int i = 0; i < localCount; i++)
            {
                keyValue.Add(i,list1.ElementAt<double>(i));
            }
            foreach (object obj in keyValue)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine(keyValue.ContainsValue(9));
            Console.ResetColor();
            //
            //  ЗАДАНИЕ - 3
            //
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nЗАДАНИЕ 3");
            Console.ResetColor();
            ///////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            LinkedList<Psychic> group1 = new LinkedList<Psychic>();
            group1.AddFirst(new Psychic {Name = "Криан" });
            group1.AddFirst(new Psychic { Name = "Макс" });
            group1.AddFirst(new Psychic { Name = "Пончик" });
            group1.AddFirst(new Psychic { Name = "Алена" });
            Console.WriteLine("Мои персонажи:");
            foreach (object obj in group1)
            {
                Console.Write((obj as Psychic).Name + ", ");
            }
            Console.WriteLine();

            SortedList<int, Psychic> sortedGroup1 = new SortedList<int, Psychic>();

            localCount = group1.Count;
            for (int i = 0; i < localCount; i++)
            {
                sortedGroup1.Add(i, group1.ElementAt<Psychic>(i));
            }
            Console.WriteLine(sortedGroup1.Count);
            Console.WriteLine("Мой sortedGroup1: ");
            foreach (object obj in sortedGroup1)
            {
                Console.WriteLine(obj);
            }
            Console.ResetColor();
            //
            //  ЗАДАГИЕ - 4
            //
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nЗАДАНИЕ 4");
            Console.ResetColor();
            ////////////////////////////////
            ObservableCollection<Psychic> myGroupPsychic = new ObservableCollection<Psychic>();
            myGroupPsychic.CollectionChanged += CollectionChangeMethod;
            myGroupPsychic.Add(new Psychic { Name = "Криан" });
            myGroupPsychic.Add(new Psychic { Name = "Макс" });
            myGroupPsychic.Add(new Psychic { Name = "Пончик" });
            myGroupPsychic.Add(new Psychic { Name = "Алена" });
            myGroupPsychic.RemoveAt(3);
            Console.WriteLine("\nМоя ОbservableCollection: ");
            foreach (object obj in myGroupPsychic)
            {
                Console.Write(obj + ", ");
            }
            Console.WriteLine();
            Console.ResetColor();
        }
        public static void CollectionChangeMethod(object obj, NotifyCollectionChangedEventArgs n)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Коллекция изменена");
            Console.ResetColor();
        }
    }
}

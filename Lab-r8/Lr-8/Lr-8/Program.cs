using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_8
{
    interface IBase<T>
    {
        void Add(T a);
        void Delete();
        void Look();
    }
    class Numb
    {
        public int number;
        public void AddNumb()
        {
            number = Convert.ToInt32(Console.ReadLine());
        }
    }
    class Matrix<T> : IBase<T> where T : new()
    {
        public T[,] array = new T[10, 10];

        public void Add(T a)
        {
            Console.WriteLine("\nВведите матрицу:");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите элементы {0} строки: ", (i + 1));
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = a;
                }
            }
            Console.WriteLine();
        }
        public void Delete()
        {
            int str;
            int elem;
            Console.WriteLine("enter deleted: ");
            str = Convert.ToInt32(Console.ReadLine());
            elem = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(i == str-1 && j == elem - 1)
                    {
                        array[i, j] = default(T);
                    }
                }
            }
        }
        public void Look()
        {
            Console.WriteLine("\nМатрица: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    class Man
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public void Naming()
        {
            FName = Console.ReadLine();
            LName = Console.ReadLine();
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Matrix<int> arr = new Matrix<int>();
            arr.Add(4);
            arr.Look();
            arr.Delete();
            arr.Look();
            Matrix<Man> arr2 = new Matrix<Man>();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_4
{
    public class Matrix
    {
        public int[,] array = new int[10, 10];
        public int modul;
        public int null_elem = 0;
        Owner info = new Owner();
        Data dat = new Data();

        public Matrix()
        {
            Console.WriteLine("\nВведите матрицу:");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите элементы {0} строки: ", (i + 1));
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine();

            modul = (array[0, 0] * array[1, 1] * array[2, 2]) + (array[1, 0] * array[2, 1] * array[0, 2]) +
                    (array[0, 1] * array[1, 2] * array[2, 0]) - (array[0, 2] * array[1, 1] * array[2, 0]) -
                    (array[0, 1] * array[1, 0] * array[2, 2]) - (array[0, 0] * array[1, 2] * array[2, 1]);


            info.Enter_info();

            Data dat = new Data();
        }
        public void Output()
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

            //Owner info2 = new Owner();
            /*Console.WriteLine("Кол-во нулевых елементов:");
            Console.WriteLine(null_elem);*/
            Console.WriteLine("ID:");
            Console.WriteLine(info.ID);
            Console.WriteLine("ФИО создателя:");
            Console.WriteLine(info.FIO);
            Console.WriteLine("Название компании:");
            Console.WriteLine(info.company);
            Console.WriteLine("Дата создания: ");
            Console.WriteLine(dat.data);
        }

        // вложенный класс Owner

        public class Owner
        {
            public int ID;
            public string FIO;
            public string company;

            public void Enter_info()
            {
                //Console.WriteLine("Введите ID:");
                ID = 290712;
                //Console.WriteLine("Введите ФИО создателя:");
                FIO = "Platov D.A.";
                //Console.WriteLine("Введите название компании:");
                company = "School inc.";
            }
        }

        public class Data
        {
            public string data;

            public Data()
            {
                data = "17.10.2018";
            }
        }

        public int Opr(/*Matrix arry*/)
        {
            int opr;
            opr = (/*arry.*/array[0, 0] * /*arry.*/array[1, 1] * /*arry.*/array[2, 2]) + (/*arry.*/array[1, 0] * /*arry.*/array[2, 1] * /*arry.*/array[0, 2]) +
                  (/*arry.*/array[0, 1] * /*arry.*/array[1, 2] * /*arry.*/array[2, 0]) - (/*arry.*/array[0, 2] * /*arry.*/array[1, 1] * /*arry.*/array[2, 0]) -
                  (/*arry.*/array[0, 1] * /*arry.*/array[1, 0] * /*arry.*/array[2, 2]) - (/*arry.*/array[0, 0] * /*arry.*/array[1, 2] * /*arry.*/array[2, 1]);
            return opr;
        }

        public int Null_elem()
        {
            null_elem = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(array[i, j] == 0)
                    {
                        null_elem++;
                    }
                }
            }
            return null_elem;
        }
        public static implicit operator int(Matrix arry)
        {
            int elem;
            elem = arry.Null_elem();
            return elem;
        }


        // прегрузка минуса

        public static Matrix operator -(Matrix arry, int minus)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arry.array[i, j] = arry.array[i, j] - minus;
                }
            }
            return arry;
        }
        
        // перегрузка инкремента

        public static Matrix operator ++(Matrix arry)
        {
            //Console.WriteLine("\nПроизведен инкремен матрицы: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arry.array[i,j]++;
                }
            }

            return arry;
        }

        // прегрузка сравнения

        public static bool operator !=(Matrix arry1, Matrix arry2)
        {
            if (arry1.modul != arry2.modul)
                return true;
            return false;
        }

        public static bool operator ==(Matrix arry1, Matrix arry2)
        {
            if (arry1.modul == arry2.modul)
                return true;
            return false;
        }
    }
    //
    // Статический класс 
    //
    public static class MathOperation
    {
        public static int numbers;
        public static int min;
        public static int max;
        // поиск минимального элемента
        public static void Minimal(Matrix arr)
        {
            min = arr.array[0, 0];
            
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(min > arr.array[i, j])
                    {
                        min = arr.array[i, j];
                    }
                }
            }
            Console.WriteLine("\nМинимальный элемент матрицы: " + min);
        }
        // поиск максимального элемента
        public static void Maximal(Matrix arr)
        {
            max = arr.array[0, 0];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (max < arr.array[i, j])
                    {
                        max = arr.array[i, j];
                    }
                }
            }
            Console.WriteLine("\nМаксимальный элемент матрицы: " + max);
        }
        // подсчет кол-ва элементтов
        public static void NumbersElem(Matrix arr)
        {
            numbers = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    numbers++;
                }
            }
            Console.WriteLine("\nКол-во элементов в матрице: " + numbers);
        }
    }
    //
    // расширение метода
    //
    public static class ExpationClass
    {
        public static int num_elem;
        static int[] ar_num = new int[10];
        static int stl;
        public static void Say(this string s)
        {
            Console.WriteLine($"\n{s}. Расширенный метод String.");
        }
        // подсчет элементов в строке
        public static void SumStr(this Matrix arr)
        {
            num_elem = 0;
            Console.WriteLine("\n\tПосчет кол-ва элементов в каждой строке.");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    num_elem++;
                }
                Console.WriteLine("Кол-во элементов в {0} строке: {1}", (i + 1), num_elem);
                num_elem = 0;
            }
        }
        // проверка на квадратность матрицы
        public static void Squar(this Matrix arr)
        {
            int prov = 0;
            int num = 0;
            num_elem = 0;
            Console.WriteLine("\n\tПоверка квадратности матрицы.");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    num_elem++;
                }
                ar_num[num] = num_elem;
                num_elem = 0;
                num++;
                stl++;
            }
            for(int k = 0; k < stl; k++)
            {
                if(ar_num[k] == stl)
                {
                    prov++;
                }
            }
            if (prov == stl)
            {
                Console.WriteLine("Матрица -- квадратная.");
            }
            else
            {
                Console.WriteLine("Матрица -- не квадратная.");
            }
        }
    }
    //
    //основаная программа
    //
    class Program
    {
        public static void Main(string[] args)
        {
            Matrix arr1 = new Matrix();
            Matrix arr2 = new Matrix();

            arr1.Output();
            arr2.Output();

            arr1.SumStr();
            string j = "Dima";
            j.Say();

            MathOperation.Minimal(arr1);
            MathOperation.Maximal(arr1);
            MathOperation.NumbersElem(arr1);

            arr1.Squar();

            /*Matrix[] arrMatx = new Matrix[3];
            Matrix arr3 = new Matrix();

            arrMatx[0] = arr1;
            arrMatx[1] = arr2;
            arrMatx[2] = arr3;

            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                arrMatx[i].Output();
            }*/

            

            Console.WriteLine("Вычетание чила из всех элементов матрицы:");
            arr1 = arr1 - 6;

            arr1.Output();

            Console.WriteLine("Инкримент всех элементов матрицы:");
            arr1++;
            arr1.Output();

            Console.WriteLine("\nСравнение модулей на не равенство:");
            Console.WriteLine(arr1 != arr2);

            int a;
            a = arr1;
            Console.WriteLine("\nКол-во нулевых элементов: " + a);

            Console.ReadKey();
        }
    }
}

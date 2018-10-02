using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_2
{
    class Program
    {
        public static void Main(string[] args)
        {
            // 1 -- 1111

            bool jj = true;
            byte aa = 5;
            sbyte ubyte = -32;
            int bb = -1295;
            short cc = -666;
            ushort uns_short = 666;
            long dd = -448820;
            ulong uns_long = 448820; 
            uint uns_int = 1295;

            object obj = 32;

            float ff = 127.7f;
            double gg = 15673.234;

            char smbol = 'A';
            string name = "Dmiriy";
            decimal hh = 632938478;

            Console.WriteLine("Type byte: " + aa);
            Console.WriteLine("Type sbyte: " + ubyte);
            Console.WriteLine("Type int: " + bb);
            Console.WriteLine("Type uint: " + uns_int);
            Console.WriteLine("Type short: " + cc);
            Console.WriteLine("Type ushort: " + uns_short);
            Console.WriteLine("Type long: " + dd);
            Console.WriteLine("Type ulong: " + uns_long);
            Console.WriteLine("Type bool: " + jj);
            Console.WriteLine("Type float: " + ff);
            Console.WriteLine("Type double: " + gg);
            Console.WriteLine("Type char: " + smbol);
            Console.WriteLine("Type string: " + name);
            Console.WriteLine("Type decimale: " + hh);

            // 1 -- 2222

            int df;
            double dg = 138.54;
            df = (int)dg;

            Console.WriteLine("\n\ndouble dg: " + dg);
            Console.WriteLine("double -> int (int df):" + df);

            
            long ni;
            int si = 142198;
            ni = si;

            Console.WriteLine("\nint si: " + si);
            Console.WriteLine("int -> long (long ni):" + ni);

            // 1 -- 3333


            int box = 123;
            object ubox = box;
            ubox = 123;
            double bbox = (int)ubox;

            Console.WriteLine("\n\nUnboxing: " + bbox);

            // 1 -- 4444

            var i = 15;
            var str = "Hello World!";
            var arr = new[] {15, 20, 5, 45};

            Console.WriteLine("\n\nType var - int: " + i);
            Console.WriteLine("Type var - string: " + str);
            foreach (int elm in arr)
            {
                int ii = 1;
                Console.WriteLine("Elrment " + ii + ": " + elm);
                ii++;
            }

            // 1 -- 5555

            Nullable<int> z1 = 5;
            int? z2 = null;

            Console.WriteLine("\n\n" + z1.Value);
            //Console.WriteLine(z2.Value);
            Console.WriteLine(z2.HasValue);

            // 2 -- 1111

            string str1 = "Hello";
            string str2 = "World";
            Console.WriteLine("\n\n" + String.CompareOrdinal(str1, str2));

            //  2 -- 2222

            string str_1 = "My World is my Life";
            string str_2 = "Dmitriy Platov";
            string str_3 = "Knock_knock";

            string str_copy = String.Copy(str_1);
            string str_merg = (str_1 + " " + str_2);
            string substring = str_2.Substring(0,7);
            string[] words = str_3.Split('_');

            Console.WriteLine("\n\nMerger str_1 and str_2: " + str_merg);
            Console.WriteLine("Copy str_1: " + str_copy);
            Console.WriteLine("Substring str_1: " + substring);
            for (int iii = 0; iii < 2; iii++)
            {
                Console.WriteLine(words[iii]);
            }
            Console.WriteLine(str_2.Insert(7," " + substring));

            string substring_2 = str_1.Substring(3, 5);
            Console.WriteLine(str_1.Replace(substring_2, ""));

            // 2 -- 3333

            string str_11 = "";
            string str_null = null;

            Console.WriteLine("\n\n" + String.IsNullOrWhiteSpace(str_11));
            Console.WriteLine(String.IsNullOrEmpty(str_null));

            // 2 - 4444

            StringBuilder sb = new StringBuilder(" Hello World ");
            sb.AppendFormat("!");
            sb.Remove(7, 5);
            sb.Insert(6, " мир");
            sb.Insert(0, " !");

            string s = sb.ToString();
            Console.WriteLine("\n\n" + s);
            
            // 3 - 1111

            int[,] arr_1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Console.WriteLine("\n\n");
            for (int z = 0; z < 3; z++)
            {
                for(int k = 0; k < 3; k++)
                {
                    Console.Write(arr_1[z,k] + " ");
                }
                Console.WriteLine();
            }

            // 3 - 2222

            string[] str_arr = {"hello", "my", "darling", "world"};


            Console.WriteLine("\n\nLength of the array: " + str_arr.Length);
            foreach (string elem in str_arr)
            {
                int i1 = 1;
                Console.WriteLine("Elrment " + i1 + ": " + elem);
                i1++;
            }

            // 3 - 3333

            const int nn = 3, kk = 2, ll = 3, mm = 4;
            int[][] ar = new int[nn][];
            ar[0] = new int[kk];
            ar[1] = new int[ll];
            ar[2] = new int[mm];

            Console.WriteLine("\n\nИсходный массив:");

            int element;

            // Сохранить значения в первом массиве.
            Console.WriteLine("first line:\n");
            for (int i_1 = 0; i_1 < 2; i_1++)
            {
                element = Convert.ToInt32(Console.ReadLine());
                ar[0][i_1] = element;
            }
            // Сохранить значения во втором массиве. 
            Console.WriteLine("two line:\n");
            for (int i_1 = 0; i_1 < 3; i_1++)
            {
                element = Convert.ToInt32(Console.ReadLine());
                ar[1][i_1] = element;
            }
            // Сохранить значения в третьем массиве.
            Console.WriteLine("three line:\n");
            for (int i_1 = 0; i_1 < 4; i_1++)
            {
                element = Convert.ToInt32(Console.ReadLine());
                ar[2][i_1] = element;
            }
            Console.WriteLine();
            // Вывести значения из первого массива. 
            for (int i_1 = 0; i_1 < 2; i_1++)
            {
                Console.Write(ar[0][i_1] + " ");
            }
            Console.WriteLine();
            // Вывести значения из второго массива, 
            for (int i_1 = 0; i_1 < 3; i_1++)
            {
                Console.Write(ar[1][i_1] + " ");
            }
            Console.WriteLine();
            // Вывести значения из третьего массива. 
            for (int i_1 = 0; i_1 < 4; i_1++)
            {
                Console.Write(ar[2][i_1] + " ");
            }
            Console.WriteLine();

            // 3 - 4444

            var ar_var = new[] {1, 10, 100, 1000};
            var str_var = "Platov";

            // 4 - 1111

            /*(int, string, char, string, ulong)*/var person = (age: 25, name: "Tom", symbol: 'C', character: "darling", money: 123456);
            
            // 4 - 3333

            Console.WriteLine("\n\n" + person + "\n");

            Console.WriteLine(person.age);
            Console.WriteLine(person.symbol);
            Console.WriteLine(person.character);

            // 4 - 4444

            var tuple_ub = (10, "hello");
            (int val, string str123) = tuple_ub;

            // 4 - 5555

            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            Console.WriteLine("\n\nComparison of tuples 'left' & 'right': " + left.Equals(right));

            //  5 - function

            int[] ar_fun = { 11, 3, 2, 7, };
            string str_funct = "Dmitriy";

            (int min, int max, int summ, string FirstSymb) Func(int[] a, string str_fun)
            {

                Array.Sort(a);
                int minVal = a[0];
                int maxVal = a[a.Length - 1];

                int sumVal = 0;

                for (int cho = 0; cho < a.Length; cho++)
                {
                    sumVal += a[cho];
                }

                string symb = str_fun.Substring(0,1);

                var ret = (min: minVal, max: maxVal, summ: sumVal, FirstSymb: symb);

                return ret;
            }

            Console.WriteLine("\n\n" + Func(ar_fun, str_funct));

            Console.ReadKey();
        }
    }
}

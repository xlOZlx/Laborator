using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lr_6
{
    public class MyException
    {
        public string str;
        public MyException() { }
        public void ExceptionMethod()
        {
            Console.WriteLine("Введите строку:");
            str = Console.ReadLine();
            if(str == "")
            {
                Console.WriteLine("Неверное значение: пустая строка.\nstr = null.");
                str = null;
            }
            else
            {
                Console.WriteLine($"Значение корректн.\nЗначение строки: {str}");
            }
        }
    }

    public class ArrException : MyException
    {
        public void ArrExceptionMethod()
        {
            int[] array = new int[5];
            Random num = new Random();
            Console.WriteLine("Мой массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = num.Next(0, 20); ;
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("Какой элемент хотите вывести?");
            int ind = Convert.ToInt32(Console.ReadLine());
            if (ind > array.Length || ind < 0)
            {
                Console.WriteLine("Некорректный индекс элемента.");
            }
            else
            {
                Console.WriteLine($"Элемент под номером {ind} равен: {array[ind - 1]}.");
            }
        }
    }
    public class DivisionByZero : ArrException
    {
        public void DivisByZeroMethod()
        {
            Console.WriteLine("Введите значение числителя:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение знаменателя:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num2 == 0)
            {
                Console.WriteLine("Деление на нуль невозможно.");
            }
            else
            {
                Console.WriteLine($"Результат деления: {num1 / num2}");
            }
        }
    }

    public class HeirException : Exception
    {
        public HeirException(string messeg) : base(messeg) { }
    }

    public class Heir
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "")
                {
                    throw new HeirException("\nПустое имя наследника.");
                }
                else
                {
                    name = value;
                }
            }
        }
    }

    public class MyValue
    {
        public void ValueMethod()
        {
            try
            {
                Console.WriteLine("Введите номер: ");
                string myvalue = Console.ReadLine();
                int result = Convert.ToInt32(myvalue);
                Console.WriteLine($"Значение = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nИсключение: " + ex.Message);
                Console.WriteLine("Метод: " + ex.TargetSite);
                Console.WriteLine("Название сборки: " + ex.Source);
                Console.WriteLine("Call address: " + ex.StackTrace);
                Console.WriteLine("Установить значение по умолчанию.\nmyvalue = 0");
            }
        }
    }
    //////////////////////////////////////////
    ////////////ОСНОВНАЯ ПРОГРАММА////////////
    //////////////////////////////////////////

    class Program
    {
        public static void Main(string[] args)
        {
             MyException myException = new MyException();
            myException.ExceptionMethod();

            ArrException arrayException = new ArrException();
            arrayException.ArrExceptionMethod();

            DivisionByZero DZException = new DivisionByZero();
            DZException.DivisByZeroMethod();

            Heir heir = new Heir();
            try
            {
                heir.Name = ""; 
            }
            catch (HeirException ex)
            {
                Console.WriteLine("\nИсключение: " + ex.Message);
                Console.WriteLine("Метод: " + ex.TargetSite);
                Console.WriteLine("Название сборки: " + ex.Source);
                Console.WriteLine("Call address: " + ex.StackTrace);
            }
            finally
            {
                heir.Name = "Krian";
                Console.WriteLine($"Установить имя по умолчанию: {heir.Name}");
            }

            /*int[] arr = null;
            Debug.Assert(arr != null, "Массив значений не может быть нулевым");
            Console.WriteLine("Продолжить");*/

            Console.ReadKey();
        }
    }
}

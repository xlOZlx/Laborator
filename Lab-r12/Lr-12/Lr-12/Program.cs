using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Lr_12
{
    public static class Reflector
    {
        // метод, выводящий содержимое в класс
        public static void OutInfoIntoFile(Type explore)
        {
            using (FileStream fstream = new FileStream(@"E:\\Laborator\note.txt", FileMode.Create))
            {
                foreach (MemberInfo mi in explore.GetMembers())
                {
                    byte[] array = Encoding.Default.GetBytes(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
                    Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
                    fstream.Write(array, 0, array.Length);
                }
                Console.WriteLine("\nИнформация записана в файл.");
            }
        }
        // метод, извлекающий информацию о публичных методах
        public static void ExtractPublicMethods(Type explore)
        {
            MethodInfo[] publicMethods = new MethodInfo[explore.GetMethods().Length];
            int index = 0;
            foreach (MethodInfo method in explore.GetMethods())
            {
                if (method.IsPublic)
                {
                    publicMethods[index] = method;
                    index++;
                }
            }
            Console.WriteLine("Информация о публичных методах:\n");
            foreach (MethodInfo method in publicMethods)
            {
                Console.Write("public " + method.ReturnType.Name + " " + method.Name + " (");
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }
        // метод, получающий информацию о полях и свойствах класса
        public static void ExtractFieldsAndProperties(Type explore)
        {
            Console.WriteLine("Информация о полях и свойствах:\n");
            foreach (FieldInfo field in explore.GetFields())
            {
                Console.WriteLine(field);
            }
            foreach (PropertyInfo property in explore.GetProperties())
            {
                Console.WriteLine(property);
            }
        }
        // метод, получающий все реализованные классом интерфейсы
        public static void ExtractInterfaces(Type explore)
        {
            Console.WriteLine("Информация об интерфейсах:\n");
            foreach (Type i in explore.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
        }
        // метод, выводит по имени класса имена методов, которые содержат заданный (пользователем) тип параметра

        public static void ExtractSpecificMethods(Type explore)
        {
            MethodInfo[] rightMethods = new MethodInfo[explore.GetMethods().Length];
            int index = 0;
            Console.Write("Введите тип параметра: ");
            string parameterType = Console.ReadLine();
            foreach (MethodInfo method in explore.GetMethods())
            {
                bool flag = false;
                foreach (ParameterInfo parameter in method.GetParameters())
                {
                    if (parameter.ParameterType.Name == parameterType)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    rightMethods[index] = method;
                    index++;
                }
            }
            Console.WriteLine("Информация о конкретных методах:\n");
            foreach (MethodInfo method in rightMethods)
            {
                if (method != null)
                {
                    Console.WriteLine(method.Name);
                }
            }
        }
        // метод, вызывает некоторый метод класса, при этом значения для его параметров необходимо прочитать из текстового файла
        public static void MethodСall(string typeName, string methodName)
        {
            using (FileStream fstream = File.OpenRead(@"E:\\Laborator\par.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string parameter = Encoding.Default.GetString(array);
                Type explore = Type.GetType($"Lr_12.{typeName}");
                object obj = Activator.CreateInstance(explore);
                MethodInfo method = explore.GetMethod(methodName);
                Console.WriteLine("MethodCall:");
                method.Invoke(obj, new object[] { parameter });
            }
        }


    }

    public partial class Customer : ICustomer
    {
        public string Name { get; set; }
        public int age;
        public int balanse;

        public void Write()
        {
            Console.WriteLine("Я покупатель.");
        }
        public void Scream(string toScream)
        {
            Console.WriteLine(toScream + "!");
        }

        public double Credit(ref double balanc_in, out double balanc_out)
        {
            double i = balanc_in;
            double plus;
            Console.WriteLine("\nВведите количество зачисленных средств:");
            plus = Convert.ToDouble(Console.ReadLine());
            balanc_out = balanc_in + plus;

            return i;
        }
    }

    interface ICustomer
    {
        string Name { get; set; }
        void Write();
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Type explore = typeof(Customer);
            Reflector.OutInfoIntoFile(explore);
            Console.ReadLine();
            Console.Clear();
            Reflector.ExtractPublicMethods(explore);
            Console.ReadLine();
            Console.Clear();
            Reflector.ExtractFieldsAndProperties(explore);
            Console.ReadLine();
            Console.Clear();
            Reflector.ExtractInterfaces(explore);
            Console.ReadLine();
            Console.Clear();
            Console.Write("Введите имя типа: ");
            explore = Type.GetType($"Lr_12.{Console.ReadLine()}");
            Reflector.ExtractSpecificMethods(explore);
            Console.ReadLine();
            Console.Clear();
            Reflector.MethodСall("Customer", "Scream");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Пример с классом Console");
            Reflector.ExtractPublicMethods(typeof(Console));
            Console.ReadLine();
            Console.Clear();
            Reflector.ExtractFieldsAndProperties(typeof(Console));
            Console.ReadLine();
        }
    }
}

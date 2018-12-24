using System;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

namespace Lr_15
{
    class Program
    {
        private static void Domain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("Сборка загружена.");
        }

        private static void SecondaryDomain_DomainUnload(object sender, EventArgs e)
        {
            Console.WriteLine("Домен выгружен из процесса.");
        }

        //  ДЛЯ ЗАДАНИЯ 3

        public static void NumToConsole()
        {
            Console.WriteLine("Введите кол-во элементов в массиве: ");
            int max = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine(i);
                using (StreamWriter fs = new StreamWriter("NumToConsole.txt", true, Encoding.Default))
                {
                    fs.Write(i + " ");
                }
                Thread.Sleep(400);
            }
        }

        //  ДЛЯ ЗАДАНИЯ 4
        static int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        static object lockerObj = new object();
        public static void OddNumber()
        {
            lock (lockerObj)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0)
                    {
                        Console.WriteLine($"Поток {Thread.CurrentThread.Name}: {numbers[i]}");
                        File.AppendAllText("OddOrEvenNumbers.txt", $"<{numbers[i]}>", Encoding.Default);
                    }
                }
            }
        }

        public static void EvenNumber()
        {
            lock (lockerObj)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        Console.WriteLine($"Поток {Thread.CurrentThread.Name}: {numbers[i]}");
                        File.AppendAllText("OddOrEvenNumbers.txt", $"<{numbers[i]}>", Encoding.Default);
                    }
                }
            }
        }

        static int x = 1;
        static Mutex mutex = new Mutex();
        public static void Count1()
        {
            for (; x < 20;)
            {
                mutex.WaitOne();
                Thread.Sleep(300);
                if (x % 2 == 0)
                {
                    Console.WriteLine($"Поток {Thread.CurrentThread.Name}: {x}");
                    File.AppendAllText("oddandeven.txt", $"<{x}>", Encoding.Default);
                    x++;
                }
                mutex.ReleaseMutex();
            }
        }

        public static void Count2()
        {
            for (; x < 20;)
            {
                mutex.WaitOne();
                Thread.Sleep(100);
                if (x % 2 != 0)
                {
                    Console.WriteLine($"Поток {Thread.CurrentThread.Name}: {x}");
                    File.AppendAllText("oddandeven.txt", $"<{x}>", Encoding.Default);
                    x++;
                }
                mutex.ReleaseMutex();
            }
        }

        //  ДЛЯ ЗАДАНИЯ 5

        public static void Timer(object fake)
        {
            Console.WriteLine("Прошла 1 секунда.");
        }

        public static void Main(string[] args)
        {

            /*====================================================================*/
            ////////////////////////////////////////////////////////////////////////
            ///////////////////////////    ЗАДАНИЕ 1    ////////////////////////////
            ////////////////////////////////////////////////////////////////////////
            /*====================================================================*/

            var allProcess = Process.GetProcesses();

            foreach (Process pr in allProcess)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nId: " + pr.Id + " ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Name: " + pr.ProcessName + " ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Base priority: " + pr.BasePriority + " ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Virtual memory: " + pr.VirtualMemorySize64 + "\n");
                Console.ResetColor();
            }
            Console.ReadKey();
            Console.Clear();

            /*====================================================================*/
            ////////////////////////////////////////////////////////////////////////
            ///////////////////////////    ЗАДАНИЕ 2    ////////////////////////////
            ////////////////////////////////////////////////////////////////////////
            /*====================================================================*/

            AppDomain myDomain = AppDomain.CurrentDomain;
            Assembly[] myAssemblies = myDomain.GetAssemblies();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Имя: " + myDomain.FriendlyName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Детали конфигурации:" + myDomain.BaseDirectory);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Все сборки, загруженные в домен.");
            foreach (Assembly ass in myAssemblies)
            {
                Console.WriteLine(ass.GetName().Name);
            }
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

            AppDomain mySecondDomain = AppDomain.CreateDomain("Мой второй домен");

            mySecondDomain.AssemblyLoad += Domain_AssemblyLoad;
            mySecondDomain.DomainUnload += SecondaryDomain_DomainUnload;

            Console.WriteLine("Домен: {0}", mySecondDomain.FriendlyName);
            mySecondDomain.Load(new AssemblyName("SoapFormatter"));

            Assembly[] mySecondAssemblies = mySecondDomain.GetAssemblies();
            foreach (Assembly asm in mySecondAssemblies)
                Console.WriteLine(asm.GetName().Name);
            AppDomain.Unload(mySecondDomain);
            Console.ReadKey();
            Console.Clear();

            /*=====================================================================*/
            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////    ЗАДАНИЕ 3    ////////////////////////////
            /////////////////////////////////////////////////////////////////////////
            /*=====================================================================*/

            Thread myThread = new Thread(new ThreadStart(NumToConsole)) {Name = "NumToConsole" };
            myThread.Start();
            Thread.Sleep(3500);
            myThread.Suspend();
            Thread.Sleep(1500);
            myThread.Resume();
            Console.WriteLine($"Имя потока: {myThread.Name}\nСтатус потока: {myThread.ThreadState}" +
                $"\nПриоритет потока: {myThread.Priority} \nЧисловой идентификатор: {myThread.ManagedThreadId}");
            Console.ReadKey();
            Console.Clear();

            /*=====================================================================*/
            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////    ЗАДАНИЕ 4    ////////////////////////////
            /////////////////////////////////////////////////////////////////////////
            /*=====================================================================*/

            Thread threadOddNumbers = new Thread(OddNumber) {Name = "OddNumbers" };
            Thread threadEvenNumbers = new Thread(EvenNumber) {Name = "EvenNumbers" };

            threadEvenNumbers.Start();
            threadOddNumbers.Start();

            Console.ReadKey();
            Console.Clear();

            Thread firstThread = new Thread(Count1) { Name = "1" };
            Thread secondThread = new Thread(Count2) { Name = "2" };
            
            secondThread.Start();
            firstThread.Start();

            Console.ReadLine();
            Console.Clear();

            /*=====================================================================*/
            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////    ЗАДАНИЕ 5    ////////////////////////////
            /////////////////////////////////////////////////////////////////////////
            /*=====================================================================*/

            TimerCallback tm = new TimerCallback(Timer);
            Timer timer = new Timer(tm, null, 0, 1000);

            Console.ReadLine();

        }
    }
}

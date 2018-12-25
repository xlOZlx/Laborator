using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lr_16
{
    class Program
    {
        public static int[,] a = new int[35, 35];
        public static int[,] b = new int[35, 35];
        public static int[,] c = new int[35, 35];
        static Random rnd = new Random();

        public static void MultiplicationMatrix()
        {
           Console.WriteLine("Задание первой матрицы А: ");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = rnd.Next(0, 10);
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
            Thread.Sleep(1500);
            Console.WriteLine("Задание первой матрицы B: ");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = rnd.Next(0, 10);
                    Console.Write("{0} ", b[i, j]);
                }
                Console.WriteLine();
            }

            Thread.Sleep(1500);
            Console.WriteLine("\nУмножение матриц в С: ");

            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int k = 0; k < c.GetLength(1); k++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        c[i, k] += a[j, k] * b[i, j];
                    }
                    Console.Write("{0} ", c[i, k]);
                }
                Console.WriteLine();
            }
        }

        public static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i < x+1; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал {x}: {result}");
            return result;
        }

        public static void SecondMethodTask(Task t)
        {
            Console.WriteLine("Это продолжение.");
        }

        public static void ArrayIncialz(int x)
        {
            int[] array1 = new int[10000];
            int[] array2 = new int[10000];

            
            for (int i = 0; i < x; i++)
            {
                array1[i] = rnd.Next(1, 100);
                array2[i] = rnd.Next(1, 100);
            }
        }

        //  ДЛЯ ЗАДАНИЯ 6

        static void DisplayForInvoke()
        {
            Console.WriteLine("Выполняется задача (DisplayForInvoke) {0}", Task.CurrentId);
            Thread.Sleep(3000);
        }

        static void FactorialForInvoke(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine("Выполняется задача (FactorialForInvoke) {0}", Task.CurrentId);
            Thread.Sleep(3000);
            Console.WriteLine("Результат {0}", result);
        }

        public static void Main(string[] args)
        {
            //  ЗАДАНИЕ 1
            Stopwatch sw = new Stopwatch();

            Task taskMultiplicationMatrix = new Task(MultiplicationMatrix);
            sw.Start();
            taskMultiplicationMatrix.Start();

            Console.WriteLine($"ID задачи: {taskMultiplicationMatrix.Id}");
            Console.WriteLine($"\n Состояние задачи: {taskMultiplicationMatrix.Status}");

            Thread.Sleep(1500);
            Console.WriteLine($"ID задачи: {taskMultiplicationMatrix.Id}");
            Console.WriteLine($"\n Состояние задачи: {taskMultiplicationMatrix.Status}");

            taskMultiplicationMatrix.Wait();
            sw.Stop();

            Thread.Sleep(2000);
            Console.WriteLine($"ID задачи: {taskMultiplicationMatrix.Id}");
            Console.WriteLine($"\n Состояние задачи: {taskMultiplicationMatrix.Status}");

            Console.WriteLine($"Время выполнения задачи: {sw.Elapsed}");
            Console.ReadKey();
            Console.Clear();

            // ЗАДАНИЕ 2

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task taskMultiplicationMatrixCancel = new Task(() =>
            {
                Console.WriteLine("Задание первой матрицы А: ");
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        a[i, j] = rnd.Next(0, 10);
                        Console.Write("{0} ", a[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                Thread.Sleep(1500);
                Console.WriteLine("Задание первой матрицы B: ");
                for (int i = 0; i < b.GetLength(0); i++)
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        b[i, j] = rnd.Next(0, 10);
                        Console.Write("{0} ", b[i, j]);
                    }
                    Console.WriteLine();
                }

                Thread.Sleep(1500);

                for (int i = 0; i < c.GetLength(0); i++)
                {
                    for (int k = 0; k < c.GetLength(1); k++)
                    {
                        for (int j = 0; j < a.GetLength(1); j++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                Console.WriteLine("Операция прервана.");
                                return;
                            }
                            c[i, k] += a[j, k] * b[i, j];
                        }
                        Console.Write("{0} ", c[i, k]);
                    }
                    Console.WriteLine();
                }
            });

            Console.WriteLine("CancellationToken:\n\n");
            Console.WriteLine("Наджмите для начала задачи.");
            Console.ReadLine();
            taskMultiplicationMatrixCancel.Start();
            Console.WriteLine("Введите 'Q' или 'q'.");
            string s = Console.ReadLine();
            if (s == "q" || s == "Q")
                cancelTokenSource.Cancel();
            Thread.Sleep(1000);
            Console.WriteLine(taskMultiplicationMatrixCancel.Status);

            Console.ReadLine();
            Console.Clear();

            //  ЗАДАНИЕ 3

            Console.WriteLine("ЗАдание 3");
            Task<int> task1 = new Task<int>(() => Factorial(5));
            Task<int> task2 = new Task<int>(() => Factorial(4));
            Task<int> task3 = new Task<int>(() => Factorial(8));
            task1.Start();
            task2.Start();
            task3.Start();

            Task.WaitAll(task1, task2, task3);
            int result1 = task1.Result;
            int result2 = task2.Result;
            int result3 = task3.Result;

            Func<int> result = () =>
            {
                int summ = 0;
                summ += result1;
                summ += task2.Result;
                summ += result3;
                return summ;
            };
            Task<int> taskToReturn = new Task<int>(result);
            taskToReturn.Start();
            Console.WriteLine($"Сумма трех факториалов: {taskToReturn.Result}");

            Console.ReadLine();
            Console.Clear();

            //  ЗАДНИЕ 4

            Task firstTask = new Task(() =>
            {
                Console.WriteLine("Это первая задача. С помощью ContinueWith.");
            });

            Task secondTask = firstTask.ContinueWith(SecondMethodTask);
            firstTask.Start();
            firstTask.Wait();

            Thread.Sleep(100);
            Console.WriteLine("\nПродолжение с помощью GetAwaiter & GetResult:");

            Task<int> what = Task.Run(() => rnd.Next(10, 20));
            var awaiter = what.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int res = awaiter.GetResult();
                Console.WriteLine("\nРезультат: " + res);
            });

            Console.ReadLine();
            Console.Clear();

            //  ЗАДАНИЕ 5

            int[] arrayA1 = new int[10000];
            int[] arrayB1 = new int[10000];

            sw.Restart();
            for (int i = 0; i < arrayA1.Length; i++)
            {
                arrayA1[i] = rnd.Next(1, 100);
                arrayB1[i] = rnd.Next(1, 100);
            }
            sw.Stop();
            Console.WriteLine($"Время заполнения с помощью for: {sw.Elapsed}");

            int[] arrayA2 = new int[10000];
            int[] arrayB2 = new int[10000];

            Task[] tasksParallel = new Task[2]
            {
                new Task(() => {for(int i = 0; i <= 5000; i++)
                {
                    arrayA2[i] = rnd.Next(1, 100);
                    arrayB2[i] = rnd.Next(1, 100);
                } }),
                 new Task(() => {for(int i = 5001; i < 10000; i++)
                 {
                    arrayA2[i] = rnd.Next(1, 100);
                    arrayB2[i] = rnd.Next(1, 100);
                 } })
            };

            foreach (var t in tasksParallel)
            {
                t.Start();
            }
            sw.Restart();
            Task.WaitAll(tasksParallel);
            sw.Stop();
            Console.WriteLine($"Время работы for в Task: {sw.Elapsed}");

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Начало работы Parallel.For");
            Parallel.For(0, 10000, ArrayIncialz);
            Console.WriteLine("Конец работы Parallel.For");

            Console.WriteLine("Начало работы Parallel.ForEach");

            ParallelLoopResult resultForEach = Parallel.ForEach<int>(new List<int> { 1, 3, 5, 8 }, ArrayIncialz);

            Console.WriteLine("Конец работы Parallel.ForEach " + resultForEach);

            Console.ReadLine();
            Console.Clear();

            //  ЗАДАНИЕ 6

            Parallel.Invoke(DisplayForInvoke,
            () => {
                Console.WriteLine("Выполняется задача (встроенная) {0}", Task.CurrentId);
                Thread.Sleep(3000);
            },
            () => FactorialForInvoke(5));

            Console.ReadLine();
            Console.Clear();

            //  ЗАДАНИЕ 7

            Console.WriteLine("Производитель и клиент:\n");
            int xx = 0;
            BlockingCollection<int> blockcoll = new BlockingCollection<int>();
            for (int producer = 0; producer < 5; producer++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int ii = 0; ii < 3; ii++)
                    {
                        int id = ++xx;
                        blockcoll.Add(id);
                        Console.WriteLine("Producer add " + id);
                        Thread.Sleep(rnd.Next() % 4000);
                    }
                });
            }
            Task consumer = Task.Factory.StartNew(
            () =>
            {
                foreach (var item in blockcoll.GetConsumingEnumerable())
                {
                    Console.WriteLine(" Reading " + item);
                }
            });
            consumer.Wait();

            Console.WriteLine("Выполнение завершено.");

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_11
{
    public class Customer
    {
        public string Name { get; set; }
        public int NumbCard { get; set; }
        public int SumCard { get; set; }
        public int NumPurchase { get; set; }
        public static string[] arrayCustomer = new string[15];
        public static int[] arrayPunchase = new int[15];
        static int number = 0;

        public Customer()
        {
            //Console.WriteLine("Введите имя:");
            //Name = Console.ReadLine();
            //Console.WriteLine("Введите номкр карты:");
            //NumbCard = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Введите кол-во средств на карте");
            //SumCard = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("введите кол-во покупок");
            //NumPurchase = Convert.ToInt32(Console.ReadLine());
            arrayCustomer[number] = Name;
            arrayPunchase[number] = NumPurchase;
            number++;
        }

        public static string[] Sort()
        {
            Array.Sort(arrayCustomer);
            return arrayCustomer;
        }

        public override string ToString()
        {
            return ("\nИмя: " + Name + 
                "\nНомер кредитной карты: " + NumbCard + 
                "\nБаланс: " + SumCard + 
                "\nКол-во покупок: " + NumPurchase);
        }
        public static int MaxPunchase()
        {
            Array.Sort(arrayPunchase);
            return arrayPunchase[arrayPunchase.Length - 1]; 
        }
    }

    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            string[] array = new string[] { "Oktober", "June", "July", "May",
                "December", "September", "January", "February", "Mart", "April", "August", "November" };


            var stringLength = from arr1 in array
                               where arr1.Length == 6
                               select arr1;

            var Request = from arr4 in array
                          where arr4.Contains("mb") && (arr4 == "December" || arr4 == "January" || arr4 == "February")
                          select arr4;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nТребуемы запрос:");
            foreach(string elem in Request)
            {
                Console.WriteLine(elem);
            }
            Console.ResetColor();


            var mounthReturn = from arr2 in array
                               where arr2 == "June" || arr2 == "July" || arr2 == "August"
                               || arr2 == "January" || arr2 == "December" || arr2 == "February"
                               select arr2;

            var mounthAlphabet = from arr3 in array
                                 orderby arr3 ascending
                                 select arr3;

            var lengthAndU = (from arr4 in array
                              where arr4.Contains("u") && arr4.Length >= 4
                              select arr4).Count();
            Console.WriteLine("First request:");
            foreach (string i in stringLength)
            {
                Console.Write($"   {i}");
            }
            Console.WriteLine("\n\nSecond request:");
            foreach (string i in mounthReturn)
            {
                Console.Write($"   {i}");
            }
            Console.WriteLine("\n\nThird request:");
            foreach (string i in mounthAlphabet)
            {
                Console.Write($"   {i}");
            }
            Console.WriteLine($"\n\nFourth request: {lengthAndU}");
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();
            //
            //  ЗАДАНИЕ 2-3
            //

            List<Customer> arrCustomer = new List<Customer>()
            {
                new Customer {Name = "Monika", NumbCard = 4563, NumPurchase = 107, SumCard = 1670},
                new Customer {Name = "Anna", NumbCard = 1041, NumPurchase = 45, SumCard = 5791},
                new Customer {Name = "Freya", NumbCard = 7831, NumPurchase = 61, SumCard = 7890},
                new Customer {Name = "Ersa", NumbCard = 0415, NumPurchase = 78, SumCard = 45680},
                new Customer {Name = "Nina", NumbCard = 9814, NumPurchase = 15, SumCard = 1340},
                new Customer {Name = "Gray", NumbCard = 3145, NumPurchase = 45, SumCard = 4530},
                new Customer {Name = "Krian", NumbCard = 4977, NumPurchase = 64, SumCard = 300500},
                new Customer {Name = "Max", NumbCard = 2678, NumPurchase = 49, SumCard = 225600},
                new Customer {Name = "Jaelit", NumbCard = 3711, NumPurchase = 110, SumCard = 50660},
                new Customer {Name = "Kan", NumbCard = 5168, NumPurchase = 56, SumCard = 31550}
            };
            //for(int i = 0; i < 2; i++)
            //{
            //    arrCustomer.Add(new Customer());
            //}

            var sortCustomer = from u in arrCustomer
                               orderby u.Name
                               select u;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nСортировка покупателей по алфавиту: ");
            Console.ResetColor();
            foreach(Customer u in sortCustomer)
            {
                Console.WriteLine(u);
            }

            var cardNumCustomer = arrCustomer.Where(p => p.NumbCard > 2000 && p.NumbCard < 5000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nСортировка покупателей по номеру карты: ");
            Console.ResetColor();
            foreach (Customer s in cardNumCustomer)
            {
                Console.WriteLine(s);
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nМаксимальное кол-во покупок у покупателя: ");
            Console.ResetColor();
            //var maxPunchase = arrCustomer.Where(c => c.NumPurchase == Customer.MaxPunchase());
            var maxPunchase = (from c in arrCustomer
                              orderby c.NumPurchase descending
                              select c).First();
            Console.WriteLine(maxPunchase);

            var maxSumCardFive = from c in arrCustomer
                                 orderby c.SumCard descending
                                 select c;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nМакисальная сумма у пяти покупателей: ");
            Console.ResetColor();
            foreach (Customer c in maxSumCardFive)
            {
                Console.WriteLine(c);
            }
            //
            // ЗАДАНИЕ 4
            //
            var myRequest = (from c in arrCustomer
                             where (c.NumbCard > 2000 && c.NumbCard < 5000)
                             select c).OrderByDescending(c => c.Name).First();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nМой запрос: {myRequest}");
            Console.ResetColor();
            //
            //  ЗАДАНИЕ 5
            //

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nРабота с Join:");
            Console.ResetColor();
            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Маг", Country ="Группа_1" },
                new Team { Name = "Воин", Country ="Группа_2" }
            };
                        List<Player> players = new List<Player>()
            {
                new Player {Name="криан", Team="Маг"},
                new Player {Name="Риис", Team="Маг"},
                new Player {Name="Макс", Team="Воин"}
            };

            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                          select new { Name = pl.Name, Team = pl.Team, Country = t.Country };

            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1} ({2})", item.Name, item.Team, item.Country);
            }

            Console.ReadKey();
        }
    }
}

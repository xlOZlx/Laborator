using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_3
{

    public partial class Customer
    {
        static int numbers = 0;

        public const int constant = 23;
        public int ID;
        private string surName; // фамилия
        public string name; 
        public string midle_name; // отчество
        public string address; //адрес
        public int card_num; // номер кредитки
        public double balance; // баланс
        
        public string SurName
        {
            get
            {
                return surName;
            }

            set
            {
                surName = value;
            }
        }

        public Customer()
        {
            numbers++;
        }
        public Customer(int id, string surNam, string nam, string mNam, string addr, int cNum, double balc)
        {
            ID = id;
            surName = surNam;
            name = nam;
            midle_name = mNam;
            address = addr;
            card_num = cNum;
            balance = balc;
            numbers++;
        }
        public Customer(int init)
        {
            ID = 1;
            surName = "Pavlov";
            name = "Alexandr";
            midle_name = "Alexeyevich";
            address = "pr.Mira-13_123";
            card_num = 5609;
            balance = 475.6;
            numbers++;
        }
        static Customer()
        {
            Console.WriteLine("Static class create.");
        }
        private Customer(char aa)
        {

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
        public double Withdrawal(ref double balanc_in, out double balanc_out)
        {
            double i = balanc_in;
            double minus;
            Console.WriteLine("\nВведите количество списанных средств:");
            minus = Convert.ToDouble(Console.ReadLine());
            balanc_out = balanc_in - minus;

            return i;
        }
        public static void Info()
        {
            Console.WriteLine("Number of objects: " + numbers);
        }
                                                                                                                                                                        /* public override bool Equals(object obj)
         {
             if (obj == null)
                 return false;
             Customer m = obj as Customer; // возвращает null если объект нельзя привести к типу Money 
             if (m as Customer == null)
                 return false;
             return m.A == this.a && m.B == this.b;
         }*/
        public override string ToString()
        {
            return ("\nID: " + ID + "\nФамилия: "+ SurName + 
                "\nИмя: " + name + "\nОтчество: " + midle_name + 
                "\nАдресс: " + address + "\nНомер кредитной карты: " + card_num + "\nБаланс: " + balance);
        }

        // Сортировка по фамилии

        public static void Sort_SurName(Customer[] arr)
        {
            Customer[] array2 = new Customer[arr.Length];

            string[] Sur_Name = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                Sur_Name[i] = arr[i].SurName;
            }

            Array.Sort(Sur_Name);

            for (int i = 0; i < Sur_Name.Length; i++)
            {
                Console.WriteLine(Sur_Name[i]);
            }

            for (int i = 0; i < Sur_Name.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j].SurName == Sur_Name[i])
                    {
                        array2[i] = arr[j];
                    }
                }
            }

            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine(array2[i]);
            }

        }

        public static void Card_Num(Customer[] arr)
        {
            Customer[] array2 = new Customer[arr.Length];

            string[] Sur_Name = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                Sur_Name[i] = arr[i].SurName;
            }

            Array.Sort(Sur_Name);

            for (int i = 0; i < Sur_Name.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j].SurName == Sur_Name[i])
                    {
                        array2[i] = arr[j];
                    }
                }
            }

            for (int i = 0; i < array2.Length; i++)
            {
                if ((array2[i].card_num > 4000) && (array2[i].card_num < 6000))
                {
                    Console.WriteLine(array2[i]);
                }
            }
        }

    } 

    public partial class Customer
    {
        public void InfoPartial()
        {
            Console.WriteLine("This is a partial class method.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer Alex = new Customer(1);

            double bal_in, bal_out;

            bal_in = Alex.balance;

            Alex.Credit(ref bal_in, out bal_out);
            Console.WriteLine("\nOrigin balance: " + bal_in + "\nChanged balance: " + bal_out);

            Customer Oleg = new Customer(2, "Bulahov", "Oleg", "Dmitrievich", "st.Lenina-18_34", 3457, 641.5);

            Oleg.Withdrawal(ref bal_in, out bal_out);
            Console.WriteLine("\nOrigin balance: " + bal_in + "\nWithdrawal balance: " + bal_out);

            Customer.Info();

            Oleg.InfoPartial();

            Console.WriteLine(Oleg);
            Console.WriteLine(Alex);

            // сравнение

            Customer Cust1 = new Customer();
            Cust1.name = "Ivan";
            Cust1.balance = 34;
            Customer Cust2 = new Customer();
            Cust2.name = "Ivan";
            Cust2.balance = 30;

            Console.WriteLine("\nUsing Equals: " + Cust1.Equals(Cust2));
            Console.WriteLine("\n Тип объекта Gust1: " + Cust1.GetType());

            Customer.Info();

            Customer Max = new Customer();
            Max.ID = 3;
            Max.SurName = "Balinov";
            Max.name = "Maxim";
            Max.midle_name = "Vasilievich";
            Max.address = "st.Victory-4_52";
            Max.card_num = 4381;
            Max.balance = 821.3;

            Customer Veranica = new Customer(2, "Ilinskaya", "Veranika", "Glebovna", "pr.Independence-11_73", 8931, 911.4);

            Customer[] array = new Customer[4];
            array[0] = Alex;
            array[1] = Oleg;
            array[2] = Max;
            array[3] = Veranica;

            // Сортировка по фамилиям
            Console.WriteLine("\nСортировка по фамилиям: ");
            Customer.Sort_SurName(array);

            // список покупателей, у которых
            //номер кредитной карточки находится в заданном интервале

            Console.WriteLine("\nсписок покупателей, у которых " +
                              "\nномер кредитной карточки находится в заданном интервале");
            Customer.Card_Num(array);

            var Nik = new { SurName = "Pochkov" };

            Console.WriteLine("\n Аннонимный объкт" + Nik.SurName);
        }
    }
}

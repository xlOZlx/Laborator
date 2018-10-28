using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_5
{
    // человек
    public abstract class Man
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public abstract void Naming();
    }
    // действия
    interface Inter
    {
        void Hoba();
    }
    interface Inter2
    {
        void Hoba();
    }
    public class Action : Man, Inter, Inter2
    {

        int choise1;
        public bool sleep = false;
        public bool eadinessToFight = false;

        void Inter.Hoba()
        {
            Console.WriteLine("Hoba");
        }       

        void Inter2.Hoba()
        {
            Console.WriteLine("Hoba2");
        }

        // рефлизация абстрактного метода
        public override void Naming()
        {
            Console.WriteLine("Name");
            FName = Console.ReadLine();
            Console.WriteLine("LastName:");
            LName = Console.ReadLine();
        }

        public void Sleep()
        {
            Console.WriteLine("Спит ли человек?");
            choise1 = Convert.ToInt32(Console.ReadLine());
            if(choise1 == 1)
            {
                sleep = true;
                Console.WriteLine("Человек спит.");
            }
            else
            {
                sleep = false;
                Console.WriteLine("Человек бодрствует.");
            }
        }
        public void EadinessToFight()
        {
            Console.WriteLine("Готов ли человек к бою?");
            choise1 = Convert.ToInt32(Console.ReadLine());
            if (choise1 == 1)
            {
                sleep = true;
                Console.WriteLine("Человек готов к бою.");
            }
            else
            {
                sleep = false;
                Console.WriteLine("Человек не готов к бою.");
            }
        }

        //
        // переопределение методов Object
        //

        public override string ToString()
        {
            string str;
            str = "\nСпит - " + sleep + ", готов к бою - " + eadinessToFight;
            return str;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Action a = (Action)obj;
            if (sleep == a.sleep && eadinessToFight == a.eadinessToFight)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        // 5 задание
        public new object GetType()
        {
            if (this is Action)
            {
                return typeof(Action);
            }
            if (this is Psychic)
            {
                return typeof(Psychic);
            }
            if (this is Fighter)
            {
                return typeof(Fighter);
            }
            if (this is Hunter)
            {
                return typeof(Hunter);
            }
            return typeof(object);
        }
    }
    // конец 5

    // экстрасенс
    public class Psychic : Action
    {
        public bool use_force = false;
        int choise2;
        public void UseForce()
        {
            choise2 = Convert.ToInt32(Console.ReadLine());
            if (choise2 == 1)
            {
                use_force = true;
                Console.WriteLine("Использует силу.");
            }
            else
            {
                use_force = false;
                Console.WriteLine("Не использует силу.");
            }
        }
    }
    // шаман
    public class Shaman : Psychic
    {
        string[] future = { "хорошее.", "плохое.", " не удалось увидеть." };
        Random y = new Random();
        int m;
        public void SeeFuture()
        {
            m = y.Next(0, 3);
            Console.WriteLine("Будущее - " + future[m]);
        }
    }
    // боец
    public class Fighter : Psychic
    {
        string[] side = { "с лева", "с права", "с переди", "со спины", "с верху" };
        Random x = new Random();
        int n;
        public void AnticipateAttack()
        {
            n = x.Next(0, 5);
            Console.WriteLine("Атака будет " + side[n]);
        }
    }
    // охотник
    public class Hunter : Action
    {
        string[] _catch = { "куропатка", "олень", "куница", "кабан", "медведь" };
        Random z = new Random();
        int l;

        public void Hunting()
        {
            l = z.Next(0, 5);
            Console.WriteLine("Добыт(а) - " + _catch[l]);
        }
    }
    // лучник
    public sealed class Archer : Action
    {
        Random chance = new Random();
        int rand;
        public void Shot()
        {
            rand = chance.Next(0, 7);
            Console.WriteLine("\nПодготовка к выстрелу...");
            Console.WriteLine("Прицеливание...");
            if(((rand/7)*100) > 60)
            {
                Console.WriteLine("Стрела попала в цель.");
            }
            else
            {
                Console.WriteLine("Срела не попала в цель.");
            }
        }

        class Printer
        {
            public Printer() { }
            public virtual void IAmPrinting(Archer a)
            {
                Console.WriteLine(a.GetType().ToString());
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Archer Numb1 = new Archer();
            Numb1.Shot();
            Numb1.Sleep();
            Numb1.EadinessToFight();
            Console.WriteLine(Numb1.ToString());

            Action Numb3 = new Action();
            Numb3.EadinessToFight();
            Numb3.Sleep();
            Console.WriteLine(Numb3.ToString());
            


            Fighter Numb2 = new Fighter();
            Console.WriteLine("\nПредвидение атаки:");
            Numb2.AnticipateAttack();
            Numb2.Naming();

            Inter inter1 = new Archer();
            inter1.Hoba();
        }
    }
}

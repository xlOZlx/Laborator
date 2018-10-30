using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_6
{
    // человек
    public abstract class Man
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int strength;
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
    //
    // преобразованный в partial
    //
    public partial class Action : Man, Inter, Inter2
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
            Console.WriteLine("Strength:");
            strength = Convert.ToInt32(Console.ReadLine());
        }
        public void Info()
        {
            Console.WriteLine("Name: " + FName);
            Console.WriteLine("LastName: " + LName);
            Console.WriteLine("Strength: " + strength);
        }
        public void Sleep()
        {
            Console.WriteLine("Спит ли человек?");
            choise1 = Convert.ToInt32(Console.ReadLine());
            if (choise1 == 1)
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
            string info;
            info = $"\nName: {FName}\nLastName: {LName}\nStrength: {strength}\n";
            return info;
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
        public Psychic()
        {
            Console.WriteLine("Psychic");
            Naming();
        }
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
        public Shaman()
        {
            Console.WriteLine("Shaman");
            Naming();
        }
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
        public Fighter()
        {
            Console.WriteLine("Fighter");
            Naming();
        }
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
        public Hunter()
        {
            Console.WriteLine("Hunter");
            Naming();
        }
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
        public Archer()
        {
            Console.WriteLine("Archer");
            Naming();
        }
        Random chance = new Random();
        int rand;
        public void Shot()
        {
            rand = chance.Next(0, 7);
            Console.WriteLine("\nПодготовка к выстрелу...");
            Console.WriteLine("Прицеливание...");
            if (((rand / 7) * 100) > 60)
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
    //
    // структура
    //
    struct One
    {
        int one;
        string two;

        public void Enter()
        {
            Console.WriteLine("Ввеите возраст: ");
            one = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ввеите имя: ");
            two = Console.ReadLine();

            Console.WriteLine($"Name: {two}, Age: {one}.");
        }
    }
    //
    // перечисление
    //
    enum Three
    {
        Enter = 1,
        Output,
        Open,
        Close
    }
    ///
    /// контенер
    ///
    public class Army
    {
        public Man[] array = new Man[0];
        public Man Add
        {
            get
            {
                return Add;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("/nВведите корректное значение.");
                }
                else
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = value;
                }
            }
        }
        public Man Del
        {
            get
            {
                return Del;
            }
            set
            {
                Console.WriteLine("/nВведите индекс удаляемого элемента: ");
                int index = Convert.ToInt32(Console.ReadLine());
                for (int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                Array.Resize(ref array, array.Length - 1);
            }
        }
        public Man Out
        {
            get
            {
                return Out;
            }
            set
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine($"/nИнформация о {i}-м элементе");
                    Console.WriteLine(array[i]);
                }
            }
        }
    }

    public class Controller
    {
        public void Task(Army container)
        {
            Man[] warriors = container.array;
            Man[] warriors_sort = new Man[container.array.Length];
            int StrengthAttack = 0;

            for(int i = 0; i < warriors.Length; i++)
            {
                StrengthAttack += warriors[i].strength;
            }
            Console.WriteLine($"Сила атаки армии: {StrengthAttack}");
            int[] strength_arr = new int[warriors.Length];
            for(int j = 0; j < warriors.Length; j++)
            {
                strength_arr[j] = warriors[j].strength; 
            }
            // сортировка по силе
            Array.Sort(strength_arr);
            Console.WriteLine("\nСортировка армии по силе:");
            for(int i = 0; i < strength_arr.Length; i++)
            {
                for(int j = 0; j < warriors.Length; j++)
                {
                    if(warriors[j].strength == strength_arr[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        warriors_sort[i] = warriors[j];
                        Console.ResetColor();
                    }
                }
            }
            for (int j = 0; j < warriors_sort.Length; j++)
            {
                Console.WriteLine(warriors_sort[j]);
            }
            // сильнейший боец в "армии"
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\nСильнейший боец: {warriors_sort[warriors_sort.Length-1]}");
            Console.ResetColor();
        }
    }

    //////////////////////////////////////////
    ////////////ОСНОВНАЯ ПРОГРАММА////////////
    //////////////////////////////////////////

    class Program
    {
        public static void Main(string[] args)
        {
            Three op;
            op = Three.Enter;
            Console.WriteLine(op + "\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            One Num1 = new One();
            Num1.Enter();
            Console.ResetColor();

            Archer Arch1 = new Archer();
            Psychic Psych1 = new Psychic();
            Hunter Hunt1 = new Hunter();

            Army container = new Army();
            Controller controller = new Controller();
            container.Add = Arch1;
            container.Add = Psych1;
            container.Add = Hunt1;
            controller.Task(container);


            Console.ReadKey();
        }
    }
}

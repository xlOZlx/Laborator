using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_9
{
    public delegate void StatusMan(string messege);

    class Game
    {
        public event StatusMan TakingDamage;
        public event StatusMan RecoveryHP;
        public event StatusMan FullHeal;
        public event StatusMan Death;
        public event StatusMan Failure;

        public void Attack(Warrior a)
        {
            int strength = 800;
            a.HP -= strength;
            Console.WriteLine("\nПроизведена атака.");
            if (a.HP > 0)
            {
                //Console.WriteLine 
                TakingDamage($"Боец потерял 800 HP.\nНа данный момент HP: {a.HP}");
            }
            else
            {
                a.death = true;

                //Console.WriteLine
                Death("Боец умер.");
            }

            

        }
        public void Attack(Archer b)
        {
            int strength = 800;
            b.HP -= strength;
            Console.WriteLine("\nПроизведена атака.");
            if (b.HP > 0)
            {
                TakingDamage($"Боец потерял 800 HP.\nНа данный момент HP: {b.HP}");
            }
            else
            {
                b.death = true;
                Death("Боец умер.");
            }
        }
        public void Heal(Warrior a)
        {
            int strength = 680;
            Console.WriteLine("\nПроизведена попытка лечения.");
            if (a.death == true)
            {
                //Console.WriteLine
                Failure("Нельзя лечить мертвого бойца.");
            }
            else
            {
                a.HP += strength;
                if (a.HP > Warrior.point)
                {
                    a.HP = 2000;
                    //Console.WriteLine("Боец польностью исцелен.", (a.HP - Warrior.point));
                    FullHeal("Боец польностью исцелен.");
                }
                else
                {
                    //Console.WriteLine("Боец вылечен на 680 HP.\nНа данный момент HP: {0}", a.HP);
                    RecoveryHP($"Боец вылечен на 680 HP.\nНа данный момент HP: {a.HP}");
                }
            }
        }
        public void Heal(Archer b)
        {
            int strength = 680;
            Console.WriteLine("\nПроизведена попытка лечения.");
            if (b.death == true)
            {
                //Console.WriteLine("Нельзя лечить мертвого бойца.");
                Failure("Нельзя лечить мертвого бойца.");
            }
            else
            {
                b.HP += strength;
                if (b.HP > Warrior.point)
                {
                    b.HP = 2000;
                    //Console.WriteLine("Боец польностью исцелен.", (b.HP - Warrior.point));
                    FullHeal("Боец польностью исцелен.");
                }
                else
                {
                    //Console.WriteLine("Боец вылечен на 680 HP.\nНа данный момент HP: {0}", b.HP);
                    RecoveryHP($"Боец вылечен на 680 HP.\nНа данный момент HP: {b.HP}");
                }
            }
        }
        public void Info(Warrior a)
        {
            if (a.death)
            {
                Console.WriteLine("\nБоец меертв");
            }
            else
            {
                Console.WriteLine("\nHP: {0}", a.HP);
            }
        }
        public void Info(Archer b)
        {
            if (b.death)
            {
                Console.WriteLine("Боец мертв");
            }
            else
            {
                Console.WriteLine("HP: {0}", b.HP);
            }
        }
    }

    public class Warrior
    {
        public const int point = 2000;
        public int HP = 2000;
        public bool death = false;
    }

    public class Archer
    {
        public const int point = 1200;
        public int HP = 1200;
        public bool death = false;
    }

    public delegate void Delg1(Warrior a);
    public delegate void Delg2(Archer b);
    

    class Program
    {
        static void DisplayWithColor(string messege)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(messege);
            Console.ResetColor();
        }
        //
        //// работа со строками
        //
        static void Out(string value)
        {
            Console.WriteLine(value);
        }
        static void FirstWord(string value)
        {
            string[] words = value.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Первое слово: {words[0]}");
        }
        static string Add(int x, string value)
        {
            value = value.Insert(x, ", просто великолепный");
            return value;
        }
        static string Replace(int x, string value)
        {
            if (x == 1)
            {
                value = value.Replace("Добрый, просто ", "");
            }
            else
            {
                value = value.Replace("Добрый, ", "");
            }
            return value;
        }
        static string ToUpperCase(int x, string value)
        {

            if (x == 1)
            {
                return Char.ToUpper(value[0]) + value.Substring(1);
            }
            else
            {
                return value.ToUpper();
            }
        }
        //
        //// главное меню
        //
        public static void Main(string[] args)
        {
            Game game1 = new Game();
            game1.TakingDamage += DisplayWithColor;
            game1.RecoveryHP += DisplayWithColor;
            game1.FullHeal += DisplayWithColor;
            game1.Death += DisplayWithColor;
            game1.Failure += DisplayWithColor;

            ////

            Delg1 DelegatWar = game1.Attack;
            Delg2 DelegatArch = game1.Attack;
            Delg1 InfoWar = game1.Info;
            Delg2 InfoArch = game1.Info;


            ////

            /*Warrior w1 = new Warrior();
            DelegatWar(w1);
            InfoWar(w1);*/


            Warrior w2 = new Warrior();

            DelegatWar(w2);
            DelegatWar(w2);
            DelegatWar(w2);
            InfoWar(w2);
            DelegatWar = game1.Heal;
            DelegatWar(w2);


            Archer arch1 = new Archer();

            DelegatArch(arch1);
            InfoArch(arch1);
            DelegatArch = game1.Heal;
            DelegatArch(arch1);

            //Archer arch2 = new Archer();

            //
            //// работа со строками
            //

            Action<string> action;
            //Action<string> _out = Out;
            //Action<string> _firstWord = FirstWord;
            string value = "Добрый день";
            action = Out;
            action += FirstWord;
            action(value);
            action -= FirstWord;
            Func<int, string, string> func;
            func = Add;
            value = func(6, value);
            action(value);
            func = Replace;
            value = func(1, value);
            action(value);
            func = ToUpperCase;
            value = func(2, value);
            action(value);

            Console.ReadKey();
        }
    }
}

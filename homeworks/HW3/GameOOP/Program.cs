using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Character utiputi = new Character("utiputi", 40, 2);
            Character atip = new Character("atip", 100, 2);
            while (utiputi.IsAlive() && atip.IsAlive())
            {
                utiputi.Attack(atip);
                Console.WriteLine(atip);
                if (!atip.IsAlive())
                {
                    Console.WriteLine($"{atip.Name} умер!");
                    break;
                }
                atip.Attack(utiputi);
                Console.WriteLine(utiputi);
                if (!utiputi.IsAlive())
                {
                    Console.WriteLine($"{utiputi.Name} умер!");
                    break;
                }
            }
            Console.WriteLine(utiputi);
            utiputi.Attack(atip);
            Console.WriteLine(atip);
            atip.Attack(utiputi);
            Console.WriteLine(utiputi);
        }
    }

    class Character
    {
        private string? _name;
        private int _hp;
        private int _power;
        private static int _count;

        public string Name
        {
            get { return _name; } set { }
        }
        public int Hp
        {
            get { return _hp; } set { if (value > 0) _hp = value; else _hp = 0; }
        }
        public int Power
        {
            get {return _power;} set {if (value > 0) _power = value;}
        }
        
        public Character(string n, int h, int p)
        {
            _name = n;   Hp = h;   _power = p;
        }

        public virtual void Attack(Character target)
        {
            target.Hp -= _power;
            Console.WriteLine($"Атака на {target.Name}!");
        }

        public string GetStatus()
        {
            return $"Персонаж {Name} имеет {Hp} очков здоровья";
        }

        public static int HowMany()
        {
            return _count;
        }

        public static void IsValidStats(int hp, int power)
        {
            if (hp >= 0 && power >= 0) Console.WriteLine("Характеристики допустимы."); 
            else                       Console.WriteLine("Характеристики НЕдопустимы."); 
        }
        public bool IsAlive()
        {
            if (Hp > 0) return true;
            else return false;
        }
        public void TakeDamage(int damage) {
            Hp -= damage;

        }
        public override string ToString()
        {
            return $"Player: {Name}, HP: {Hp}, Power: {Power}";
        }

        
    }
    class Player : Character
    {
        public Player(string n, int h, int p) : base(n, h, p) { }

        public int Hp {
            get { return base.Hp;}
            set { if (value > 0 ) base.Hp = value;}
        }  
        public string Name
        {
            get { return base.Name; }
            set { if (value is string) base.Name = value;}
        }

        public override void Attack(Character target)
        {
            int dmg = 2 * base.Power;

            target.TakeDamage(dmg);
        }


    }

    class Enemy : Character
    {
        public Enemy(string n, int h, int p) : base(n, h, p) { }
        public override void Attack(Character target)
        {
            int dmg =  base.Power;

            target.TakeDamage(dmg);
        }
        
    }
    
}




//меняю чуть файл чтобы залить ео в другую branch
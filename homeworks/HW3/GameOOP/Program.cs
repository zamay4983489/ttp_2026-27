using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Character Burmalda = new Character("burmalda", 100, 1);
            Character okak = new Character("okak", 100, 2);
            Console.WriteLine(Burmalda.GetStatus());
            Burmalda.Attack(okak);
            Console.WriteLine(okak.GetStatus());
            Console.WriteLine(Burmalda.GetStatus());
        }
    }

    class Character
    {
        private string? name;
        private int hp;
        private int power;
        private static int count;

        public string Name
        {
            get { return name; } set { }
        }
        public int Hp
        {
            get { return hp; } set { if (value > 0) hp = value; }
        }
        
        public Character(string n, int h, int p)
        {
            name = n;   Hp = h;   power = p;
        }

        public void Attack(Character target)
        {
            target.Hp -= power;
            Console.WriteLine($"Атака на {target.Name}!");
        }

        public string GetStatus()
        {
            return $"Персонаж {name} имеет {Hp} очков здоровья";
        }

        public static int HowMany()
        {
            return count;
        }

        public static void IsValidStats(int hp, int power)
        {
            if (hp >= 0 && power >= 0) Console.WriteLine("Характеристики допустимы."); 
            else                       Console.WriteLine("Характеристики НЕдопустимы."); 
        }
    }
    class Player : Character
    {
        public Player(string n, int h, int p) : base(n, h, p) { }
    }

    class Enemy : Character
    {
        public Enemy(string n, int h, int p) : base(n, h, p) { }
    }
    
}




//меняю чуть файл чтобы залить ео в другую branch
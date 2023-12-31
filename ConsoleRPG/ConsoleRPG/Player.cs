using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Player
    {
        public string Name { get; private set; }
        public string ClassName { get; private set; }
        public int Accuracy { get; private set; }
        public int HitPoints { get; private set; }
        public int MaxHitPoints { get; private set; }
        public int ExpPoints { get; private set; }
        public int NextLevelExp { get; private set; }
        public int Level { get; private set; }
        public int Armor { get; private set; }
        public Weapon Weapon { get; private set; }

        public Player()
        {
            Name = "Default";
            ClassName= "Default";
            Accuracy= 0;
            HitPoints= 0;
            MaxHitPoints= 0;
            ExpPoints= 0;
            NextLevelExp= 0;
            Level= 0;
            Armor = 0;
            Weapon = new Weapon("Default Weapon Name", new Range(0,0));
        }

        public bool IsDead
        {
            get
            {
                return HitPoints <= 0;
            }

            private set { }
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }

        public void CreateClass()
        {
            Console.WriteLine("CHARACTER CLASS GENERATION");
            Console.WriteLine("==========================");

            Console.Write("Enter your character's name: ");
            Name = Console.ReadLine()!;

            Console.WriteLine("Please select a character class number...");
            Console.Write("1)Fighter 2)Wizard 3)Cleric 4)Thief: ");
            int characterNum;
            characterNum = Convert.ToInt32(Console.ReadLine());
            switch(characterNum)
            {
                case 1:
                    ClassName = "Fighter";
                    Accuracy = 10;
                    HitPoints = 20;
                    MaxHitPoints = 20;
                    ExpPoints = 0;
                    NextLevelExp = 1000;
                    Level = 1;
                    Armor = 4;
                    Weapon.Name = "Long Sword";
                    Weapon.DamageRange!.Low = 1;
                    Weapon.DamageRange!.Hight = 8;
                    break;
                case 2:
                    ClassName = "Wizard";
                    Accuracy = 5;
                    HitPoints = 10;
                    MaxHitPoints = 10;
                    ExpPoints = 0;
                    NextLevelExp = 1000;
                    Level = 1;
                    Armor = 1;
                    Weapon.Name = "Staff";
                    Weapon.DamageRange!.Low = 1;
                    Weapon.DamageRange!.Hight = 4;
                    break;
                case 3:
                    ClassName = "Cleric";
                    Accuracy = 8;
                    HitPoints = 15;
                    MaxHitPoints = 15;
                    ExpPoints = 0;
                    NextLevelExp = 1000;
                    Level = 1;
                    Armor = 3;
                    Weapon.Name = "Flail";
                    Weapon.DamageRange!.Low = 1;
                    Weapon.DamageRange!.Hight = 6;
                    break;
                case 4:
                    ClassName = "Thief";
                    Accuracy = 7;
                    HitPoints = 12;
                    MaxHitPoints = 12;
                    ExpPoints = 0;
                    NextLevelExp = 1000;
                    Level = 1;
                    Armor = 2;
                    Weapon.Name = "Short Sword";
                    Weapon.DamageRange!.Low = 1;
                    Weapon.DamageRange!.Hight = 6;
                    break;
            }
        }

        public void Attack(Monster monster)
        {
            int selection;
            Console.WriteLine("1)Attack, 2)Run: ");
            selection = Convert.ToInt32(Console.ReadLine());
            switch(selection)
            {
                case 1:
                    Console.WriteLine($"You attack an {monster.Name} with a {Weapon.Name}");

                    if (Utilities.Random(0, 20) < Accuracy)
                    {
                        int damage = Utilities.Random(Weapon.DamageRange!);
                        int totalDamage = damage - monster.Armor;

                        if (totalDamage <= 0)
                        {
                            Console.WriteLine("Your attack failed to penetrate the armor");
                        }
                        else
                        {
                            Console.WriteLine($"You attack for {totalDamage} damage!");
                            monster.TakeDamage(totalDamage);
                        }
                    }
                    else
                        Console.WriteLine("You miss!");
                    Console.WriteLine();
                    break;
                case 2:
                    int roll = Utilities.Random(1,4);
                    if(roll == 1)
                    {
                        Console.WriteLine("You ran away!");
                        return ;
                    }
                    else
                    {
                        Console.WriteLine("You could not escape!");
                        break;
                    }
            }

        }

        public void LevelUp()
        {
            if(ExpPoints >= NextLevelExp)
            {
                Console.WriteLine("You gained a level!");
                Level++;

                NextLevelExp = Level * Level * 1000;
                Accuracy += Utilities.Random(1, 3);
                MaxHitPoints += Utilities.Random(2, 6);
                Armor += Utilities.Random(1, 2);

                HitPoints = MaxHitPoints;
            }
        }

        public void Rest()
        {
            Console.WriteLine("Resting...");
            HitPoints = MaxHitPoints;
        }

        public void ViewStats()
        {
            Console.WriteLine("PLAYER STATS:");
            Console.WriteLine("=============");
            Console.WriteLine();

            Console.WriteLine($"Name:                   {Name}");
            Console.WriteLine($"Class:                  {ClassName}");
            Console.WriteLine($"Accuracy:               {Accuracy}");
            Console.WriteLine($"Hitpoints:              {HitPoints}");
            Console.WriteLine($"XP:                     {ExpPoints}");
            Console.WriteLine($"XP for Next Level:      {NextLevelExp}");
            Console.WriteLine($"Level:                  {Level}");
            Console.WriteLine($"Armor:                  {Armor}");
            Console.WriteLine($"Weapon Name:            {Weapon.Name}");
            Console.WriteLine($"Weapon Damage:          {Weapon.DamageRange!.Low} - {Weapon.DamageRange.Hight}");

            Console.WriteLine();
            Console.WriteLine("END PLAYER STATS");
            Console.WriteLine("================");
            Console.WriteLine();
        }

        public void Victory(int xp)
        {
            Console.WriteLine("You won the battle!");
            Console.WriteLine($"You won {xp} experience points!");

            ExpPoints += xp;
        }

        public void GameOver()
        {
            Console.WriteLine("You died in battle...");
            Console.WriteLine();
            Console.WriteLine("GAME OVER!");
            Console.WriteLine("Press 'q' to quit");
            char q = Convert.ToChar(Console.ReadKey());
            Console.WriteLine();
        }

        public void DisplayHitPoints()
        {
            Console.WriteLine($"{Name}'s hitpoints = {HitPoints}");
        }
    }
}

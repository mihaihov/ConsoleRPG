using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Monster
    {
        public string Name { get; set; }
        public int HitPoints { get; private set; }
        public int XPReward { get; set; }
        public int Armor { get; set; }
        public Weapon Weapon { get; set; }
        public int Accuracy { get; set; }

        public Monster()
        {
            Name = string.Empty;
            HitPoints = 0;
            Armor = 0;
            XPReward= 0;
            Weapon = new Weapon();
            Accuracy= 0;
        }

        public Monster(string name, int hp, int acc, int xpReward, int armor, string weaponName, int lowDamage, int highDamage)
        {
            Name = name;
            HitPoints = hp;
            Accuracy = acc;
            XPReward = xpReward;
            Armor = armor;
            Weapon = new Weapon(weaponName,new Range(lowDamage, highDamage));
        }

        public bool IsDead
        {
            get
            {
                return HitPoints <= 0;
            }
            private set { }
        }

        public void Attack(Player player)
        {

            Console.WriteLine($"A {Name} attacks you with a {Weapon.Name}");

            if(Utilities.Random(0,20) < Accuracy)
            {
                int damage = Utilities.Random(Weapon.DamageRange!);
                int totalDamage = damage - player.Armor;

                if(totalDamage < 0)
                {
                    Console.WriteLine("The monster's attack failed to penetrate your armor.");
                }
                else
                {
                    Console.WriteLine($"You are hit for {totalDamage} damage!");
                    player.TakeDamage(totalDamage);
                }
            }
            else
            {
                Console.WriteLine($"The {Name} missed!");
            }
            Console.WriteLine();
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }
    }
}

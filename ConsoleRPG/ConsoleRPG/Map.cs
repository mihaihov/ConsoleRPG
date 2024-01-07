using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Map
    {
        public int XPos { get; private set; }
        public int YPos { get; private set; }

        public Map()
        {
            XPos = YPos = 0;
        }

        public Monster CheckRandomEncounter()
        {
            int roll = Utilities.Random(0, 20);
            Monster monster = new Monster();

            if (roll < 5)
                return monster;
            else if (roll >= 6 && roll <= 10)
            {
                monster = new Monster("Orc", 10, 8, 200, 1, "Short Sword", 2, 7);
                Console.WriteLine("You encountered an Orc!");
                Console.WriteLine("Prepare for battle!");
                Console.WriteLine();
            }
            else if (roll >= 11 && roll <= 15)
            {
                monster = new Monster("Goblin", 6, 6, 100, 0, "Dagger", 1, 5);
                Console.WriteLine("You encountered an Goblin!");
                Console.WriteLine("Prepare for battle!");
                Console.WriteLine();
            }
            else if (roll >= 16 && roll <= 19)
            {
                monster = new Monster("Orge", 20, 12, 500, 2, "Club", 3, 8);
                Console.WriteLine("You encountered an Orge!");
                Console.WriteLine("Prepare for battle!");
                Console.WriteLine();
            }
            else if (roll == 20)
            {
                monster = new Monster("Orc Lord", 25, 15, 2000, 5, "Two Handed Sword", 5, 20);
                Console.WriteLine("You encountered an Orc Lord!");
                Console.WriteLine("Prepare for battle!");
                Console.WriteLine();
            }

            return monster;
        }

        public void MovePlayer()
        {
            int selection;
            Console.Write("1)North 2)East 3)South 4)West");
            selection = Convert.ToInt32(Console.ReadLine());

            switch(selection)
            {
                case 1:
                    YPos++;
                    break;
                case 2:
                    XPos++;
                    break;
                case 3:
                    YPos--;
                    break;
                case 4:
                    XPos--;
                    break;
            }

            Console.WriteLine();
        }

        public void PrintPlayerPosition()
        {
            Console.WriteLine($"Player Position = ( {XPos} , {YPos} )");
        }

    }
}

using ConsoleRPG;
using System;
using System.Collections.Specialized;
using System.Xml.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        bool done = false;

        Map gameMap = new Map();
        Player mainPlayer = new Player();
        Monster monster = new Monster();

        mainPlayer.CreateClass();
        while(!done)
        {
            gameMap.PrintPlayerPosition();

            int selection;
            Console.Write("1)Move 2)Rest 3)ViewStates, 4)Quit: ");
            selection = Convert.ToInt32(Console.ReadLine());

            switch(selection)
            {
                case 1:
                    gameMap.MovePlayer();
                    monster = gameMap.CheckRandomEncounter();
                    if(monster.HitPoints > 0)
                    {
                        while(true)
                        {
                            mainPlayer.DisplayHitPoints();
                            Console.WriteLine($"{monster.Name}'s hitpoints = {monster.HitPoints}");
                            bool runAway = mainPlayer.Attack(monster);

                            if (runAway)
                                break;

                            if(monster.IsDead)
                            {
                                mainPlayer.Victory(monster.XPReward);
                                mainPlayer.LevelUp();
                                break;
                            }

                            monster.Attack(mainPlayer);
                            if(mainPlayer.IsDead)
                            {
                                mainPlayer.GameOver();
                                done = true;
                                break;
                            }
                        }
                    }
                    break;
                case 2:
                    mainPlayer.Rest();
                    break;
                case 3:
                    mainPlayer.ViewStats();
                    break;
                case 4:
                    done = true;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.SportApp
{
    public class SportAppMain
    {

        public static void MainEntry()
        {
            Season[] groups = TestSportApp.CreateChampionsLeagueMock();

            bool finish = false;
            
            while (!finish)
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");

                Console.WriteLine("Sport App Menu");
                Console.WriteLine("=====================");
                Console.WriteLine("1. Show League Table");
                Console.WriteLine("2. Play Game");
                Console.WriteLine("0. Exit");
                Console.WriteLine("=====================");
                Console.Write("Enter Choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        TestSportApp.PrintGroupsDetails(groups);
                        break;
                    case 2:
                        PlayGame(groups);
                        break;
                    case 0:
                        finish = true;
                        break;

                }
            }

        }
        private static void PlayGame(Season[] groups)
        {
            int groupIndex, firstTeam, secondTeam;
            Console.Clear();
            Console.WriteLine("Choose League:");
            for (int i=0; i<groups.Length; i++)
            {
                Console.WriteLine(i+1 + ". " + groups[i].getLeague());
            }
            Console.WriteLine("0. Go Back");
            Console.WriteLine();
            Console.Write("Enter choice: ");
            groupIndex = int.Parse(Console.ReadLine()) - 1;
            if (groupIndex < 0) return;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Competition Between:");
            for (int i=0; i < groups[groupIndex].getTeams().Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + groups[groupIndex].getTeams()[i].getName());
            }
            Console.WriteLine("0. Go Back");
            Console.WriteLine();
            Console.Write("Choose First team: ");
            firstTeam = int.Parse(Console.ReadLine()) - 1;
            if (firstTeam < 0) return;
            Console.Write("Choose Second team: ");
            secondTeam = int.Parse(Console.ReadLine()) - 1;
            if (secondTeam < 0) return;

            Play(groups[groupIndex], firstTeam, secondTeam);


        }

        private static void Play(Season group, int firstTeam, int secondTeam)
        {
            bool finish = false;
            Console.Clear();
            Game game = new Game(group.getTeams()[firstTeam], group.getTeams()[secondTeam]);
            string team1Name = game.Team1.getName();
            string team2Name = game.Team2.getName();
            
            while (!finish)
            {
                Console.Clear();
                Console.WriteLine("{0} VS. {1} ({2}-{3})", team1Name, team2Name, game.Team1Goals, game.Team2Goals);
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1.Goal for {0}!!", team1Name);
                Console.WriteLine("2.Goal for {0}!!", team2Name);
                Console.WriteLine("0. Game End");
                Console.WriteLine("-----------------------------");
                Console.Write("Enter Choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        game.ScoreGoal(game.Team1);
                        break;
                    case 2:
                        game.ScoreGoal(game.Team2);
                        break;
                    case 0:
                        finish = true;
                        game.FinishGame();
                        break;
                }
            }
        }
    }
}

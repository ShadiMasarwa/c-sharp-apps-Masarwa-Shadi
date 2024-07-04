using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
                Screen.Clean();

                Console.WriteLine("Sport App Menu");
                Console.WriteLine("=====================");
                Console.WriteLine("1. Show League Table");
                Console.WriteLine("2. Play Game");
                Console.WriteLine("3. Plyer App");
                Console.WriteLine("0. Exit");
                Console.WriteLine("=====================");
                Console.Write("Enter Choice: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        TestSportApp.PrintGroupsDetails(groups);
                        break;
                    case 2:
                        PlayGame(groups);
                        break;
                    case 3:
                        PlayerApp();
                        break;
                    case 0:
                        finish = true;
                        break;

                }
            }

        }
        private static void PlayGame(Season[] groups)
        {
            int groupIndex = 0, firstTeam = 0, secondTeam = 0, i;
            bool correctLeague = false;
            while (!correctLeague)
            {
                Screen.Clean();

                Console.WriteLine("Choose League:");
                Console.WriteLine("=============================");
                for (i = 0; i < groups.Length; i++)
                {
                    Console.WriteLine(i + 1 + ". " + groups[i].GetLeague());
                }
                Console.WriteLine();
                Console.WriteLine("0. Go Back");
                Console.WriteLine("=============================");

                Console.WriteLine();
                Console.Write("Enter choice: ");
                char ch = Console.ReadKey().KeyChar;
                int choice = ch - 48;
                if (choice == 0) return;
                if (choice > 0 && choice <= i)
                {
                    groupIndex = choice - 1;
                    correctLeague = true;
                }

            }


            Screen.Clean();

            Console.WriteLine("Competition Between:");
            Console.WriteLine("=============================");
            for (i = 0; i < groups[groupIndex].GetTeams().Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + groups[groupIndex].GetTeams()[i].getName());
            }
            Console.WriteLine();
            Console.WriteLine("0. Go Back");
            Console.WriteLine("=============================");
            Console.WriteLine();
            bool correctTeamNumber = false;
            while (!correctTeamNumber)
            {
                Console.Write("Choose First team: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                if (choice == 0) return;
                if (choice > 0 && choice <= i)
                {
                    firstTeam = choice - 1;
                    correctTeamNumber = true;
                }

            }
            correctTeamNumber = false;
            while (!correctTeamNumber)
            {
                Console.Write("Choose Second team: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                if (choice == 0) return;
                if (choice > 0 && choice <= i && choice != firstTeam + 1)
                {
                    secondTeam = choice - 1;
                    correctTeamNumber = true;
                }

            }

            Play(groups[groupIndex], firstTeam, secondTeam);


        }

        private static void Play(Season group, int firstTeam, int secondTeam)
        {
            bool finish = false;
            Screen.Clean();
            Game game = new Game(group.GetTeams()[firstTeam], group.GetTeams()[secondTeam]);
            string team1Name = game.Team1.getName();
            string team2Name = game.Team2.getName();

            while (!finish)
            {
                Screen.Clean();

                Console.WriteLine("{0} VS. {1} ({2} - {3})", team1Name, team2Name, game.Team1Goals, game.Team2Goals);
                Console.WriteLine("=============================");
                Console.WriteLine("1. Goal for {0}!!", team1Name);
                Console.WriteLine("2. Goal for {0}!!", team2Name);
                Console.WriteLine();
                Console.WriteLine("0. Game End");
                Console.WriteLine("=============================");
                Console.Write("Enter Choice: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
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

        private static void PlayerApp()
        {
            while (true)
            {
                Screen.Clean();

                Console.WriteLine("Choose Game Type:");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Soccer");
                Console.WriteLine("2. Basketball");
                Console.WriteLine();
                Console.WriteLine("0. Go Back");
                Console.WriteLine("=============================");

                Console.WriteLine();
                Console.Write("Enter choice: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        PlaySoccer();
                        break;
                    case 2:
                        PlayBasketBall();
                        break;
                    case 0:
                        return;
                }

            }
        }

        private static void PlaySoccer()
        {
            Screen.Clean();
            Console.Write("Enter Player Name --> ");
            string name = Console.ReadLine();
            SoccerPlayer player = new SoccerPlayer(name);
            
            while (true)
            {
                Screen.Clean();
                Console.WriteLine("Game On - Player: {0}", name);
                Console.WriteLine("=============================");
                Console.WriteLine("1. Goal ({0})", player.GetPoints());
                Console.WriteLine("2. Assist ({0})", player.GetAssists());
                Console.WriteLine("3. Foul ({0})", player.GetFouls());
                Console.WriteLine("4. Red Card");
                Console.WriteLine();
                Console.WriteLine("0. Finish Game");
                Console.WriteLine("=============================");

                Console.Write("Enter choice: ");
                char ch = Console.ReadKey().KeyChar;
                int choice = ch - 48;
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        player.ScoreField();
                        break;
                    case 2:
                        player.AddAssist();
                        break;
                    case 3:
                        player.AddFoul();
                        break;
                    case 4:
                        player.SetRedCard(true);
                        return;
                    case 0:
                        player.GameOver();
                        return;
                }
            }
        }

        private static void PlayBasketBall()
        {
            Screen.Clean();
            Console.Write("Enter Player Name --> ");
            string name = Console.ReadLine();
            BasketBallPlayer player = new BasketBallPlayer(name);

            while (true)
            {
                Screen.Clean();
                Console.WriteLine("Game On - Player: {0}", name);
                Console.WriteLine("=============================");
                Console.WriteLine("1. Dunk ({0})",player.Dunks);
                Console.WriteLine("2. 3 Points ({0})", player.ThreeShots);
                Console.WriteLine("3. Assist ({0})", player.GetAssists());
                Console.WriteLine("4. Rebound ({0})", player.Rebounds);
                Console.WriteLine("5. Foul ({0})",player.GetFouls());
                Console.WriteLine();
                Console.WriteLine("0. Finish Game");
                Console.WriteLine("=============================");

                Console.Write("Enter choice: ");
                char ch = Console.ReadKey().KeyChar;
                int choice = ch - 48;
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        player.ScoreField();
                        break;
                    case 2:
                        player.Score3();
                        break;
                    case 3:
                        player.AddAssist();
                        break;
                    case 4:
                        player.AddRebound();
                        break;
                    case 5:
                        player.AddFoul();
                        if (player.GetFouls() == 5)
                            return;
                        break;
                    case 0:
                        player.GameOver();
                        return;
                }
            }
        }
    }
}

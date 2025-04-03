using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Masarwa_Shadi.BankApp;
using c_sharp_apps_Masarwa_Shadi.DraftApp;
using c_sharp_apps_Masarwa_Shadi.PokerGame.poker_hands;
using c_sharp_apps_Masarwa_Shadi.PokerGame.users;
using c_sharp_apps_Masarwa_Shadi.SportApp;
using c_sharp_apps_Masarwa_Shadi.StockDemo;
using c_sharp_apps_Masarwa_Shadi.TransportationApp;

namespace c_sharp_apps_Masarwa_Shadi.PokerGame.game_area
{
    class PokerAppMain
    {
        public static void MainEntry()
        {
            bool finished = false;
            Users users = new Users();
            while (!finished)
            {
                Screen.Clean();
                Console.WriteLine("Poker Game Menu");
                Console.WriteLine("===============");
                Console.WriteLine("1. Display class manual testing");
                Console.WriteLine("2. Add user");
                Console.WriteLine("3. Open Table");
                Console.WriteLine();
                Console.WriteLine("0. Exit");
                Console.WriteLine("=====================");
                Console.Write("Enter Choice: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                switch (choice)
                {
                    case 1:
                        MyTesting.RunMe();
                        break;
                    case 2:
                        users.AddUser();
                        break;
                    case 3:
                        GameSystem.AddTable(users.UsersList);
                        break;
                    case 0:
                        finished = true;
                        break;
                }
            }
        }
    }
}

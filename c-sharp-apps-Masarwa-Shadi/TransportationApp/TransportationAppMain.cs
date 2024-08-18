using c_sharp_apps_Masarwa_Shadi.BankApp;
using c_sharp_apps_Masarwa_Shadi.SportApp;
using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class TransportationAppMain
    {
        public static void MainEntry()
        {
            bool finish = false;

            while (!finish)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("        Cargo App Menu");
                Console.WriteLine("-------------------------------\n");
                Console.WriteLine("1. Run Tests");
                Console.WriteLine("2. Run Console App");
                Console.WriteLine("\n0. Exit\n");
                Console.WriteLine("-------------------------------");
                Console.Write("Enter Choice: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                switch (choice)
                {
                    case 1:
                        TestApp.RunTests();
                        break;
                    case 2:
                        ConsoleApp.RunApp();
                        break;
                    case 0:
                        finish = true;
                        break;
                }
            }
        }
    }
}

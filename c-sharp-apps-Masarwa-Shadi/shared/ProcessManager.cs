using System;

using c_sharp_apps_Masarwa_Shadi.TransportationApp;
using c_sharp_apps_Masarwa_Shadi.SportApp;
using c_sharp_apps_Masarwa_Shadi.DraftApp;
using c_sharp_apps_Masarwa_Shadi.BankApp;
using c_sharp_apps_Masarwa_Shadi.StockDemo;

namespace c_sharp_apps_Masarwa_Shadi.shared
{
    public class ProcessManager
    {
        public static void RunMainProcess()
        {
            bool finish = false;
            Console.WriteLine("App Menu");
            Console.WriteLine("========");
            Console.WriteLine("1. Bank App");
            Console.WriteLine("2. Sport App");
            Console.WriteLine("3. Transportation App");
            Console.WriteLine("4. Draft App");
            Console.WriteLine("5. Stock App");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=====================");
            while (!finish)
            {
                Console.Write("Enter Choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        BankAppMain.MainEntry();
                        break;
                    case 2:
                        SportAppMain.MainEntry();
                        break;
                    case 3:
                        TransportationAppMain.MainEntry();
                        break;
                    case 4:
                        DraftAppMain.MainEntry();
                        break;
                    case 5:
                        ExchangeDemo exchangeDemo = new ExchangeDemo();
                        exchangeDemo.MainEntry();
                        break;
                    case 0:
                        finish = true;
                        break;

                }
            }
        }
    }
}

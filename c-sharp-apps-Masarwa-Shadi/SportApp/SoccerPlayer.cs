using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.SportApp
{
    public class SoccerPlayer:GeneralPlayer
    {
        private bool redCard = false;
        private int penalties=0;
        private int dribblingRate=0; //(רמת הכדרור – מ1- עד 10)

        public SoccerPlayer(string name) : base(name, "Goal")
        {
            
        }

        public void SetRedCard(bool redCard)
        {
            this.redCard = redCard;
            if (redCard)
                GameOver();
        }

        public void GameOver()
        {
            Screen.Clean();
            string str;
            if (redCard)
                str = "Yes";
            else
                str = "No";
            Console.WriteLine("===============================");
            Console.WriteLine("=       Player Statistics     =");
            Console.WriteLine("===============================");
            Console.WriteLine("Name:    " + name);
            Console.WriteLine("Goals:   " + points);
            Console.WriteLine("Assists: " + GetAssists());
            Console.WriteLine("Fouls:   " + fouls);
            Console.WriteLine("Red Card:" + str);
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.SportApp
{
    public class BasketBallPlayer:GeneralPlayer
    {
        private int dunks = 0;
        private int threeShots = 0;
        private int rebounds = 0;

        public int Dunks { get => dunks; set => dunks = value; }
        public int ThreeShots { get => threeShots; set => threeShots = value; }
        public int Rebounds { get => rebounds; set => rebounds = value; }

        public BasketBallPlayer(string name) : base(name, "Basket")
        {
        }
        
        public void AddRebound()
        {
            rebounds++;
        }
        public override void AddFoul() 
        {
            fouls++;
            if (fouls == 5)
                GameOver();
        }

        public override int GetFouls()
        {
            return fouls;
        }

        public override void ScoreField()
        {
            dunks++;
            points += 2;
            DisplayScore(2);
        }
        
        public void Score3()
        {
            threeShots++;
            points += 3;
            DisplayScore(3);
        }

        public void DisplayScore(int points)
        {
            Console.WriteLine("{0} Scored {1} Points",name, points);
            Console.WriteLine("Press any key to continue game...");
            Console.ReadKey();

        }

        public void GameOver()
        {
            Screen.Clean();
            string str;
            if (fouls==5)
                str = "Yes";
            else
                str = "No";
            Console.WriteLine("===============================");
            Console.WriteLine("= Game Over-Player Statistics =");
            Console.WriteLine("===============================");
            Console.WriteLine("Name:      " + name);
            Console.WriteLine("Baskets:   " + dunks);
            Console.WriteLine("3 points:  " + threeShots);
            Console.WriteLine("Total Points:" + points);
            Console.WriteLine("Assists:   " + GetAssists());
            Console.WriteLine("Rebounds:  " + rebounds);
            Console.WriteLine("5 Fouls:   " + str);
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();

        }

    }
}

using System;

namespace c_sharp_apps_Masarwa_Shadi.SportApp
{
    public  class GeneralPlayer
    {
        protected string name;
        protected int points;
        protected string scoreName; //(מייצגת את שם ההבקעה – לדוגמא :    goal, basket)
        private int assists;
        protected int fouls;
        protected bool outOfGame;
        
        public GeneralPlayer(string name, string scoreName)
        {
            this.name = name;
            this.scoreName = scoreName;
        }
        public void AddAssist() 
        {
            assists ++;
        }

        public int GetAssists()
        {
            return assists;
        }
        public int GetPoints()
        {
            return points;
        }

        public virtual int GetFouls()
        {
            return fouls;
        }



        public virtual void ScoreField()
        {
            points ++;
            DisplayScore();
        }
        
        public void DisplayScore()
        {
            //Method that prints that the player scored.For example: "Messy score a goal".
            Console.WriteLine("{0} Scored {1}", name, scoreName);
            Console.WriteLine("Press any key to continue game...");
            Console.ReadKey();

        }

        public virtual void AddFoul()
        {
            fouls ++;
        }

    }
}

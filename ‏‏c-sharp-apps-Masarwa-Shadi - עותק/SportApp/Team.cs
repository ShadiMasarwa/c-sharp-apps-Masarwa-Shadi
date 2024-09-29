using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.SportApp
{
    public class Team
    {
        private string name;
        private string city;
        private string currLeague;
        private int numOfGames=0;
        private int gamesPlayed=0;
        private int wins = 0;
        private int loses = 0;
        private int draw = 0;
        private int points = 0;
        private int goalsFor = 0;
        private int goalAgainst = 0;
        private int goalDifferential = 0;

        public Team(string name, string city)
        {
            this.name = name;
            this.city = city;
        }

        public int NumOfGames { get => numOfGames; set => numOfGames = value; }
        public int GamesPlayed { get => gamesPlayed; set => gamesPlayed = value; }
        public int Wins { get => wins; set => wins = value; }
        public int Loses { get => loses; set => loses = value; }
        public int Draw { get => draw; set => draw = value; }
        public int Points { get => points; set => points = value; }
        public int GoalsFor { get => goalsFor; set => goalsFor = value; }
        public int GoalAgainst { get => goalAgainst; set => goalAgainst = value; }
        public int GoalDifferential { get => goalDifferential; set => goalDifferential = value; }

        public string getName()
        {
            return name;
        }

        

    }
}

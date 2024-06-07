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
        private int numOfGames;
        private int gamesPlayed;
        private int wins;
        private int loses;
        private int drow;
        private int points;
        private int goalsFor;
        private int goalAgainst;
        private int goalDifferential;

        public Team(string name, string city)
        {
            this.name = name;
            this.city = city;
        }

        public string getName()
        {
            return name;
        }

        public int getPoints()
        {
            return points;
        }

    }
}

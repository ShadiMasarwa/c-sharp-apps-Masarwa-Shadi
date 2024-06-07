using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.SportApp
{
    public class Season
    {
        private int year;
        private string sportType;
        private string league;
        private Round[] rounds;
        private Round nextRound;
        private Team[] teamsInSeason;
        private int numOfTeams;
        private bool isActive;

        public Season(int year, string sportType, string league, Team[] teams) 
        {
            this.year = year;
            this.sportType = sportType;
            this.league = league;
            this.teamsInSeason = teams;
        }

        public void DisplayTable()
        {
            Console.WriteLine("Table of teams and points");
            foreach (Team t in teamsInSeason)
            {
                Console.WriteLine("Name of team: " +  t.getName() +  " Points: " + t.getPoints());
            }
        }

    }
}

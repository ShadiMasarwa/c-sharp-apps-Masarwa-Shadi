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

        public void DisplayTable(int num)
        {
            Console.WriteLine(league);
            Console.WriteLine(" -----------------------------------------");
            Console.WriteLine(String.Format("|{0,-30}|{1,-10}|", "Team", "Points"));
            Console.WriteLine(" -----------------------------------------");
            foreach (Team t in teamsInSeason)
            {
                Console.WriteLine(String.Format("|{0,-30}|{1,-10}|", t.getName(), t.getPoints()));
                //Console.WriteLine(t.getName() +  "\t Points: " + t.getPoints());
            }
            Console.WriteLine(" -----------------------------------------");
            Console.WriteLine();
        }

    }
}

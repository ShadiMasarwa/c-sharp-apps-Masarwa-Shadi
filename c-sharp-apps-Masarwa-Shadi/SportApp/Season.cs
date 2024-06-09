using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Console.WriteLine(league);
            Console.WriteLine(" ----------------------------------------------------------");
            Console.WriteLine(String.Format("|{0,-20} | {1,-6}| {2, -6} | {3,-6} | {4, -8} |", "Team", "Wins", "Loses", "Draws", "Points"));
            Console.WriteLine(" ----------------------------------------------------------");
            foreach (Team t in teamsInSeason)
            {
                Console.WriteLine(String.Format("|{0,-20} | {1,-6}| {2, -6} | {3,-6} | {4,-8} |", t.getName(), t.Wins,t.Loses, t.Draw, t.Points));
            }
            Console.WriteLine(" ----------------------------------------------------------");
            Console.WriteLine();
        }

        public string GetLeague()
        {
            return league;
        }

        public Team[] GetTeams()
        {
            return teamsInSeason;
        }

    }
}

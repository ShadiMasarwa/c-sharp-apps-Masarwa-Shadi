using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.SportApp
{
    public class Game
    {
        private Team team1;
        private Team team2;
        private int team1Goals=0;
        private int team2Goals=0;
        private int currMinute=0;
        private bool activeGame=true;

        public Team Team1 { get => team1; set => team1 = value; }
        public Team Team2 { get => team2; set => team2 = value; }
        public int Team1Goals { get => team1Goals; set => team1Goals = value; }
        public int Team2Goals { get => team2Goals; set => team2Goals = value; }
        public int CurrMinute { get => currMinute; set => currMinute = value; }
        public bool ActiveGame { get => activeGame; set => activeGame = value; }

        public Game(Team team1, Team team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }

        public void ScoreGoal(Team team)
        {
            if (team == team1)
                team1Goals++;
            else
                team2Goals++;
        }

        public void FinishGame()
        {
            team1.GamesPlayed++;
            team2.GamesPlayed++;
            team1.GoalsFor += team1Goals;
            team2.GoalsFor += team2Goals;
            team1.GoalAgainst += team2Goals;
            team2.GoalAgainst += team1Goals;
            team1.GoalDifferential += team1Goals - team2Goals;
            team2.GoalDifferential += team2Goals - team1Goals;
            if (team1Goals > team2Goals)
            {
                team1.Wins++;
                team2.Loses++;
                team1.Points += 3;
            }
            else if (team2Goals > team1Goals)
            {
                team2.Wins++;
                team1.Loses++;
                team2.Points += 3;
            }
            else
            {
                team1.Draw++;
                team2.Draw++;
                team1.Points++;
                team2.Points++;
            }
        }
    }
}

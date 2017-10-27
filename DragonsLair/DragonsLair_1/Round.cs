
using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Round
    {
        private List<Match> matches = new List<Match>();
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            Match a = new Match();
            teamName1 = "";
            teamName2 = "";
            // TODO: Implement this method
            foreach (Match x in matches) {
                if (teamName1 == "")
                {
                    teamName1 = x.FirstOpponent.Name;
                }
                if(teamName1 != "" && teamName2 == "")
                {
                    teamName2 = x.SecondOpponent.Name;
                }
                if(teamName1 != "" && teamName2 != "")
                {
                    a.FirstOpponent = new Team(teamName1);
                    a.SecondOpponent = new Team(teamName2);
                    break;
                }
            }
            return a;
            
            
        }

        public bool IsMatchesFinished()
        {
            // TODO: Implement this method
            foreach (Match a in matches) {
                if (a.Winner == null) {
                    return false;
                }
            }

            return true;
        }

        public List<Team> GetWinningTeams()
        {
            // TODO: Implement this method
            List<Team> winners = new List<Team>();
            
            foreach (Match a in matches) {
                winners.Add(a.Winner);
            }
            return winners;
        }

        public List<Team> GetLosingTeams()
        {
            // TODO: Implement this method
            List<Team> losers = new List<Team>();
            foreach (Match a in matches) {
                if (a.FirstOpponent.Name == a.Winner.Name)
                {
                    losers.Add(a.SecondOpponent);
                }
                else
                {
                    losers.Add(a.FirstOpponent);

                }
            }
            return losers;
        }

        public bool IsRoundFinished()
        {
            return false;
        }

        public void GetFreeRider()
        {
            
        }

        public void Add(Team freeRider)
        {

        }
    }
}

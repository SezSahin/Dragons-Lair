
using System.Collections.Generic;

namespace DragonsLair_1
{
    public class Round
    {
        private List<Match> matches = new List<Match>();

        private Team freerider = new Team("");

        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string winner){
            Match match = new Match();
            match.Winner.Name = winner;
            return match;
        }
        
        public Match GetMatch(string teamName1, string teamName2)
        {
            //ikke del af template
            Match match = new Match();
            match.FirstOpponent = new Team(teamName1);
            match.SecondOpponent = new Team(teamName2);
            return match;
            
            
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

        //extra
        public bool IsRoundFinished()
        {
            
            for(int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Winner == null)
                {
                    return false;
                }
            }
            return true;
        }

        //extra
        public Team GetFreeRider()
        {

            //Team freerider = new Team("");

            //int numberofteams = 8;

            //if (numberofteams % 2 == 1)
            //{
            //    freerider.Name = "The Corinthians";
            //    return freerider;
            //}
            //return null;
            return this.freerider;
        }

        //extra
        public void Add(Team freeRider)
        {
            //int numberofteams = 8;

            this.freerider = freeRider;


        }

        public void Add(Match match) {
            matches.Add(match);
        }
    }
}

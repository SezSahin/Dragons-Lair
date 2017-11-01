using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonsLair_1
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();

        public void ShowScore(string tournamentName)
        {
            /*
             * TODO: Calculate for each team how many times they have won
             * Sort based on number of matches won (descending)
             */
            Tournament t = tournamentRepository.GetTournament(tournamentName);
            List<Team> team = t.GetTeams();
            int[] score = new int[team.Count];
            int[] sortedscore = new int[team.Count];
            List<Team> sortedteam = t.GetTeams();
            for (int i = 0; i < t.GetNumberOfRounds(); i++)
            {
                Round currentround = t.GetRound(i);
                List<Team> winningteams = currentround.GetWinningTeams();
                foreach (Team x in team) {
                    foreach (Team y in winningteams) {

                        if (x.Name == y.Name) {
                            score[team.IndexOf(x)] += 1;
                        }
                    }
                }

            }
            
            for (int i = 0; i < team.Count; i++) {
                int index = Array.IndexOf(score, score.Max());
                sortedteam[i] = team[index];
                sortedscore[i] = score[index];
                score[index] = -1;
            }
            
            for (int i = 0; i < team.Count; i++) {
                Console.WriteLine("Team: " + sortedteam[i].Name + "   Score: " + sortedscore[i]);
            }

        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            Tournament tournament = new Tournament(tournamentName);
            TournamentRepo repo = new TournamentRepo();
            Round round = new Round();

            List<Team> teams = new List<Team>();

            Tournament t = repo.GetTournament(tournamentName);
            
            int numberOfRound = tournament.GetNumberOfRounds();

            Round lastRound;

            bool isRoundFinished;
            //[numberOrRounds = 0]
            if (numberOfRound == 0)
            {
                teams = tournament.GetTeams();
            }
            else
            {
                lastRound = tournament.GetRound(numberOfRound - 1);
                isRoundFinished = round.IsRoundFinished();
                //[isRoundFinished]
                if (isRoundFinished)
                {
                    teams = round.GetWinningTeams();

                    if (teams.Count >= 2)
                    {



                        Random rnd = new Random();

                        List<Team> scrambled = new List<Team>();

                        //List<Team> scrambledteams = new List<Team>();

                        int index = 0;

                        int count = teams.Count;

                        while (count > 0)
                        {
                            int r = rnd.Next(teams.Count);

                            if (teams[r] == null)
                            {
                                scrambled[r] = teams[index];

                                //scrambledteams[index] = scrambled[r];

                                count--;

                                index++;
                            }
                        }

                        teams = scrambled;

                        Round newRound = new Round();
                        //[teams has at least two members]
                        if (teams.Count % 2 == 1)
                        {
                            Team oldFreeRider = round.GetFreeRider();

                            Team newFreeRider = round.GetFreeRider();

                            int x = 0;
                            //[loop until newFreeRider <> oldFreeRider]
                            while (newFreeRider == oldFreeRider)
                            {
                                newFreeRider = teams[x];
                                x++;
                            }

                            teams.Remove(newFreeRider);

                            newRound.Add(newFreeRider);
                            //[loop for all pairs]
                            while (teams.Count > 0)
                            {
                                Match match = new Match();
                                Team first = teams[0];
                                match.FirstOpponent = first;
                                teams.RemoveAt(0);
                                Team second = teams[0];
                                match.SecondOpponent = second;
                                teams.RemoveAt(0);
                                round.Add(match);
                            }
                            tournament.Add(newRound);

                        }


                    }
                    else
                    {
                        tournament.SetStatus(true);

                    }
                }
                else
                {
                    throw new Exception("RoundNotFinished");
                }
            }


        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            Tournament t = tournamentRepository.GetTournament(tournamentName);
            Round r = t.GetRound(roundNumber - 1);
            Match m = r.GetMatch(winningTeam);

            if (m != null && m.Winner == null)
            {
                Team w = t.GetTeam(winningTeam);
                m.Winner = w;
                Console.WriteLine("Succes");
            }
            else {
                throw new Exception("fail");
            }
        }
    }
}

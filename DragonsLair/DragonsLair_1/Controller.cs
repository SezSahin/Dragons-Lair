using System;
using System.Collections.Generic;

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
            Console.WriteLine("Implement this method!");
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

            if (numberOfRound == 0)
            {
                teams = tournament.GetTeams();
            }
            else
            {
                lastRound = tournament.GetRound(numberOfRound - 1);
                isRoundFinished = round.IsRoundFinished();

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

                        if (teams.Count % 2 == 1)
                        {
                            Team oldFreeRider = round.GetFreeRider();

                            Team newFreeRider = round.GetFreeRider();

                            int x = 0;

                            while (newFreeRider == oldFreeRider)
                            {
                                newFreeRider = teams[x];
                                x++;
                            }

                            teams.Remove(newFreeRider);

                            newRound.Add(newFreeRider);

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
            // Do not implement this method
        }
    }
}

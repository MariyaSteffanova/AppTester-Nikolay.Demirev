using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustPoll.DAL
{
    public static class VotesDAL
    {
        public static TimeSpan TimeToNextVote(string voterIp, int pollId)
        {
            JustPollsEntities database = new JustPollsEntities();

            var lastVoteByThisIp = (from p in database.Votes.Include("PossibleAnswer") where p.voterIp == voterIp && p.PossibleAnswer.PollId == pollId orderby p.Date descending select p).FirstOrDefault();

            if (lastVoteByThisIp != null)
            {
                return lastVoteByThisIp.Date.AddDays(1) - DateTime.Now;
            }

            return new TimeSpan(0, 0, 0);
        }

        public static double CalculateVotesPercents(int pollId, int totalVotesCount)
        {
            if (totalVotesCount == 0)
            {
                return 0;
            }
            int votesCount = GetVotesCount(pollId);
            double proportion = (double)totalVotesCount / votesCount;

            return proportion;
        }

        public static int GetVotesCount(int pollId)
        {
            JustPollsEntities database = new JustPollsEntities();

            var possibleAnswers = (from p in database.PossibleAnswers where p.PollId == pollId select p);
            int votesCount = 0;
            foreach (var answer in possibleAnswers)
            {
                votesCount += answer.VotesCount;
            }

            return votesCount;
        }

        public static void AddVote(int answerId, string voterIp)
        {
            JustPollsEntities database = new JustPollsEntities();

            int oldVotesCount = (from p in database.Votes where p.answerId == answerId && p.voterIp == voterIp select p).Count();

            PossibleAnswer answer = (from p in database.PossibleAnswers where p.id == answerId select p).FirstOrDefault();

            if (oldVotesCount == 0 && answer != null)
            {
                answer.VotesCount++;

                Vote newVote = new Vote();
                newVote.answerId = answerId;
                newVote.Date = DateTime.Now;
                newVote.voterIp = voterIp;

                database.Votes.AddObject(newVote);
                database.SaveChanges();
            }
        }
    }
}

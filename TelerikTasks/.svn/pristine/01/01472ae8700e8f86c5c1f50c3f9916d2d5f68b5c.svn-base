using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustPoll.DAL
{
    public static class PollsDAL
    {
        public static List<Poll> GetPolls(int pageNumber, int pollsPerPage)
        {
            int pollsToSkip = (pageNumber - 1) * pollsPerPage;

            JustPollsEntities database = new JustPollsEntities();
            List<Poll> polls = database.Polls.Include("PossibleAnswers").OrderByDescending(x => x.Date).Skip(pollsToSkip).Take(pollsPerPage).ToList();
            //List<Poll> polls = (from p in database.Polls orderby p.Date descending select p).Skip(pollsToSkip).Take(pollsPerPage).ToList();

            return polls;
        }

        public static Poll GetPoll(int pollId)
        {
            JustPollsEntities database = new JustPollsEntities();
            Poll poll = database.Polls.Include("PossibleAnswers").Where(x => x.id == pollId).FirstOrDefault();

            return poll;
        }

        public static int GetPollsCount()
        {
            JustPollsEntities database = new JustPollsEntities();
            return (from p in database.Polls select p).Count();
        }

        public static StringBuilder ExtractKeywords(List<Poll> polls)
        {
            StringBuilder keywords = new StringBuilder();
            foreach (var poll in polls)
            {
                AddTextToKeywords(keywords, poll.Title);

                foreach (var answer in poll.PossibleAnswers)
                {
                    AddTextToKeywords(keywords, answer.text);
                }
            }

            keywords = keywords.Remove(keywords.Length - 2, 2);
            return keywords;
        }

        private static void AddTextToKeywords(StringBuilder keywords, string text)
        {
            var words = text.Split(new char[] { ',', '.', '!', '?', ';', '\'', '"', ' ' });
            foreach (var word in words)
            {
                keywords.AppendFormat("{0}, ", word);
            }
        }
    }
}

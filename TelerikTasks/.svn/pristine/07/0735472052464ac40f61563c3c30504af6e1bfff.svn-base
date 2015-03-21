using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustPoll.DAL
{
    public static class PossibleAnswersDAL
    {
        public static List<PossibleAnswer> GetPossibleAnswers(int pollId)
        {
            JustPollsEntities database = new JustPollsEntities();
            List<PossibleAnswer> polls = (from p in database.PossibleAnswers where p.PollId == pollId orderby p.VotesCount orderby p.text select p).ToList();

            return polls;
        }

        public static StringBuilder GetKeywords(int pollId, Poll poll)
        {
            List<Poll> polls = new List<Poll>();
            polls.Add(poll);
            StringBuilder keywords = PollsDAL.ExtractKeywords(polls);

            var answers = PossibleAnswersDAL.GetPossibleAnswers(pollId);
            foreach (var answer in answers)
            {
                keywords.AppendFormat("{0}, ", PossibleAnswersDAL.ExtractKeywords(answer));
            }
            keywords = keywords.Remove(keywords.Length - 2, 2);
            return keywords;
        }

        private static StringBuilder ExtractKeywords(PossibleAnswer answer)
        {
            StringBuilder keywords = new StringBuilder();

            AddTextToKeywords(keywords, answer.text);

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

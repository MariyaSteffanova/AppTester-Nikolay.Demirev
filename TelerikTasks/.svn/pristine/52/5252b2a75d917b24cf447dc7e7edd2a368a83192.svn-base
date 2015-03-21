using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustPoll.DAL;
using System.Text;

namespace JustPoll.Controllers
{
    public class VoteController : Controller
    {
        //
        // GET: /Vote/

        public ActionResult Index(int pollId = 1)
        {
            Poll poll = PollsDAL.GetPoll(pollId);
            if (poll == null)
            {
                return Redirect("/Home/Index");
            }
            ViewBag.Poll = poll;

            TimeSpan timeToNextVote = VotesDAL.TimeToNextVote(Request.ServerVariables["REMOTE_ADDR"], pollId);

            ViewBag.CanUserVote = timeToNextVote.TotalSeconds == 0;
            ViewBag.TimeToNextVote = string.Format("{0}:{1}:{2}", timeToNextVote.Hours, timeToNextVote.Minutes, timeToNextVote.Seconds);

            StringBuilder keywords = PossibleAnswersDAL.GetKeywords(pollId, poll);

            ViewBag.Keywords = keywords.ToString();

            return View();
        }

        public ActionResult Vote(int answerId)
        {
            VotesDAL.AddVote(answerId, Request.ServerVariables["REMOTE_ADDR"]);
            return Redirect("~/Home/Index?pageNumber=" + Session["pageNumber"]);
        }

        public string GetTimeLeftToVote(int id)
        {
            TimeSpan timeToNextVote = VotesDAL.TimeToNextVote(Request.ServerVariables["REMOTE_ADDR"], id);

            return string.Format("You can vote again after: {0:00}:{1:00}:{2:00}", timeToNextVote.Hours, timeToNextVote.Minutes, timeToNextVote.Seconds);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustPoll.DAL;
using System.Text;

namespace JustPoll.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(int pageNumber = 1)
        {
            Session["pageNumber"] = pageNumber;

            int pollsCount = PollsDAL.GetPollsCount();
            int pollsPerPage = 3;
            int pagesCount = (int)Math.Ceiling((double)pollsCount / pollsPerPage);

            ViewBag.PagesCount = pagesCount;
            ViewBag.PollsCount = pollsCount;
            ViewBag.CurrentPageNumber = pageNumber;
            var polls = PollsDAL.GetPolls(pageNumber, pollsPerPage);
            ViewBag.Polls = polls;

            StringBuilder keywords = PollsDAL.ExtractKeywords(polls);

            ViewBag.Keywords = keywords.ToString();

            return View();
        }
    }
}

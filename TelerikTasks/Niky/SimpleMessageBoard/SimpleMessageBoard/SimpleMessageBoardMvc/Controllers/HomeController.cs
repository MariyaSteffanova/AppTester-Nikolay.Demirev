using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL = SimpleMessageBoard.DAL;

namespace SimpleMessageBoardMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int pageNumber = 1)
        {
            int votesPerPage = 4;
            int messagesCount = DAL.SimpleMessageBoard.GetMessagesCount();

            int pagesCount = (int)Math.Ceiling((double)messagesCount / votesPerPage);

            var messages = DAL.SimpleMessageBoard.GetMessages(pageNumber, votesPerPage);

            ViewBag.Messages = messages;
            ViewBag.PagesCount = pagesCount;
            ViewBag.PageNumber = pageNumber;

            return View("Index");
        }

        public ActionResult PostMessage(string author, string NewPostMessage)
        {
            DAL.SimpleMessageBoard.PostMessage(author, NewPostMessage);
            return Index();
        }

        [HttpPost]
        public string VoteUp(int messageId)
        {
            return DAL.SimpleMessageBoard.Vote(messageId, Request.UserHostAddress, true).ToString() + " votes";
        }

        [HttpPost]
        public string VoteDown(int messageId)
        {
            return DAL.SimpleMessageBoard.Vote(messageId, Request.UserHostAddress, false).ToString() + " votes";
        }
    }
}

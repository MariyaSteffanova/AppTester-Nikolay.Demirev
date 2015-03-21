using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustPoll.DAL;

namespace JustPollAdministrator.Controllers
{
    public class PollsController : Controller
    {
        private JustPollsEntities db = new JustPollsEntities();

        //
        // GET: /Polls/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "id", bool desc = false)
        {
            ViewBag.Count = db.Polls.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Polls/GridData/?start=0&itemsPerPage=20&orderBy=id&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "id", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Polls.Count().ToString());
            ObjectQuery<Poll> polls = db.Polls;
            polls = polls.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(polls.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Poll poll = db.Polls.Single(p => p.id == id);
            return PartialView("GridData", new Poll[] { poll });
        }

        //
        // GET: /Polls/Create

        public ActionResult Create()
        {
            return PartialView("Edit");
        }

        //
        // POST: /Polls/Create

        [HttpPost]
        public ActionResult Create(Poll poll)
        {
            if (ModelState.IsValid)
            {
                db.Polls.AddObject(poll);
                db.SaveChanges();
                return PartialView("GridData", new Poll[] { poll });
            }

            return PartialView("Edit", poll);
        }

        //
        // GET: /Polls/Edit/5

        public ActionResult Edit(int id)
        {
            Poll poll = db.Polls.Single(p => p.id == id);
            return PartialView(poll);
        }

        //
        // POST: /Polls/Edit/5

        [HttpPost]
        public ActionResult Edit(Poll poll)
        {
            if (ModelState.IsValid)
            {
                db.Polls.Attach(poll);
                db.ObjectStateManager.ChangeObjectState(poll, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Poll[] { poll });
            }

            return PartialView(poll);
        }

        //
        // POST: /Polls/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Poll poll = db.Polls.Single(p => p.id == id);
            db.Polls.DeleteObject(poll);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

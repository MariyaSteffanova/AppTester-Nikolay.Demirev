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
    public class VotesController : Controller
    {
        private JustPollsEntities db = new JustPollsEntities();

        //
        // GET: /Votes/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "id", bool desc = false)
        {
            ViewBag.Count = db.Votes.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Votes/GridData/?start=0&itemsPerPage=20&orderBy=id&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "id", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Votes.Count().ToString());
            ObjectQuery<Vote> votes = db.Votes.Include("PossibleAnswer");
            votes = votes.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(votes.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Vote vote = db.Votes.Single(v => v.id == id);
            return PartialView("GridData", new Vote[] { vote });
        }

        //
        // GET: /Votes/Create

        public ActionResult Create()
        {
            ViewBag.answerId = new SelectList(db.PossibleAnswers, "id", "text");
            return PartialView("Edit");
        }

        //
        // POST: /Votes/Create

        [HttpPost]
        public ActionResult Create(Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Votes.AddObject(vote);
                db.SaveChanges();
                return PartialView("GridData", new Vote[] { vote });
            }

            ViewBag.answerId = new SelectList(db.PossibleAnswers, "id", "text", vote.answerId);
            return PartialView("Edit", vote);
        }

        //
        // GET: /Votes/Edit/5

        public ActionResult Edit(int id)
        {
            Vote vote = db.Votes.Single(v => v.id == id);
            ViewBag.answerId = new SelectList(db.PossibleAnswers, "id", "text", vote.answerId);
            return PartialView(vote);
        }

        //
        // POST: /Votes/Edit/5

        [HttpPost]
        public ActionResult Edit(Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Votes.Attach(vote);
                db.ObjectStateManager.ChangeObjectState(vote, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Vote[] { vote });
            }

            ViewBag.answerId = new SelectList(db.PossibleAnswers, "id", "text", vote.answerId);
            return PartialView(vote);
        }

        //
        // POST: /Votes/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Vote vote = db.Votes.Single(v => v.id == id);
            db.Votes.DeleteObject(vote);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

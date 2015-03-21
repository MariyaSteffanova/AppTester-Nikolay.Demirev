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
    public class PossibleAnswersController : Controller
    {
        private JustPollsEntities db = new JustPollsEntities();

        //
        // GET: /PossibleAnswers/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "id", bool desc = false)
        {
            ViewBag.Count = db.PossibleAnswers.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /PossibleAnswers/GridData/?start=0&itemsPerPage=20&orderBy=id&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "id", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.PossibleAnswers.Count().ToString());
            ObjectQuery<PossibleAnswer> possibleanswers = db.PossibleAnswers.Include("Poll");
            possibleanswers = possibleanswers.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(possibleanswers.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            PossibleAnswer possibleanswer = db.PossibleAnswers.Single(p => p.id == id);
            return PartialView("GridData", new PossibleAnswer[] { possibleanswer });
        }

        //
        // GET: /PossibleAnswers/Create

        public ActionResult Create()
        {
            ViewBag.PollId = new SelectList(db.Polls, "id", "Title");
            return PartialView("Edit");
        }

        //
        // POST: /PossibleAnswers/Create

        [HttpPost]
        public ActionResult Create(PossibleAnswer possibleanswer)
        {
            if (ModelState.IsValid)
            {
                db.PossibleAnswers.AddObject(possibleanswer);
                db.SaveChanges();
                return PartialView("GridData", new PossibleAnswer[] { possibleanswer });
            }

            ViewBag.PollId = new SelectList(db.Polls, "id", "Title", possibleanswer.PollId);
            return PartialView("Edit", possibleanswer);
        }

        //
        // GET: /PossibleAnswers/Edit/5

        public ActionResult Edit(int id)
        {
            PossibleAnswer possibleanswer = db.PossibleAnswers.Single(p => p.id == id);
            ViewBag.PollId = new SelectList(db.Polls, "id", "Title", possibleanswer.PollId);
            return PartialView(possibleanswer);
        }

        //
        // POST: /PossibleAnswers/Edit/5

        [HttpPost]
        public ActionResult Edit(PossibleAnswer possibleanswer)
        {
            if (ModelState.IsValid)
            {
                db.PossibleAnswers.Attach(possibleanswer);
                db.ObjectStateManager.ChangeObjectState(possibleanswer, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new PossibleAnswer[] { possibleanswer });
            }

            ViewBag.PollId = new SelectList(db.Polls, "id", "Title", possibleanswer.PollId);
            return PartialView(possibleanswer);
        }

        //
        // POST: /PossibleAnswers/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            PossibleAnswer possibleanswer = db.PossibleAnswers.Single(p => p.id == id);
            db.PossibleAnswers.DeleteObject(possibleanswer);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleChatDal;

namespace Administrator.Controllers
{
    public class MessagesController : Controller
    {
        private ChatRoomEntities db = new ChatRoomEntities();

        //
        // GET: /Messages/

        public ViewResult Index(int start = 0, int itemsPerPage = 20, string orderBy = "MessageID", bool desc = false)
        {
            ViewBag.Count = db.Messages.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Messages/GridData/?start=0&itemsPerPage=20&orderBy=MessageID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "MessageID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.Messages.Count().ToString());
            ObjectQuery<Message> messages = db.Messages.Include("ChatRoom");
            messages = messages.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(messages.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Message message = db.Messages.Single(m => m.MessageID == id);
            return PartialView("GridData", new Message[] { message });
        }

        //
        // GET: /Messages/Create

        public ActionResult Create()
        {
            ViewBag.ChatRoomID = new SelectList(db.ChatRooms, "ChatRoomID", "ChatRoomName");
            return PartialView("Edit");
        }

        //
        // POST: /Messages/Create

        [HttpPost]
        public ActionResult Create(Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.AddObject(message);
                db.SaveChanges();
                return PartialView("GridData", new Message[] { message });
            }

            ViewBag.ChatRoomID = new SelectList(db.ChatRooms, "ChatRoomID", "ChatRoomName", message.ChatRoomID);
            return PartialView("Edit", message);
        }

        //
        // GET: /Messages/Edit/5

        public ActionResult Edit(int id)
        {
            Message message = db.Messages.Single(m => m.MessageID == id);
            ViewBag.ChatRoomID = new SelectList(db.ChatRooms, "ChatRoomID", "ChatRoomName", message.ChatRoomID);
            return PartialView(message);
        }

        //
        // POST: /Messages/Edit/5

        [HttpPost]
        public ActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Attach(message);
                db.ObjectStateManager.ChangeObjectState(message, EntityState.Modified);
                db.SaveChanges();
                return PartialView("GridData", new Message[] { message });
            }

            ViewBag.ChatRoomID = new SelectList(db.ChatRooms, "ChatRoomID", "ChatRoomName", message.ChatRoomID);
            return PartialView(message);
        }

        //
        // POST: /Messages/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Message message = db.Messages.Single(m => m.MessageID == id);
            db.Messages.DeleteObject(message);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

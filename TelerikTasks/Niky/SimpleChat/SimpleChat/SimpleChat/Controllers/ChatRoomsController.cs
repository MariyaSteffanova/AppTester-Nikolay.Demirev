using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleChat.Controllers
{
    public class ChatRoomsController : Controller
    {
        //
        // GET: /ChatRooms/

        public ActionResult Index()
        {
            List<int> lstOpenedRooms;
            if (Session["OpenedRooms"] == null)
            {
                Session["OpenedRooms"] = new List<int>();
            }
            lstOpenedRooms = (List<int>)Session["OpenedRooms"];

            ViewBag.ChatRomsList = SimpleChatDal.SimpleChatDal.GetAllChatRooms();
            ViewBag.OpenedChatRooms = SimpleChatDal.SimpleChatDal.GetChatRooms(lstOpenedRooms);
            return View();
        }

        [HttpGet]
        public ActionResult AddChatWindow(int chatRoomId = 0)
        {
            if (chatRoomId == 0)
            {
                return RedirectToAction("Index");
            }

            List<int> lstOpenedRooms;
            if (Session["OpenedRooms"] == null)
            {
                Session["OpenedRooms"] = new List<int>();
            }
            lstOpenedRooms = (List<int>)Session["OpenedRooms"];
            if (!lstOpenedRooms.Contains(chatRoomId))
            {
                lstOpenedRooms.Add(chatRoomId);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RemoveChatWindow(int chatRoomId = 0)
        {
            if (chatRoomId == 0)
            {
                return RedirectToAction("Index");
            }

            List<int> lstOpenedRooms;
            if (Session["OpenedRooms"] == null)
            {
                Session["OpenedRooms"] = new List<int>();
            }
            lstOpenedRooms = (List<int>)Session["OpenedRooms"];

            if (lstOpenedRooms.Contains(chatRoomId))
            {
                lstOpenedRooms.Remove(chatRoomId);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult PostMessage(int chatRoomId = 0, string message = null)
        {
            if (chatRoomId == 0 || string.IsNullOrEmpty(message))
            {
                RedirectToAction("Index");
            }

            SimpleChatDal.SimpleChatDal.PostMessage(Session["User"].ToString(), Request.UserHostAddress, chatRoomId, message);

            return RedirectToAction("Index");
        }
    }
}

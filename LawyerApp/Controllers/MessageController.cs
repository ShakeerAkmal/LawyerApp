using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealtimeChat.Hubs;
using LawyerApp.Models;

namespace LawyerApp.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetNotification()
        {
            return Json(MessageService.GetNotification(), JsonRequestBehavior.AllowGet);

        }
    }
}
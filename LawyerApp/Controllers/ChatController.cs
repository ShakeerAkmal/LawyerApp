using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace LawyerApp.Controllers
{
    public class ChatController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret= "04ZUBRKtmGPqBaow63uy6MT0PL1wiXZiVCLl6HEx",
            BasePath = "https://lawyerapp-3f80e.firebaseio.com/"

        };
        IFirebaseClient client;
        // GET: Chat
        public ActionResult Index()
        {
            int xx=4;
            client = new FireSharp.FirebaseClient(config);
            if(client != null)
            {
                 xx = 12;
            }
            var f = xx;
            return View();
        }
    }
}
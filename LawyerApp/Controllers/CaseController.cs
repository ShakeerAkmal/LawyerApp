using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyerApp.Controllers
{
    public class CaseController : Controller
    {
        // GET: Case
        public ActionResult Add()
        {
            return View();
        }
    }
}
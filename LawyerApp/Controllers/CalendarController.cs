using LawyerApp.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LawyerApp.Controllers
{
    public class CalendarController : Controller
    {
        siteDbEntities db = new siteDbEntities();
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()

        {
            List<CalendarViewModel> calendarList = new List<CalendarViewModel>();
            var User = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var caseList = db.Cases.Where(a => a.LawyerId == User).Select(a => new { a.NextCaseDate, a.OtherDetails, a.CaseNumber }).ToList();
            foreach (var casee in caseList)
            {
                CalendarViewModel calendar = new CalendarViewModel();
                calendar.DateString = casee.NextCaseDate.Value.Date.ToString();
                calendar.CaseNumber = casee.CaseNumber;
                calendar.OtherDetails = casee.OtherDetails;
                calendarList.Add(calendar);

            }
            
            return new JsonResult { Data = calendarList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
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
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            var columns = new Dictionary<string, string>
            {
                {"Subject","ssssdd"},
                {"Description","asdasdas"},
                {"Start","2019/03/20"},
                {"End","2019/03/21"},
                {"ThemeColor","red"},
                {"IsFullDay","true"}
            };


            var listNumber = columns.Select(kvp => kvp.Key).ToList();
            return new JsonResult { Data = listNumber, JsonRequestBehavior = JsonRequestBehavior.AllowGet };




        }
    }
}
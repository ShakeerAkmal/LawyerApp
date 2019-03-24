using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace LawyerApp.Controllers
{
    public class SetupController : Controller
    {
        siteDbEntities db = new siteDbEntities();
       
        // GET: Setup
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CaseTypes()
        {
            var caseTypes = db.CaseTypes.Where(a => a.IsDeleted == false).ToList();
            return PartialView("_CaseType", caseTypes);
        }
        public ActionResult CourtComplexes()
        {
            List<CourtComplex> courtComplexes = db.CourtComplexes.Where(a => a.IsDeleted == false).ToList();
            return PartialView("_CourtComplexes", courtComplexes);
        }
        public ActionResult Judges()
        {
            return PartialView("_Judges");
        }
        public ActionResult States()
        {
            return PartialView("_States");
        }
        public ActionResult SessionDivisions()
        {
            return PartialView("_SessionDivisions");
        }

        public bool AddCaseType( FormCollection formdata)
        {
            CaseType caseType = new CaseType();
            var casetypeName = formdata["CourtComplex"];
            caseType.IsDeleted = false;
            caseType.CaseType1 = casetypeName;
            db.CaseTypes.Add(caseType);
            db.SaveChanges();

            return true;
        }
        public bool DeleteCaseType(string id)
        {
            int x = Int32.Parse(id);
            var casetype = db.CaseTypes.Where(a => a.Id == x).FirstOrDefault();
            casetype.IsDeleted = true;
            db.SaveChanges();
            return true;
        }
        public bool AddCourtComplex(FormCollection formdata)
        {
            CourtComplex courtComplex = new CourtComplex();
            var courtComplexName = formdata["CourtComplex"];
            courtComplex.IsDeleted = false;
            courtComplex.CourtComplex1 = courtComplexName;
            db.CourtComplexes.Add(courtComplex);
            db.SaveChanges();

            return true;
        }
        public bool DeleteCourtComplex(string id)
        {
            int x = Int32.Parse(id);
            var courtComplex = db.CourtComplexes.Where(a => a.Id == x).FirstOrDefault();
            courtComplex.IsDeleted = true;
            db.SaveChanges();
            return true;
        }
    }
        
}
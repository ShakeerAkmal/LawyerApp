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
            List<Judge> judges = db.Judges.Where(a => a.IsDeleted == false).ToList();
            return PartialView("_Judges", judges);
        }
        public ActionResult States()
        {
            List<State> states = db.States.Where(a => a.isDeleted == false).ToList();
            return PartialView("_States", states);
        }
        public ActionResult SessionDivisions()
        {
            List<SessionDivision> divisions = db.SessionDivisions.Where(a => a.isDeleted == false).ToList();
            return PartialView("_SessionDivisions", divisions);
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
        public bool AddJudge(FormCollection formdata)
        {
            Judge judge = new Judge();
            var JudgeName = formdata["Name"];
            var JudgeDesignation = formdata["Designation"];

            judge.IsDeleted = false;
            judge.Name = JudgeName;
            judge.Designation = JudgeDesignation;

            db.Judges.Add(judge);
            db.SaveChanges();

            return true;
        }
        public bool DeleteJudge(string id)
        {
            int x = Int32.Parse(id);
            var judge = db.Judges.Where(a => a.Id == x).FirstOrDefault();
            judge.IsDeleted = true;
            db.SaveChanges();
            return true;
        }
        public bool AddState(FormCollection formdata)
        {
            State state = new State();
            var stateName = formdata["State"];
            state.isDeleted = false;
            state.state1 = stateName;
            db.States.Add(state);
            db.SaveChanges();

            return true;
        }
        public bool DeleteState(string id)
        {
            int x = Int32.Parse(id);
            var state = db.States.Where(a => a.id == x).FirstOrDefault();
            state.isDeleted = true;
            db.SaveChanges();
            return true;
        }
        public bool AddDivision(FormCollection formdata)
        {
            SessionDivision Division = new SessionDivision();
            var divisionName = formdata["Division"];
            Division.isDeleted = false;
            Division.SessionDivision1 = divisionName;
            db.SessionDivisions.Add(Division);
            db.SaveChanges();

            return true;
        }
        public bool DeleteDivision(string id)
        {
            int x = Int32.Parse(id);
            var division = db.SessionDivisions.Where(a => a.Id == x).FirstOrDefault();
            division.isDeleted = true;
            db.SaveChanges();
            return true;
        }
    }
        
}
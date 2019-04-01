using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawyerApp.Models;
using Microsoft.AspNet.Identity;

namespace LawyerApp.Controllers
{
    public class CaseController : Controller
    {
        siteDbEntities db = new siteDbEntities();
        

        // GET: Case
        public ActionResult Add()
        {
            siteDbEntities db = new siteDbEntities();
            AddCaseViewModel addCaseViewModel = new AddCaseViewModel();
            addCaseViewModel.CaseTypes = db.CaseTypes.Where(a => a.IsDeleted == false).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CaseType1.ToString()
            });
            addCaseViewModel.CourtComplexes = db.CourtComplexes.Where(a => a.IsDeleted == false).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CourtComplex1.ToString()
            });
            addCaseViewModel.Judges = db.Judges.Where(a => a.IsDeleted == false).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Designation + x.Name.ToString()
            });
            addCaseViewModel.States = db.States.Where(a => a.isDeleted == false).ToList().Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.state1.ToString()
            });
            addCaseViewModel.SessionDivisions = db.SessionDivisions.Where(a => a.isDeleted == false).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.SessionDivision1.ToString()
            });

            return View(addCaseViewModel);
        }
        public ActionResult AddCase(AddCaseViewModel addcase)
        {
            Case newCase = new Case();
            newCase.CaseNumber = addcase.CaseNumber;
            newCase.FirstParty = addcase.FirstParty;
            newCase.SecondParty = addcase.SecondParty;
            newCase.OppositeAdvocateName = addcase.OppositeAdvocateName;
            newCase.OppositeAdvocateContactNum = addcase.OppositeAdvocateContactNum;
            newCase.OtherDetails = addcase.OtherDetails;
            newCase.DateOfFiling = addcase.DateOfFiling;
            newCase.NextCaseDate = addcase.NextCaseDate;
            newCase.NextStage = addcase.NextStage;
            newCase.CaseTypeId = addcase.CaseTypeId;
            newCase.CourtComplexId = addcase.CourtComplexId;
            newCase.JudgeId = addcase.JudgeId;
            newCase.SessionDivisionId = addcase.SessionDivisionId;
            newCase.StateId = addcase.StateId;
            newCase.IsNewCase = addcase.IsNewCase;
            newCase.Court = addcase.Court;
            newCase.LawyerId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            newCase.ClientId = db.AspNetUsers.Where(a => a.Email == addcase.LawyerId).Select(b => b.Id).FirstOrDefault();
            db.Cases.Add(newCase);
            db.SaveChanges();
            return View(addcase);
        }
        public JsonResult GetClientData(string Prefix)
        {
            var ClientList = db.AspNetUsers.Where(x => x.AspNetRoles.Select(role => role.Name).Contains("User")).ToList();

            var clients = (from N in ClientList
                           where N.Email.StartsWith(Prefix)
                                             select new { N.Email, N.Id});


            
            return Json(clients, JsonRequestBehavior.AllowGet);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawyerApp.Models;

namespace LawyerApp.Controllers
{
    public class CaseController : Controller
    {
        // GET: Case
        public ActionResult Add()
        {
            siteDbEntities s = new siteDbEntities();
            AddCaseViewModel addCaseViewModel = new AddCaseViewModel();
            addCaseViewModel.CaseTypes= s.CaseTypes.Where(a => a.IsDeleted == false).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CaseType1.ToString()
            });
            addCaseViewModel.CourtComplexes = s.CourtComplexes.Where(a => a.IsDeleted == false).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CourtComplex1.ToString()
            });
            addCaseViewModel.Judges = s.Judges.Where(a => a.IsDeleted == false).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Designation + x.Name.ToString()
            });
            addCaseViewModel.States = s.States.Where(a => a.isDeleted == false).ToList().Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.state1.ToString()
            });
            addCaseViewModel.SessionDivisions = s.SessionDivisions.Where(a => a.isDeleted == false).ToList().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.SessionDivision1.ToString()
            });
           
            return View(addCaseViewModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyerApp.Models
{
    public class AddCaseViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Case Number")]
        public string CaseNumber { get; set; }
        [Display(Name = "FirstParty")]

        public string FirstParty { get; set; }
        [Display(Name = "Second Party")]

        public string SecondParty { get; set; }
        [Display(Name = "Opposite Advocate Name")]
        public string OppositeAdvocateName { get; set; }
        [Display(Name = "Opposite Advocate Contact Number")]
        public string OppositeAdvocateContactNum { get; set; }
        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }
        [Display(Name = "Date Of Filing")]
        [DataType(DataType.Date)]
        public DateTime DateOfFiling { get; set; }
        [Display(Name = "Next Case Date")]
        [DataType(DataType.Date)]
        public DateTime NextCaseDate { get; set; }
        [Display(Name = "Next Stage")]
        public string NextStage { get; set; }
        [Display(Name = "Case Type ")]
        public string CaseTypeId { get; set; }
        [Display(Name = "Court Complex ")]
        public Nullable<int> CourtComplexId { get; set; }
        [Display(Name = "Judge")]
        public Nullable<int> JudgeId { get; set; }
        [Display(Name = "Session Division ")]
        public Nullable<int> SessionDivisionId { get; set; }
        [Display(Name = "State ")]
        public Nullable<int> StateId { get; set; }
        [Display(Name = "Is NewCase")]
        public Nullable<bool> IsNewCase { get; set; }
        [Display(Name = "Court")]
        public string Court { get; set; }
        [Display(Name = "FirstParty")]
        public string LawyerId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual CaseType CaseType { get; set; }
        public virtual CourtComplex CourtComplex { get; set; }
        public virtual Judge Judge { get; set; }
        public virtual SessionDivision SessionDivision { get; set; }
        public virtual State State { get; set; }

        public IEnumerable<SelectListItem> CaseTypes { get; set; }
        public IEnumerable<SelectListItem> CourtComplexes { get; set; }
        public IEnumerable<SelectListItem> Judges { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> SessionDivisions { get; set; }
    
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LawyerApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Case
    {
        public int Id { get; set; }
        public string CaseNumber { get; set; }
        public string FirstParty { get; set; }
        public string SecondParty { get; set; }
        public string OppositeAdvocateName { get; set; }
        public string OppositeAdvocateContactNum { get; set; }
        public string OtherDetails { get; set; }
        public Nullable<System.DateTime> DateOfFiling { get; set; }
        public Nullable<System.DateTime> NextCaseDate { get; set; }
        public string NextStage { get; set; }
        public Nullable<int> CaseTypeId { get; set; }
        public Nullable<int> CourtComplexId { get; set; }
        public Nullable<int> JudgeId { get; set; }
        public Nullable<int> SessionDivisionId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<bool> IsNewCase { get; set; }
        public string Court { get; set; }
        public string LawyerId { get; set; }
        public string ClientId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual CourtComplex CourtComplex { get; set; }
        public virtual Judge Judge { get; set; }
        public virtual SessionDivision SessionDivision { get; set; }
        public virtual State State { get; set; }
        public virtual CaseType CaseType { get; set; }
    }
}

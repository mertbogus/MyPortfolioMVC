//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyPortfolioMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblEducation
    {
        public int EducatıonId { get; set; }
        public string SchoolName { get; set; }
        public string Department { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Description { get; set; }
        public string Degree { get; set; }
    }
}

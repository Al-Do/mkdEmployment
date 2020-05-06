using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace Services.Models
{
    public class JobPostingModel
    {
        public int CompanyID{ get; set; }
        public int PostID { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Added On")]
        public DateTime JobPostedDate { get; set; }

        [Display(Name = "Available untill")]
        public DateTime JobAvailableToDate { get; set; }
        [Display(Name = "Expected hours per week")]
        public string HoursPerWeek { get; set; }
        [Display(Name = "Job title")]
        public string JobTitle { get; set; }
        public int RegionID { get; set; }
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        public string ImagePath { get; set; }
        [Display(Name = "Company email")]
        public string CompanyEmail { get; set; }
        [Display(Name = "Job posted in region: ")]
        public string RegionName { get; set; }
    }
}
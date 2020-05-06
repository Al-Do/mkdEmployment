using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace mkd.Models
{
    public class JobPostingViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int PostID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CompanyID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime JobPostedDate { get; set; }

        [CurrentDate(ErrorMessage = "Date must be after or equal to current date")]
        [Required(ErrorMessage = "Please select valid date")]
        [Display(Name = "Available untill")]
        public DateTime JobAvailableToDate { get; set; }

        [Required(ErrorMessage = "Hours are required")]
        public string HoursPerWeek { get; set; }

        [Required(ErrorMessage = "Job title is required")]
        public string JobTitle { get; set; }

        public int RegionID { get; set; }
        [Required(ErrorMessage = "Job description is required")]
        [StringLength(500)]
        public string JobDescription { get; set; }
        [HiddenInput(DisplayValue = false)]
        public List<RegionModel> Regions{get; set;}

      
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
   public class ShortJobPosting
    {
        public int PostID { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Added On")]
        public DateTime JobPostedDate { get; set; }
        [Display(Name = "Available untill")]
        public DateTime JobAvailableToDate { get; set; }
        public string ImagePath { get; set; }
        public string JobTitle { get; set; }
        public string RegionName { get; set; }
    }
}

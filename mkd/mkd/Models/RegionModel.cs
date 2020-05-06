using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mkd.Models
{
    public class RegionModel
    {
        [HiddenInput(DisplayValue = false)]
        public int RegionID { get; set; }

        [Required(ErrorMessage = "Region Name is required")]
        public string RegionName { get; set; }
    }
}
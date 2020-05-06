using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
  public  class UserLoginModel
    {
       
            [Display(Name = "Email")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
            public string CompanyEmail { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember Me")]
            public bool RememberMe { get; set; }
        
    }
}

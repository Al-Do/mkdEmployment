using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;

namespace mkd.Models
{
    public partial class CompanyModel
    {
  
        [Display(Name = "Company Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Company name required")]
        public string CompanyName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CompanyID { get; set; }

        public string ImageTitle { get; set; }

        [Display(Name = "Upload logo")]
        [StringLength(500)]
        public string CompanyLogoPath { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public HttpPostedFileBase Imagefile { get; set; }

        [Display(Name = "Company Email")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [StringLength(255)]
        public string ComapanyEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }
        
        [StringLength(500)]
        public string CompanyDescription { get; set; }


     
    }
}

namespace mkd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JobPosting
    {
        [Key]
        public int PostID { get; set; }

        public int CompanyID { get; set; }

        [Column(TypeName = "date")]
        public DateTime JobPostedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime JobAvailableToDate { get; set; }

        [StringLength(10)]
        public string HoursPerWeek { get; set; }

        [Required]
        [StringLength(255)]
        public string JobTitle { get; set; }

        [StringLength(500)]
        public string JobDescription { get; set; }

        public int RegionID { get; set; }
    }
}

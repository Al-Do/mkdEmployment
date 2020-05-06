namespace Repository
{
    using Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JobPosting : BaseEntity
    {
        
        [Key]
        public int PostID { get; set; }


       
        public DateTime JobPostedDate { get; set; }

        
        public DateTime JobAvailableToDate { get; set; }

        [StringLength(10)]
        public string HoursPerWeek { get; set; }

        [Required]
        [StringLength(255)]
        public string JobTitle { get; set; }

        [StringLength(500)]
        public string JobDescription { get; set; }

        [Required]
        public int RegionID { get; set; }
        
        public virtual Region Region { get; set; }

        [Required]
        public int CompanyID { get; set; }
        public virtual Company Companies { get; set; }

    }
}

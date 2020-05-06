namespace Repository
{
    using Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Company : BaseEntity
    {
        
        public Company()
        {
            JobPostings = new HashSet<JobPosting>();
        }

        [Key]
        public int CompanyID { get; set; }

        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; }

        [StringLength(500)]
        public string CompanyLogoPath { get; set; }

        [Required]
        [StringLength(255)]
        public string ComapanyEmail { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(500)]
        public string CompanyDescription { get; set; }
        [Required]
        public string ImageTitle { get; set; }
        [Required]
        public System.Guid ImageID { get; set; }
        public virtual ICollection<JobPosting> JobPostings { get; set; }

        // stoi
    }
}

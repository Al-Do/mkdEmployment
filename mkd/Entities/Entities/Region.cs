using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
  public partial class Region : BaseEntity
    {
        [Key]
        public int RegionID { get; set; }

        [Required]
        [StringLength(100)]
        public string RegionName { get; set; }
    }
}

using System.Collections.Generic;

namespace mkd.Models
{
    public class CompanyJobPostingHandlingModel
    {
        public CompanyModel currentUser { get; set; }
        public List<mkd.Models.JobPostingViewModel> UserPostings {get;set;}
    }
}
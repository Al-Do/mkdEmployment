using mkd.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkd.Helper_Methods
{
    public static class JobPostingInCompanyHelpers
    {
        public static JobPostingViewModel ToPostingViewModel(this JobPosting jobPosting)
        {
            JobPostingViewModel postModel = new JobPostingViewModel()
            {
               CompanyID = jobPosting.CompanyID,
               PostID = jobPosting.PostID,
               JobTitle = jobPosting.JobTitle,
               RegionID = jobPosting.RegionID,
               HoursPerWeek = jobPosting.HoursPerWeek,
               JobDescription = jobPosting.JobDescription,
               JobAvailableToDate = jobPosting.JobAvailableToDate,
               JobPostedDate = jobPosting.JobPostedDate
            };


            return postModel;
        }
    }
}
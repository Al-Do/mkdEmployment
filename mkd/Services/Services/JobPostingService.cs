
using Repository;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class JobPostingService : Service<JobPosting, IJobPostingRepository>, IJobPostingService
    {
        private readonly IJobPostingRepository _jobPostingRepository;
        public override IJobPostingRepository Repository
        {
            get; protected set;
        }
        public JobPostingService(IJobPostingRepository jobPostingRepository)
        {
            _jobPostingRepository = jobPostingRepository;
            Repository = _jobPostingRepository;
        }
      
    }
}

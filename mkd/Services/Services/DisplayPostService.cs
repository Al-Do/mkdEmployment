
using Repository;
using Repository.Interfaces;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Services
{
    public class DisplayPostService : IDisplayPostService
    {
        private readonly IJobPostingRepository _jobPostingRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly ICompanyRepository _companyRepository;
        public DisplayPostService(IJobPostingRepository jobPostingRepository, ICompanyRepository companyRepository, IRegionRepository regionRepository)
        {
            _jobPostingRepository = jobPostingRepository;
            _companyRepository = companyRepository;
            _regionRepository = regionRepository;
        }
        public List<ShortJobPosting> GetPostingsByRegion(int regionId)
        {
            List<ShortJobPosting> postingsByRegion = new List<ShortJobPosting>();
            var postings = _jobPostingRepository.All().Where(p => p.RegionID == regionId).ToList();
            
            postings.ForEach(p =>
            {
                var company = _companyRepository.All().Where(c => c.CompanyID == p.CompanyID).SingleOrDefault();
                var region = _regionRepository.All().Where(r => r.RegionID == p.RegionID).SingleOrDefault();
                ShortJobPosting shortPosting = new ShortJobPosting
                {
                    CompanyName = company.CompanyName,
                    ImagePath = company.CompanyLogoPath,
                    PostID = p.PostID,
                    JobTitle = p.JobTitle,
                    JobPostedDate = p.JobPostedDate,
                    JobAvailableToDate = p.JobAvailableToDate,
                   RegionName = p.Region.RegionName
                    
                };
                postingsByRegion.Add(shortPosting);
            });

            return postingsByRegion;
        }

        public JobPostingModel GetPosting(int jobPostingID)
        {
            var posting = _jobPostingRepository.All().Where(p => p.PostID == jobPostingID).SingleOrDefault();
            var company = _companyRepository.All().Where(c => c.CompanyID == posting.CompanyID).SingleOrDefault();
            var region = _regionRepository.All().Where(r => r.RegionID == posting.RegionID).SingleOrDefault();

            JobPostingModel model = new JobPostingModel {

                PostID = posting.PostID,
                ImagePath = company.CompanyLogoPath,
                CompanyID = company.CompanyID,
                CompanyName = company.CompanyName,
                CompanyEmail = company.ComapanyEmail,
                JobDescription = posting.JobDescription,
                JobTitle = posting.JobTitle,
                HoursPerWeek = posting.HoursPerWeek,
                JobAvailableToDate = posting.JobAvailableToDate.Date,
                JobPostedDate = posting.JobPostedDate.Date,
                RegionName = region.RegionName,
                RegionID = region.RegionID
            };
            
            return model;
        }
    }
}

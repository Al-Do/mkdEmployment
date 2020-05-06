using Services.Interfaces;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System;

namespace mkd.Controllers
{
    public class JobPostingController : Controller
    {
       
        private IJobPostingService _jobPostingService;
        
        private IDisplayPostService _displayPosts;
        public JobPostingController(IJobPostingService jobPostingService, IDisplayPostService displayPosts)
        {
            _jobPostingService = jobPostingService;
            _displayPosts = displayPosts;
            
        }
        [HttpGet]
        // GET: Functionality
        public ActionResult Index()
        {
         
            return View();
        }

        public ActionResult GetPostingsByRegion(int id=6,int page=1)
        {
            var listingsByRegion = _displayPosts.GetPostingsByRegion(id).ToPagedList(page , 5);

            return View(listingsByRegion);
        }
        public ActionResult GetPosting(int ID=0)
        {
          
            var listingsByRegion = _displayPosts.GetPosting(ID);

                return View(listingsByRegion);
          
           
        }

    }
}
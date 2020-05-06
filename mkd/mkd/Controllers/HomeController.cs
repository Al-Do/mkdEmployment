using Services.Interfaces;
using System.Linq;
using System.Web.Mvc;
namespace mkd.Controllers
{
    public class HomeController : Controller
    {
        private IJobPostingService _jobPostingService;
        private IDisplayPostService _displayPosts;
        
        public HomeController(IJobPostingService jobPostingService, IDisplayPostService displayPosts)
        {
            _jobPostingService = jobPostingService;
            _displayPosts = displayPosts;
        }
        public ActionResult Index()
        {
            
            var listingsByRegion = _displayPosts.GetPostingsByRegion(4).Take(5).ToList();
            return View(listingsByRegion);
        }

        public ActionResult About()
        {
            ViewBag.Message = "About MKD-Employment";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
    }
}
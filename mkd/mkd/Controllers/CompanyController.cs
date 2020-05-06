
using mkd.Helper_Methods;
using Services.Models;
using Repository;
using Services.Interfaces;
using mkd.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace mkd.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;
        private IJobPostingService _jobPostingService;
        private IRegionService _regionService;
        public CompanyController(ICompanyService companyService, IJobPostingService jobPostingService, IRegionService regionService)
        {
            _companyService = companyService;
            _jobPostingService = jobPostingService;
            _regionService = regionService;
        }
        [Authorize]
        public ActionResult Index()
        {


            var ident = System.Web.HttpContext.Current.User.Identity.Name;
            var comp = _companyService.GetAll(c => c.ComapanyEmail == ident).FirstOrDefault();
            if (comp != null)
            {
                CompanyJobPostingHandlingModel doubleModel = new CompanyJobPostingHandlingModel();
                doubleModel.currentUser = comp.ToCategoryViewModel();
                var postings = _jobPostingService.GetAll().Where(t => t.CompanyID == comp.CompanyID).ToList();
                List<JobPostingViewModel> mappedPostings = new List<JobPostingViewModel>();
                postings.ForEach(p => mappedPostings.Add(p.ToPostingViewModel()));
                doubleModel.UserPostings = mappedPostings;
                return View(doubleModel);
            };

            return RedirectToAction("Login");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var jobPosting = _jobPostingService.GetAll().FirstOrDefault(x => x.PostID == id);
            if (jobPosting != null)
            {
                _jobPostingService.Delete(jobPosting);
            }
           
          return  RedirectToAction("Index");
        }
        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            var v = _companyService.GetAll().Where(a => a.ComapanyEmail == emailID).FirstOrDefault();
            return v != null;
        }
        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
            //{
            //    var verifyUrl = "/company/VerifyAccount/" + activationCode;
            //    var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            //    var fromEmail = new MailAddress("servicesicret@gmail.com", "Alex D");
            //    var toEmail = new MailAddress(emailID);
            //    var fromEmailPassword = ""; // Replace with actual password
            //    string subject = "Your account is successfully created!";

            //    string body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
            //        " successfully created. Please click on the below link to verify your account" +
            //        " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            //    var smtp = new SmtpClient
            //    {
            //        Host = "smtp.gmail.com",
            //        Port = 587,
            //        EnableSsl = true,
            //        DeliveryMethod = SmtpDeliveryMethod.Network,
            //        UseDefaultCredentials = false,
            //        Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            //    };

            //    using (var message = new MailMessage(fromEmail, toEmail)
            //    {
            //        Subject = subject,
            //        Body = body,
            //        IsBodyHtml = true
            //    })
            //        smtp.Send(message);
        }
        // GET: Company
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(CompanyModel company)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {
                //Email exists
                var isExist = IsEmailExist(company.ComapanyEmail);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(company);
                }

                string fileName = Path.GetFileNameWithoutExtension(company.Imagefile.FileName);
                string extention = Path.GetExtension(company.Imagefile.FileName);
                fileName = fileName + DateTime.UtcNow.ToString("yymmssfff") + extention;
                company.ImageTitle = fileName;
                company.CompanyLogoPath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                company.Imagefile.SaveAs(fileName);
                //company.Password = Crypto.Hash(company.Password);
                company.ConfirmPassword = Crypto.Hash(company.ConfirmPassword);
                Company companyEntity = new Company
                {
                    ComapanyEmail = company.ComapanyEmail,
                    CompanyDescription = company.CompanyDescription,
                    Password = Crypto.Hash(company.Password),
                    CompanyLogoPath = company.CompanyLogoPath,
                    CompanyName = company.CompanyName,
                    ImageTitle = company.ImageTitle


                };
                companyEntity.ImageID = Guid.NewGuid();


                // Save to Database

                message = "Registration successfully done for:" + company.ComapanyEmail;

                Status = true;
                _companyService.Create(companyEntity);

            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel login, string ReturnUrl = "")
        {
            string message = "";

            var v = _companyService.GetAll().Where(a => a.ComapanyEmail == login.CompanyEmail).FirstOrDefault();
            if (v != null)
            {
                //if (!v.IsEmailVerified)
                //{
                //    ViewBag.Message = "Please verify your email first";
                //    return View();
                //}
                if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                {
                    int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                    var ticket = new FormsAuthenticationTicket(login.CompanyEmail, login.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);


                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Company");
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            else
            {
                message = "Invalid credential provided";
            }

            ViewBag.Message = message;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Company");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddJobPosting()
        {
            var regions = _regionService.GetAll().ToList();
            List<RegionModel> regions1 = new List<RegionModel>();
            foreach (var item in regions)
            {
                RegionModel model = new RegionModel()
                {
                    RegionID = item.RegionID,
                    RegionName = item.RegionName
                };
                regions1.Add(model);
            }
            return View();

        }
        //[Authorize]
        //public ActionResult GetPostingsByCompanyID()
        //{
        //    var ident = System.Web.HttpContext.Current.User.Identity.Name;
        //    var comp = _companyService.GetAll(c => c.ComapanyEmail == ident).FirstOrDefault();
        //    if (comp != null)
        //    {
        //        var postings = _jobPostingService.GetAll().Where(t => t.CompanyID == comp.CompanyID).ToList();
        //        postings.ForEach(x => x.ToPostingViewModel());
        //        return PartialView("_companyPostings", postings);
        //    };
        //    return RedirectToAction("Login", "Company");
        //}
        [Authorize]
        [HttpPost]
        public ActionResult AddJobPosting(JobPostingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ident = System.Web.HttpContext.Current.User.Identity.Name;
                var comp = _companyService.GetAll(c => c.ComapanyEmail == ident).FirstOrDefault();
                if (comp != null)
                {
                    JobPosting posting = new JobPosting
                    {
                        CompanyID = comp.CompanyID,
                        JobPostedDate = DateTime.Now.Date,
                        JobAvailableToDate = model.JobAvailableToDate,
                        JobTitle = model.JobTitle,
                        JobDescription = model.JobDescription,
                        RegionID = model.RegionID,
                        HoursPerWeek = model.HoursPerWeek
                    };
                    _jobPostingService.Create(posting);
                    return RedirectToAction("Index", "Company");
                }
            }

            return View("AddJobPosting", model);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var posting = _jobPostingService.GetAll().ToList().FirstOrDefault(x => x.PostID == id);
            if (posting != null)
            {
                JobPostingViewModel mappedPosting = new JobPostingViewModel();
                mappedPosting = posting.ToPostingViewModel();

                return View(mappedPosting);
            }
            return null;
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(JobPostingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ident = System.Web.HttpContext.Current.User.Identity.Name;
                var comp = _companyService.GetAll(c => c.ComapanyEmail == ident).FirstOrDefault();
                if (comp != null)
                {
                    JobPosting posting = new JobPosting
                    {
                        CompanyID = comp.CompanyID,
                        JobPostedDate = DateTime.Now.Date,
                        JobAvailableToDate = model.JobAvailableToDate,
                        JobTitle = model.JobTitle,
                        JobDescription = model.JobDescription,
                        RegionID = model.RegionID,
                        HoursPerWeek = model.HoursPerWeek,
                        PostID = model.PostID
                    };
                    _jobPostingService.Create(posting);
                    return RedirectToAction("Index", "Company");
                }
            }

            return View("Edit", model);
        }

    }
}
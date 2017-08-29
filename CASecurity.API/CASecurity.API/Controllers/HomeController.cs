using CASecurity.API.Domain;
using CASecurity.API.Migrations;
using CASecurity.API.Models;
using CASecurity.API.Providers;
using CASecurity.API.Service;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CASecurity.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ILogger _logger = NullLogger.Instance;
        private readonly ICAService _service;

        public HomeController()
        {
            _service = new CAService();
        }
        

        public HomeController(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _service = new CAService();

        }
        //public ILogger Logger
        //{
        //    get { return logger; }
        //    set { logger = value; }
        //}
        public ActionResult Index()
        {
            
            ViewBag.Title = "Home Page";
            //var model = new List<IssueCertificateModel>();
            //foreach (var user in _context.Users)
            //{
            //    model.Add(new IssueCertificateModel
            //    {
            //        UserName = user.UserName,
            //        EmailId = user.Email,
            //        DeviceId = user.DeviceId,
            //        PassportNo = user.PassportNo,
            //        UserNIC = user.UserNIC,
            //        MobileNo = user.PhoneNumber,
            //        Bank = user.Bank,
            //        PlatForm = user.PlatForm,

            //    });
            //}

           // _logger.Error("test");


            return View();
        }


        public ActionResult Insert()
        {
            try
            {
                var challenge = MapSDKData();

                //_service.InsertChallenge(challenge);

                return Json(challenge.Id.ToString(), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
          
        }

        public ActionResult ListData()
        {           
            var lst=_service.GetAll();

            return Json(lst, JsonRequestBehavior.AllowGet);
        }


        private IssueChallenge MapSDKData()
        {
            var challenge = new IssueChallenge
            {
                DeviceId = "115553453533",
                AppId = "Android.13.31.",
                BankCode ="BoC.100.108",
                Parameters ="Any Json Values",
                ChallengeToken = RandomOAuthStateGenerator.Generate(256),
                TokenIssued = true,
                TokenIssuedDateTime = DateTime.Now,
                TokenValidatedDateTime = null,
                TokenValidated = false,
            };
            return challenge;
        }

    }
}

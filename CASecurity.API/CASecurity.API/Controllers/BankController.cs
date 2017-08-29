using CASecurity.API.Domain;
using CASecurity.API.Infrastructure;
using CASecurity.API.Migrations;
using CASecurity.API.Models;
using CASecurity.API.Providers;
using CASecurity.API.Repository;
using CASecurity.API.Service;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using static CASecurity.API.Common.Enums;

namespace CASecurity.API.Controllers
{

    // First, open a web browser window and navigate to http://hostname/certsrv/certrqxt.asp and click on Request Certificate.
    // Enter the URL at which the portal requests and receives client certificates from the SCEP server.For example:
    // http://<hostname>/certsrv/mscep/ 


    [RoutePrefix("bank/api/v1")]
    public class BankController : ApiController
    {     
        private readonly ICAService _service;
        private readonly IAppService _appService;

        public BankController()
        {
            _service = new CAService();
            _appService = new AppService();
        }
        public BankController(ApplicationDbContext context, IRepository repository, IUnitOfWork unitOfWork)
        {            
            
        }
       

        //POST api/bank/issuechellange
        //[AuthorizeIPAddress]
        [HttpPost]
        [AllowAnonymous]
        [Route("issue_certificate")]
        public async Task<IHttpActionResult> Challenge(ApiModelNew model)
        {
            var token = new ApiSuccessResponse();           
            try
            {
                if (!ModelState.IsValid)
                {
                    var failure = new FailureResponse
                    {
                        Status = APIResponseStatus.MandataryFieldsAreMissing.ToString(),
                        Error = "Required fields are not provided",
                        Code = "400"
                    };
                    return Json(failure);
                }

                var justPayCode = model.justpay_code;
                
                //the app with just pay code
                var isJustPayCodeAvailable = await _appService.GetApp(justPayCode);
                if(isJustPayCodeAvailable==null)
                {
                    var failure = new FailureResponse
                    {
                        Status = APIResponseStatus.NoMatchingData.ToString(),
                        Error = "No Combination Found",
                        Code = "400"
                    };
                    return Json(failure);
                }

                //map data
                var challenge = MapCertificate(model);
                var exiting = await _service.CheckChallenge(model);
                if (exiting == null)
                {
                    challenge.UserDeviceLogs.Add(new UserDeviceLog
                    {
                        LogDateTime = DateTime.Now,
                        Status = CallFrom.Bank.ToString(),
                        UserDevice = challenge
                    });

                    //call service to store data 
                    _service.InsertChallengeAsync(challenge);
                  
                    //map challenge token
                    token.CertificateChallenge = challenge.CertificateChallenge.Trim();
                    token.Status = APIResponseStatus.Success.ToString();
                   
                    return Json(token);
                }

                token.CertificateChallenge = exiting.CertificateChallenge.ToString();
                token.Status = APIResponseStatus.Success.ToString();
                
                return Json(token);

            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendErrorToText(ex);

                var failure = new FailureResponse
                {
                    Status = APIResponseStatus.ServerError.ToString(),
                    Error = "Server Error !",
                    Code = "400"
                };
                return Json(failure);
            }


        }                       
      
        private async Task<bool> IsExistWithAllParameters(ApiModelNew model)
        {
            var exiting = await _service.CheckChallenge(model);
            if (exiting != null)
            {
                return true;
            }

            return false;
        }

        private UserDevice MapCertificate(ApiModelNew model)
        {
            var param = model.justpay_code.Split('_');
            var challenge = new UserDevice
            {
                DeviceId = model.device_id,
                BankId = param[0].ToString(),
                MerchantId = param[1].ToString(),
                AppId = param[2].ToString(),               
                CertificateChallenge= RandomOAuthStateGenerator.Generate(1024),
                EmailId=model.user_email,                
                MobileNo=model.user_mobile,
                Platform=model.platform,
                UserName=model.user_name,
                UserNic=model.user_id,
                UserPassport=model.user_id,                
                Status="B",
                VaidityPriod=DateTime.Now.AddHours(1),
                NoOfAttempt=1,
                IsActive=true,
                CreatedDate=DateTime.Now,
                JustPayCode = model.justpay_code,

        };
            return challenge;
        }




    }
}

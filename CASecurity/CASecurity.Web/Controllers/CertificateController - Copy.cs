using CASecurity.API.Domain;
using CASecurity.API.Filters;
using CASecurity.API.Migrations;
using CASecurity.API.Models;
using CASecurity.API.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CASecurity.API.Controllers
{

    // First, open a web browser window and navigate to http://hostname/certsrv/certrqxt.asp and click on Request Certificate.
    // Enter the URL at which the portal requests and receives client certificates from the SCEP server.For example:
    // http://<hostname>/certsrv/mscep/ 


    [RoutePrefix("api/CertificateTest")]
    public class CertificateTestController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;
       
        public CertificateTestController()
        {
        }

        public CertificateTestController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat, ApplicationDbContext context)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
            _context = context;
           
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        //POST api/Certificate/IssueToken
        [AuthorizeIPAddress]
        [HttpPost]
        [AllowAnonymous]
        [Route("IssueToken")]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        public async Task<IHttpActionResult> CertificateToken(IssueCertificateModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //var model = new IssueCertificateModel
                //{
                //    UserName = "navaseelan4u@gmail.com",
                //    EmailId = "navaseelan4u@gmail.com",
                //    DeviceId = "1412151515",
                //    Bank = "sampath",
                //    PassportNo = "11511163363",                
                //    MobileNo = "0774533226",
                //    PlatForm = "android",
                //    UserNIC = "12515151517V",                
                //};

                var user = MapCertificateRequest(model);
                IdentityResult result = await UserManager.CreateAsync(user, user.UserNIC);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["baseUrl"].ToString());
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var authorizationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["ClientSecret"].ToString()));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeader);

                    var form = new Dictionary<string, string>
                       {
                           {"grant_type", "password"},
                           {"username", user.Email},
                           {"password", user.UserNIC},
                       };

                    var tokenResponse = client.PostAsync("Token", new FormUrlEncodedContent(form)).Result;
                    var token = tokenResponse.Content.ReadAsAsync<TokenResponse>(new[] { new JsonMediaTypeFormatter() }).Result;
                    token.ClientId = user.Id.ToString();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

                    return Ok(token);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace.ToString());
            }


        }

        //[Authorize]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("GetTokenInfo")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTokenUserInfo(string clientId)
        {
            var user = await UserManager.FindByIdAsync(clientId);
            if (user == null)
            {
                return NotFound();
            }
            
            var data = new IssueCertificateModel
            {
                UserName = user.UserName,
                EmailId = user.Email,
                DeviceId = user.DeviceId,
                PassportNo = user.PassportNo,
                UserNIC = user.UserNIC,
                MobileNo = user.PhoneNumber,
                Bank = user.Bank,
                PlatForm = user.PlatForm,
                
            };

            user.TokenValidatedDateTime = DateTime.Now;
            user.TokenValidated = true;
            var update=await UserManager.UpdateAsync(user);


            return Ok(data);
        }

        //[Authorize]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("GetCSRData")]
        [HttpGet]
        //public async Task<IHttpActionResult> GetCSRData(CSRServiceModel model)
        public async Task<IHttpActionResult> GetCSRData(string clientId)
        {
            //var _cert = new CertificateGenerator();
            var model = new CSRServiceModel
            {
                UserName = "navaseelan4u@gmail.com",
                EmailId = "navaseelan4u@gmail.com",
                DeviceId = "1412151515",
                Bank = "sampath",
                PassportNo = "11511163363",
                MobileNo = "0774533226",
                PlatForm = "android",
                UserNIC = "12515151517V",
                ClientId= clientId,
                AccessToken= clientId
            };

            var ObjectID = "1.2.3.4.5.6.78.10";
            // var certificate = _cert.CreateCertRequestMessage(ObjectID, string.Empty);

            //var decode = _cert.DecodeCertificate("");

           // _cert.ValidateSignedPkcs7("","");

            //var certificate = _cert.CreateCertRequestMessage(model.AccessToken, model.ClientId, model.UserName, model.EmailId,
            //   model.DeviceId, model.PlatForm, model.UserNIC, model.PassportNo, model.MobileNo, model.Bank, ObjectID, string.Empty);

            return Ok();
        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
        private ApplicationUser MapCertificateRequest(IssueCertificateModel model)
        {
            const int strengthInBits = 256;
            var issueToken = RandomOAuthStateGenerator.Generate(strengthInBits);

            var user = new ApplicationUser
            {
                UserName = model.EmailId,
                Email = model.EmailId,
                DeviceId = model.DeviceId,
                Bank = model.Bank,
                PassportNo = model.PassportNo,
                EmailConfirmed = true,
                PhoneNumber = model.MobileNo,
                PlatForm = model.PlatForm,
                PhoneNumberConfirmed = true,
                UserNIC = model.UserNIC,
                ChallengeToken = issueToken,
                Country = "SL",
                TokenIssued = true,
                TokenIssuedDateTime = DateTime.Now,
                TokenValidatedDateTime = null,
                TokenValidated = false,
            };
            return user;
        }


        

    }
}

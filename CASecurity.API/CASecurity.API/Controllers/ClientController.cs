using CASecurity.API.Infrastructure;
using CASecurity.API.Migrations;
using CASecurity.API.Models;
using CASecurity.API.Repository;
using CASecurity.API.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static CASecurity.API.Common.Enums;

namespace CASecurity.API.Controllers
{
    [RoutePrefix("trustedsdk/api/v1")]
    public class ClientController : ApiController
    {        
        private readonly ICAService _service;
        private readonly string baseUrl = System.Configuration.ConfigurationManager.AppSettings["lcBaseUrl"].ToString();
        
        public ClientController()
        {           
            _service = new CAService();
        }
      
        [AllowAnonymous]
        [Route("client")]
        [HttpGet]
        public async Task<IHttpActionResult> ClientInfo(string challenge)
        {
            try
            {
                var client = await _service.GetChallenge(challenge);
                if (client == null)
                {
                    var failure = new FailureResponse
                    {
                        Status = APIResponseStatus.NoMatchingData.ToString(),
                        Error = "No Combination Found",
                        Code = "400"
                    };
                    return Json(failure);
                }

                var packageName = string.Empty;
                var app = await _service.GetPackageName(client.JustPayCode);
                if (app != null)
                    packageName = app.Package;

                //if exists, map data
                var data = new 
                {                    
                    device_id = client.DeviceId,
                    user_email=client.EmailId,
                    user_mobile=client.MobileNo,                    
                    platform=client.Platform,
                    user_id=client.UserNic,
                    user_name=client.UserName,
                    justpay_code = client.JustPayCode,
                    package_name= packageName
                };

                client.ValidatedDateTime = DateTime.Now;                
                await _service.UpdateChallengeAsync(client);
                return Json(data);
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendErrorToText(ex);
                var failure = new FailureResponse
                {
                    Status = APIResponseStatus.ServerError.ToString(),
                    Error = "Something went wrong, we are working on this!",
                    Code = "400"
                };
                return Json(failure);
               
            }
            
        }

        [AllowAnonymous]
        [Route("certificate")]
        [HttpPost]
        public IHttpActionResult CSRService(SDKCall model )
        {
            var fileMaxKbSize = 1024;
            var failure = new FailureResponse
            {
                Status = APIResponseStatus.NoMatchingData.ToString(),
                Error = "Something went wrong, we are working on this!",
                Code = "400"
            };

            try
            {
                var client = _service.GetChallenge(model.challenge);
                if (client == null)
                {              
                    return Json(failure);
                }

                var regUrl = "?operation=PKIOperation&message=" + model.pkcs7csr;
                var url = baseUrl.Trim() + regUrl;

                //var regUrl = "?operation=PKIOperation&message=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";
                //var url = baseUrl.Trim() + regUrl;


                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webRequest.Credentials = CredentialCache.DefaultCredentials;
                webRequest.KeepAlive = true;
                webRequest.ContentLength = 0;
                webRequest.ContentType = "application/x-pki-message";
                webRequest.Method = "GET";

                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    Int64 fileSize = webResponse.ContentLength;
                    using (MemoryStream m = new MemoryStream())
                    {
                        Stream receiveStream = webResponse.GetResponseStream();                
                        
                        byte[] buffer = new byte[fileSize];

                        int bytesRead;
                        while ((bytesRead = receiveStream.Read(buffer, 0, buffer.Length)) != 0 && bytesRead <= fileMaxKbSize * 1024)
                        {
                            m.Write(buffer, 0, bytesRead);
                        }
                        m.Position = 0;
                        webResponse.Close();

                        //var signedDataInText = Convert.ToBase64String(m.GetBuffer());
                        var signedDataInText = m.GetBuffer();
                        var response = new CSRSuccessResponse
                        {
                            Certificate = signedDataInText,
                            Status = APIResponseStatus.Success.ToString(),
                        };

                        return Json(response);
                    }

                }                              

                return Json(failure);

            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendErrorToText(ex);              
                return Json(failure);
            }

        }

       
    }
}

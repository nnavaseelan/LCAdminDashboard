using CASecurity.API.Infrastructure;
using CASecurity.API.Models;
using CASecurity.API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace CASecurity.API.Controllers
{
    [RoutePrefix("api/lcndes")]
    public class LCServiceController : ApiController
    {
        private readonly ICAService _service;
        private readonly string baseUrl = System.Configuration.ConfigurationManager.AppSettings["lcBaseUrl"].ToString();
        private readonly string ndesService1 = System.Configuration.ConfigurationManager.AppSettings["ndesService1"].ToString();
        private readonly string ndesService2 = System.Configuration.ConfigurationManager.AppSettings["ndesService2"].ToString();
        private readonly string ndesService3 = System.Configuration.ConfigurationManager.AppSettings["ndesService3"].ToString();
        private readonly string ndesService4 = System.Configuration.ConfigurationManager.AppSettings["ndesService4"].ToString();

         //Content Types

        //Possible values for Content-Type:
        //application/x-pki-message:
        //in response to the PKIOperation operation, with pkiMessage of type: PKCSReq, GetCertInitial, GetCert or GetCRL
        //response body is a pkiMessage of type: CertRep
        //application/x-x509-ca-cert:
        //in response to the GetCACert operation
        //response body is the DER-encoded X.509 CA certificate
        //application/x-x509-ca-ra-cert:
        //in response to the GetCACert operation
        //response body is a DER-encoded degenerate PKCS#7 that contains the CA and RA certificates
        //application/x-x509-next-ca-cert:
        //in response to the GetNextCACert operation
        //response body is a variation of a pkiMessage of type: CertRep

        public LCServiceController()
        {
            _service = new CAService();
        }

        [AllowAnonymous]
        [Route("pkcsreq")]
        [HttpGet]
        public async Task<IHttpActionResult> pkcsrequest(ClientApiModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl.Trim());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-pki-message"));

                    var regUrl = "?operation=PKIOperation&message=" + model.Pkcs10Message;

                    var content = new ClientApiModel
                    {
                        CertificateChallenge = model.CertificateChallenge,
                    };

                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Trim());
                    HttpResponseMessage response = await client.PostAsJsonAsync(regUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var res= await response.Content.ReadAsHttpResponseMessageAsync();
                        var data = await response.Content.ReadAsAsync<APIResponse>();
                    }
                    else
                    {

                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
                return BadRequest(ex.Message.ToString());
            }

        }
        [AllowAnonymous]
        [Route("ndescrl")]
        [HttpGet]
        public async Task<IHttpActionResult> ndesservice2(ClientApiModel model)
        {
            try
            {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(baseUrl.Trim());
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                      var regUrl = "?operation=PKIOperation&message=" + model.Pkcs10Message;

                      var content = new ClientApiModel
                        {
                          CertificateChallenge = model.CertificateChallenge,

                        };
                        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Trim());
                        HttpResponseMessage response = await client.PostAsJsonAsync(regUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsAsync<APIResponse>();
                        }
                        else
                        {

                        }
                    }
                  return Ok();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
                return BadRequest(ex.Message.ToString());
            }

        }
        [AllowAnonymous]
        [Route("ndesservice3")]
        [HttpGet]
        public async Task<IHttpActionResult> ndesservice3(ClientApiModel model)
        {
            try
            {
                //https://tools.ietf.org/html/draft-nourse-scep-19#section-3.1
                //GetCRL
                //  o a transactionID(Section 3.1.1.1) attribute
                //o  a messageType (Section 3.1.1.2) attribute set to PKCSReq
                //   o a senderNonce(Section 3.1.1.5) attribute
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl.Trim());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var regUrl = "?operation=PKIOperation&message=" + model.Pkcs10Message;

                    var content = new ClientApiModel
                    {
                        CertificateChallenge = model.CertificateChallenge,

                    };
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Trim());
                    HttpResponseMessage response = await client.PostAsJsonAsync(regUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsAsync<APIResponse>();
                    }
                    else
                    {

                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
                return BadRequest(ex.Message.ToString());
            }

        }
        [AllowAnonymous]
        [Route("ndesservice4")]
        [HttpGet]
        public async Task<IHttpActionResult> ndesservice4(ClientApiModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl.Trim());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var regUrl = "?operation=GetCRL&message=" + model.Pkcs10Message;

                    var content = new ClientApiModel
                    {
                        CertificateChallenge = model.CertificateChallenge,

                    };
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Trim());
                    HttpResponseMessage response = await client.PostAsJsonAsync(regUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsAsync<APIResponse>();
                    }
                    else
                    {

                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
                return BadRequest(ex.Message.ToString());
            }

        }
    }
}

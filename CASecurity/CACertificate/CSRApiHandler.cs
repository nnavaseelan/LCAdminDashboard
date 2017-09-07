using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CACertificate
{
    public class CSRApiHandler:IDisposable
    {
        public async Task<APIToken> GetToken(string bankApiUrl,string deviceId, string AppId, string BankCode,string MerchantId,string Parameters,string ChallengeToken)
        {
            var token = new APIToken();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(bankApiUrl.Trim());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.Timeout = 5000;  
                                   
                    var content = new ApiSDKModel
                    {
                        DeviceId = deviceId,
                        AppId = AppId,
                        BankCode = BankCode,
                        MerchantId = MerchantId,
                        Parameters = Parameters,
                        ChallengeToken = ChallengeToken,
                    };
                                        
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/bank/issuechallenge", content);
                    if (response.IsSuccessStatusCode)
                    {
                         token = await response.Content.ReadAsAsync<APIToken>();
                    }
                    else
                    {
                       
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return token;



        }
        public async Task<ApiModel> GetClientInFo(string clientApiUrl, string challengeToken)
        {
            var token = new ApiModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(clientApiUrl.Trim());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new ClientApiModel
                    {
                        ClientId = challengeToken,
                        PkcsMessage = string.Empty,
                    };

                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Trim());
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/client/clientdata", content);
                    if (response.IsSuccessStatusCode)
                    {
                        token = await response.Content.ReadAsAsync<ApiModel>();
                    }
                    else
                    {
                      
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return token;



        }
        public async Task<ApiModel> SignCSR(string clientApiUrl, string pkcsMessage, string challengeToken)
        {
            var token = new ApiModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(clientApiUrl.Trim());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new ClientApiModel
                    {
                        ClientId = challengeToken,
                        PkcsMessage= pkcsMessage,
                    };

                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Trim());
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/client/clientdata", content);
                    if (response.IsSuccessStatusCode)
                    {
                        token = await response.Content.ReadAsAsync<ApiModel>();
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return token;



        }
        public async Task<ApiModel> ValidateCSR(string clientApiUrl, string accessToken, string challengeToken)
        {
            var token = new ApiModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(clientApiUrl.Trim());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new ClientApiModel
                    {
                        ClientId = challengeToken,
                        // AccessToken= accessToken,
                    };
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Trim());
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/client/clientdata", content);
                    if (response.IsSuccessStatusCode)
                    {
                        token = await response.Content.ReadAsAsync<ApiModel>();
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return token;



        }
        public async Task<ApiModel> CRLData(string clientApiUrl, string tracnsationId, string challengeToken)
        {
            var token = new ApiModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(clientApiUrl.Trim());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new ClientApiModel
                    {
                        ClientId = challengeToken,
                        // AccessToken= accessToken,
                    };
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Trim());
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/client/clientdata", content);
                    if (response.IsSuccessStatusCode)
                    {
                        token = await response.Content.ReadAsAsync<ApiModel>();
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return token;



        }
        public async Task<ApiModel> RenewCertificate(string clientApiUrl, string transactionId, string challengeToken)
        {
            var token = new ApiModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(clientApiUrl.Trim());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new ClientApiModel
                    {
                        ClientId = challengeToken,
                        // AccessToken= accessToken,
                    };
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Trim());
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/client/clientdata", content);
                    if (response.IsSuccessStatusCode)
                    {
                        token = await response.Content.ReadAsAsync<ApiModel>();
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return token;



        }
        


        public class ApiSDKModel
        {
            public string DeviceId { get; set; }
            public string AppId { get; set; }
            public string BankCode { get; set; }
            public string MerchantId { get; set; }
            public string Parameters { get; set; }
            public string ChallengeToken { get; set; }

        }
        public class ApiModel 
        {
            public string EmailId { get; set; }
            public string DeviceId { get; set; }
            public string PassportNo { get; set; }
            public string UserNIC { get; set; }

        }
        public class ClientApiModel
        {
            public string ClientId { get; set; }
            public string AccessToken { get; set; }
            public string PkcsMessage { get; set; }
        }







        public void Dispose()
        {
            this.Dispose();
        }

    }
}

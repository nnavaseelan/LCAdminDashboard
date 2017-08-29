using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASecurity.API.Models
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("userName")]
        public string Username { get; set; }

        [JsonProperty(".issued")]
        public string IssuedAt { get; set; }

        [JsonProperty(".expires")]
        public string ExpiresAt { get; set; }
        [JsonProperty("ClientId")]
        public string ClientId { get; set; }
    }

    public class ApiSuccessResponse
    {
        [JsonProperty("challenge")]
        public string CertificateChallenge { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        

    }
    public class FailureResponse
    {
        [JsonProperty("error_code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }

    }

    public class CSRSuccessResponse
    {
        [JsonProperty("certificate")]
        public byte[] Certificate { get; set; }

        //[JsonProperty("certificate1")]
        //public string Certificate1 { get; set; }


        //[JsonProperty("certificate2")]
        //public string Certificate2 { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

      

    }
}
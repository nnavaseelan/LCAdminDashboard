using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASecurity.API.Models
{
    public class ClientApiModel: ApiModel
    {
        public string Pkcs10Message { get; set; }
        public string JustPayCode { get; set; }
    }

    public class SDKCall
    {
        public string challenge { get; set; }
        public string pkcs7csr { get; set; }
    }
}
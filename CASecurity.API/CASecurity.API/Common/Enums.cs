using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASecurity.API.Common
{
    public static class Enums
    {
        public  enum APIResponseStatus
        {
            Success,
            Falied,
            NotFound,
            BadRequest,
            NoMatchingData,
            MandataryFieldsAreMissing,
            ServerError
        }
        public enum CallFrom
        {
            Bank,
            Client,
            SDK,
            None
        }
    }
}
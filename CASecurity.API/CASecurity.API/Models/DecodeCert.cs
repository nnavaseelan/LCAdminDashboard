using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASecurity.API.Models
{
    public class DecodeCert
    {
        public string CommonName { get; set; }
        public string Organization { get; set; }
        public string OrganizationUnit { get; set; }
        public string Locality { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string EmailId { get; set; }
    }
}
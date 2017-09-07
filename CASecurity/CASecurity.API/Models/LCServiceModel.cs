using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CASecurity.API.Models
{
    public class CSRServiceModel: IssueCertificateModel
    {
        [Required]              
        public string AccessToken { get; set; }
        public string ClientId { get; set; }
        
    }
}
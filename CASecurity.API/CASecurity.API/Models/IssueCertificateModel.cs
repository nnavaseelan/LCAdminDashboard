using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CASecurity.API.Models
{
    public class IssueCertificateModel
    {
        [Required]
        [MaxLength(30)]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string EmailId { get; set; }

        [Required]
        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string DeviceId { get; set; }


        [Required]
        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string PlatForm { get; set; }

        [Required]
        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string UserNIC { get; set; }

        [Required]
        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string PassportNo { get; set; }

        [Required]
        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string MobileNo { get; set; }

        [Required]
        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Bank { get; set; }


    }
}
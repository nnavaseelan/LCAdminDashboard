using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CASecurity.API.Domain
{
    public class UserDevice
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string DeviceId { get; set; }
        [Required]
        public string BankId { get; set; }
        [Required]
        public string MerchantId { get; set; }

        [Required]
        public string Platform { get; set; }

        [Required]
        public string UserName { get; set; }
        public string AppId { get; set; }
        [Required]
        public string UserNic { get; set; }
        [Required]
        public string UserPassport { get; set; }
        
        [Required]
        public string JustPayCode { get; set; }
        
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string MobileNo { get; set; }
        public string CertificateChallenge { get; set; }
        public string Status { get; set; }
        public DateTime? IssuedDateTime { get; set; }
        public DateTime VaidityPriod { get; set; }
        public DateTime? ValidatedDateTime { get; set; }
        public bool IsActive { get; set; }
        public int NoOfAttempt { get; set; }

        public DateTime CreatedDate { get; set; }
        public ICollection<UserDeviceLog> UserDeviceLogs { get; set; }

        public UserDevice()
        {
            Id = Guid.NewGuid();
            JustPayCode = MerchantId + "-" + BankId + "-" + DeviceId;
            UserDeviceLogs = new List<UserDeviceLog>();
        }

   

    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CASecurity.API.Models
{
    public class ApiModel
    {
        
        [Required]
        public string DeviceId { get; set; }
        [Required]
        public string BankId { get; set; }
        [Required]
        public string MerchantId { get; set; }

        [Required]
        public string Platform { get; set; }
        public string AppId { get; set; }

        [Required]
        public string UserName { get; set; }

        public string UserNic { get; set; }
       
        public string UserPassport { get; set; }
                
        [Required]
        public string UserId { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string MobileNo { get; set; }
        public string CertificateChallenge { get; set; }

        //“bank_id”= “XXXX”, 
        //“merchant_id” = “YYYYYY”,
        //“device_id” = “4534TRTTLRTYRTYRTYRTTRYTR”,
        //“platform”  = “Android”,
        //“user_mail” = “user @company.com”,
        //“user_name” = “User First name, User Last Name”,
        //“user_nic” = “7XXXXXXXXXX”,
        //“user_passport” = “NXXXXXXXXX”,
        //“user_mobile” = “7657567567567”  

    }
    public class ApiModelNew
    {
        [Required]
        public string device_id { get; set; }
        [Required]
        public string justpay_code { get; set; }
        [Required]
        public string platform { get; set; }  

        [Required]
        public string user_name { get; set; }

        [Required]
        public string user_id { get; set; }
        [Required]
        [EmailAddress]
        public string user_email { get; set; }
        [Required]
        public string user_mobile { get; set; }     

        //“bank_id”= “XXXX”, 
        //“merchant_id” = “YYYYYY”,
        //“device_id” = “4534TRTTLRTYRTYRTYRTTRYTR”,
        //“platform”  = “Android”,
        //“user_mail” = “user @company.com”,
        //“user_name” = “User First name, User Last Name”,
        //“user_nic” = “7XXXXXXXXXX”,
        //“user_passport” = “NXXXXXXXXX”,
        //“user_mobile” = “7657567567567”  

    }


    public class APIResponse
    {
        public string Reject { get; set; }
        public string Pending { get; set; }
        public string Success { get; set; }
        public string RecipientNonce { get; set; }
    }
}
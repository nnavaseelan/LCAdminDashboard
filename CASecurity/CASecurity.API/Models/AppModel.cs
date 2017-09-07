using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CASecurity.API.Models
{
    public class AppModel
    {
        public string Id { get; set; }
        public string BankMerchantId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Package { get; set; }
        //[Required]
        public string Address { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string PlatForm { get; set; }
       // [Required]
        public string Production { get; set; }
       // [Required]
        public string SandBox { get; set; }
        //[Required]
        public DateTime? SDKIssuedDateTime { get; set; }
        [Required]
        public string BankId { get; set; }
        [Required]
        public string MerchantId { get; set; }
        //[Required]
        public string BMCode { get; set; }
        public string JustPayCode { get; set; }
    }
}
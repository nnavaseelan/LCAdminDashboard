using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CASecurity.API.Models
{
    public class BankModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(4)]
        public string Code { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactPersonName { get; set; }
        [Required]
        [EmailAddress]
        public string ContactPersonEmailId { get; set; }
        [Required]
        [Phone]
        public string ContactPersonMobileNo { get; set; }

        public bool IsActive { get; set; }
       
    }
}
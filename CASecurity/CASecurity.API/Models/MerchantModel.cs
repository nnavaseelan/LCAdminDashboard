using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CASecurity.API.Models
{
    public class MerchantModel
    {
        public string Id { get; set; }        
        public string Bank { get; set; }
        [Required]
        public string BankId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BRC { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(4)]
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public List<SelectListItem> Banks { get; set; }
        public string RedirectTo { get; set; }

    }
}
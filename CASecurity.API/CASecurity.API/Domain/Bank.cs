using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CASecurity.API.Domain
{
    public class Bank
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
       // [StringLength(4)]
        public string Code { get; set; }
        public string Address { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonEmailId { get; set; }
        public string ContactPersonMobileNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public virtual ICollection<Merchant> Merchants { get; set; }
        public Bank()
        {
            Id = Guid.NewGuid();
        }

    }
  
 
   
}
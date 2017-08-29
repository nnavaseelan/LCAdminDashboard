using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CASecurity.API.Domain
{
    public class BankMerchant
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BankId { get; set; }
        public Guid MerchantId { get; set; }
        public string Code { get; set; }
        public virtual ICollection<App> Apps { get; set; }
        public BankMerchant()
        {
            Id = Guid.NewGuid();
        }
    }

}
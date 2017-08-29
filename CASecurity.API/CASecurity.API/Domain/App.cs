using System;
using System.ComponentModel.DataAnnotations;

namespace CASecurity.API.Domain
{
    public class App
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BankMerchantId { get; set; }
        public string Name { get; set; }
        public string Package { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public string PlatForm { get; set; }
        public string Production { get; set; }
        public string SandBox { get; set; }
        public string JustPayCode { get; set; }

        public DateTime? SDKIssuedDateTime { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public App()
        {
            Id = Guid.NewGuid();
        }
    }
}
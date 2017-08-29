
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CASecurity.API.Domain
{
    public class IssueChallenge
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public string AppId { get; set; }
        public string BankCode { get; set; }
        public string Parameters { get; set; }
        public string ChallengeToken { get; set; }
        public bool TokenIssued { get; set; }
        public DateTime TokenIssuedDateTime { get; set; }
        public bool TokenValidated { get; set; }
        public DateTime? TokenValidatedDateTime { get; set; }

        public IssueChallenge()
        {
            Id = Guid.NewGuid();
        }
    }
}
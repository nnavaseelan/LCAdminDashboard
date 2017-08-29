using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CASecurity.API.Domain
{
    public class ErrorLog
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateOfLog { get; set; }
        public string ErrorDetail { get; set; }
        public string ErrorFrom { get; set; }
        public ErrorLog()
        {
            Id = Guid.NewGuid();
        }
    }
}
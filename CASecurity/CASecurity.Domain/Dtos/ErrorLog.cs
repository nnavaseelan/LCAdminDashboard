using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CASecurity.Domain.Dtos
{
    public class ErrorLog : Dto
    {
        public DateTime DateOfLog { get; set; }
        public string ErrorDetail { get; set; }
        public string ErrorFrom { get; set; }
        public ErrorLog()
        {
            Id = Guid.NewGuid();
        }
    }
}
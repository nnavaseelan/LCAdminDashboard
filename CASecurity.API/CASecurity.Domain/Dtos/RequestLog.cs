using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CASecurity.Domain.Dtos
{
    public class RequestLog : Dto
    {
        public DateTime DateOfRequest { get; set; }
        public string RequestDetail { get; set; }
        public string RequestFrom { get; set; }
        public RequestLog()
        {
            Id = Guid.NewGuid();
        }
    }
}
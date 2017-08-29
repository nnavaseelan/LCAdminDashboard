using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CASecurity.API.Domain
{
    public class RequestLog
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateOfRequest { get; set; }
        public string RequestDetail { get; set; }
        public string RequestFrom { get; set; }
        public RequestLog()
        {
            Id = Guid.NewGuid();
        }
    }
}
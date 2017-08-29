using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CASecurity.API.Domain
{
    public class UserDeviceLog
    {
        [Key]
        public Guid Id { get; set; }
        //[ForeignKey("UserDevice")]
        public virtual UserDevice UserDevice { get; set; }
        public string Status { get; set; }
        public DateTime LogDateTime { get; set; }
        public UserDeviceLog()
        {
            Id = Guid.NewGuid();
        }
    }
}
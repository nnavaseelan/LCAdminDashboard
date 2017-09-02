using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CASecurity.Domain.Dtos
{
    public class UserDeviceLog : Dto
    {
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
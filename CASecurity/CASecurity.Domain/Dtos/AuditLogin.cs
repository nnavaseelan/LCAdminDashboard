﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASecurity.Domain.Dtos
{
    public class AuditLogin : Dto
    {
        public string UserName { get; set; }

        public DateTime LoginDate { get; set; }
    }
}
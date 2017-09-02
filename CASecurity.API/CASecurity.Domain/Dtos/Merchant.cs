﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CASecurity.Domain.Dtos
{
    public class Merchant : Dto
    {        
        public Guid BankId { get; set; }
        
        public string Name { get; set; }
        public string BRC { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Merchant()
        {
            Id = Guid.NewGuid();
        }
    }

}
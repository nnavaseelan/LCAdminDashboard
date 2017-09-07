using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASecurity.Domain.Dtos
{
    public abstract class Dto
    {
        [Key]
        public Guid Id { get; set; }
    }
}

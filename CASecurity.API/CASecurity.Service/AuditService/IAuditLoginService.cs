using CASecurity.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASecurity.Service.AuditService
{
    public interface IAuditLoginService
    {
        void Add(AuditLogin log);
    }
}

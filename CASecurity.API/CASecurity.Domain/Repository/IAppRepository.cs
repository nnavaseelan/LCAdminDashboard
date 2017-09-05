using CASecurity.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASecurity.Domain.Repository
{
    public interface IAppRepository : IBaseRepository<App>
    {
        Task<App> GetApp(string justPayCode);
        void InsertBankMerchant(BankMerchant bm);
        BankMerchant GetBankMerchant(Guid id);
        BankMerchant FindBankMerchant(Guid bankId, Guid merchantId);
    }
}

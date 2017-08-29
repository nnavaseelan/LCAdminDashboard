using CASecurity.API.Models;
using CASecurity.API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CASecurity.API.ViewModelBuilders
{
    public class ViewModelBuilder
    {
        private readonly IBankService _service;
        private readonly IMerchantService _merchantService;
        private readonly IAppService _appService;

        public ViewModelBuilder(IBankService service,IMerchantService merchantService, IAppService appService)
        {
            _service = service;
            _merchantService = merchantService;
            _appService = appService;
        }
        public List<BankModel> GetBanks()
        {
            var model = new List<BankModel>();           
            model = (from b in _service.GetBanks()
                     select new BankModel
                     {
                         Id=b.Id.ToString(),
                         Name = b.Name,
                         Code = b.Code,
                         Address =b.Address,                        
                         ContactPersonName=b.ContactPersonName,
                         ContactPersonEmailId=b.ContactPersonEmailId,
                         ContactPersonMobileNo=b.ContactPersonMobileNo,
                         IsActive=b.IsActive
                     }).ToList();

            return model;
        }
        public List<MerchantModel> GetMerchants()
        {
            var model = new List<MerchantModel>();
            model = (from m in _merchantService.GetMerchants()
                     join b in _service.GetBanks() on m.BankId equals b.Id
                     select new MerchantModel
                     {
                         Id = m.Id.ToString(),
                         Name = m.Name,
                         Code = m.Code,
                         Address = m.Address,
                         Bank = b.Name,
                         BRC = m.BRC,                        
                         IsActive = m.IsActive
                     }).ToList();

            return model;
        }
    }
}
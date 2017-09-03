using CASecurity.Domain.Dtos;
using CASecurity.Service;
using CASecurity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CASecurity.Web.ViewModelBuilders
{
    public class ViewModelBuilder
    {
        private readonly IBankService _bankService;
        private readonly IMerchantService _merchantService;
        private readonly IAppService _appService;

        public ViewModelBuilder(IBankService service, IMerchantService merchantService, IAppService appService)
        {
            _bankService = service;
            _merchantService = merchantService;
            _appService = appService;
        }

        public List<BankModel> GetBanks()
        {
            var model = new List<BankModel>();
            model = (from b in _bankService.Get()
                     select new BankModel
                     {
                         Id = b.Id.ToString(),
                         Name = b.Name,
                         Code = b.Code,
                         Address = b.Address,
                         ContactPersonName = b.ContactPersonName,
                         ContactPersonEmailId = b.ContactPersonEmailId,
                         ContactPersonMobileNo = b.ContactPersonMobileNo,
                         IsActive = b.IsActive
                     }).ToList();

            return model;
        }

        public BankModel GetBank(string id)
        {
            var bId = new Guid();
            var model = new BankModel();

            if (Guid.TryParse(id, out bId))
            {
                var b = _bankService.Get(bId);
                model = new BankModel
                {
                    Id = b.Id.ToString(),
                    Name = b.Name,
                    Code = b.Code,
                    Address = b.Address,
                    ContactPersonName = b.ContactPersonName,
                    ContactPersonEmailId = b.ContactPersonEmailId,
                    ContactPersonMobileNo = b.ContactPersonMobileNo,
                    IsActive = b.IsActive
                };
            }

            return model;
        }

        public void SaveBank(BankModel model)
        {
            var bId = new Guid();
            var isNew = Guid.TryParse(model.Id, out bId);
            
            //TODO: Need to move to common method to map the model builder
            var bank = new Bank
            {
                Name = model.Name,
                Code = model.Code,
                Address = model.Address,
                ContactPersonName = model.ContactPersonName,
                ContactPersonEmailId = model.ContactPersonEmailId,
                ContactPersonMobileNo = model.ContactPersonMobileNo,
                IsActive = true,
                CreatedDateTime = System.DateTime.Now,
                Id = bId,
            };

            _bankService.Save(bank);
        }

        public List<MerchantModel> GetMerchants()
        {
            var model = new List<MerchantModel>();
            model = (from m in _merchantService.GetMerchants()
                     join b in _bankService.Get() on m.BankId equals b.Id
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
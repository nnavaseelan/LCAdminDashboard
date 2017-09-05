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

        #region Bamks
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
        #endregion

        #region Merchant
        public List<MerchantModel> GetMerchants()
        {
            var model = new List<MerchantModel>();
            model = (from m in _merchantService.Get()
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

        public MerchantModel GetMerchant(string id)
        {
            var mId = new Guid();
            var model = new MerchantModel();

            if (Guid.TryParse(id, out mId))
            {
                var m = _merchantService.Get(mId);
                model = new MerchantModel
                {
                    Id = m.Id.ToString(),
                    Name = m.Name,
                    Code = m.Code,
                    Address = m.Address,
                    BRC = m.BRC,
                    IsActive = m.IsActive
                };

                if (m != null && m.BankId != null)
                {
                    var b = _bankService.Get(m.BankId);
                    model.Bank = b.Name;
                }
            }

            return model;
        }

        public void SaveMerchant(MerchantModel model)
        {
            var mId = new Guid();
            var isNotNew = Guid.TryParse(model.Id, out mId);

            var merchant = new Merchant
            {
                Name = model.Name,
                Code = model.Code,
                Address = model.Address,
                BankId = new Guid(model.BankId),
                BRC = model.BRC,
                IsActive = true,
                CreatedDateTime = System.DateTime.Now,
                Id = mId,
            };

            _merchantService.Save(merchant);
        }
        #endregion

        #region
        public void SaveApp(AppModel model)
        {
            model.BMCode = model.Code;
            var isExist = _appService.FindBankMerchant(new Guid(model.BankId), new Guid(model.MerchantId));
            if (isExist == null)
            {
                var bMerchant = new BankMerchant
                {
                    Code = model.BMCode,
                    BankId = new Guid(model.BankId),
                    MerchantId = new Guid(model.MerchantId),
                };
                _appService.InsertBankMerchant(bMerchant);
                model.BankMerchantId = bMerchant.Id.ToString();
            }

            if (string.IsNullOrEmpty(model.BankMerchantId))
                model.BankMerchantId = isExist.Id.ToString();

            //get bank
            var bank = _bankService.Get(new Guid(model.BankId));
            var bankCode = bank.Code;

            //get merchant
            var merchant = _merchantService.Get(new Guid(model.MerchantId));
            var merchantCode = merchant.Code;
            var app = new App
            {
                Code = model.Code,
                BankMerchantId = new Guid(model.BankMerchantId),
                Address = string.Empty,
                Name = model.Name,
                Package = model.Package,
                PlatForm = model.PlatForm,
                Production = string.Empty,
                SandBox = string.Empty,
                IsActive = true,
                CreatedDateTime = DateTime.Now,
                JustPayCode = string.Format("{0}_{1}_{2}", bankCode, merchantCode, model.Code),
            };

            _appService.Save(app);
        }

        public AppModel GetApp(string id)
        {
            var aId = new Guid();
            var isNotNew = Guid.TryParse(id, out aId);
            var model = new AppModel();

            var a = _appService.Get(aId);

            if(a != null)
            {
                model = new AppModel()
                {
                    Address = a.Address,
                    Code = a.Code,
                    BankMerchantId = a.BankMerchantId.ToString(),
                    Name = a.Name,
                    Package = a.Package,
                    PlatForm = a.PlatForm,
                    Production = a.Production,
                    SandBox = a.SandBox,
                    JustPayCode = a.JustPayCode,
                    Id = a.Id.ToString(),
                };
            }
            return model;
        }

        public ApplistModel GetAppList(string bankId, string merchantId)
        {
            var model = new ApplistModel
            {
                Apps = new List<AppModel>(),
                BankId = bankId,
                MerchantId = merchantId,
            };

            var isExist = _appService.FindBankMerchant(new Guid(bankId), new Guid(merchantId));
            if (isExist != null)
            {
                model.Apps = (from a in isExist.Apps
                              select new AppModel
                              {
                                  Id = a.Id.ToString(),
                                  Address = a.Address,
                                  Code = a.Code,
                                  Name = a.Name,
                                  Package = a.Package,
                                  PlatForm = a.PlatForm,
                                  Production = a.Production,
                                  SandBox = a.SandBox,
                                  JustPayCode = a.JustPayCode,
                                  SDKIssuedDateTime = a.SDKIssuedDateTime
                              }).ToList();

            }
            return model;
        }
        #endregion
    }
}
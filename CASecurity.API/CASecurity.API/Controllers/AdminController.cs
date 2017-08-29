using CASecurity.API.Models;
using CASecurity.API.Service;
using Castle.Core.Logging;
using System.Collections.Generic;
using CASecurity.API.ViewModelBuilders;
using System.Web.Mvc;
using CASecurity.API.Domain;
using System.Linq;
using System;
using System.IO;

namespace CASecurity.API.Controllers
{
    public class AdminController : Controller
    {
        private ILogger _logger = NullLogger.Instance;
        private readonly IBankService _service;
        private readonly IMerchantService _merchantService;
        private readonly IAppService _appService;
        private readonly ViewModelBuilder _viewModelBuilder;

        public AdminController()
        {
            _service = new BankService();
            _merchantService = new MerchantService();
            _appService = new AppService();
            _viewModelBuilder = new ViewModelBuilder(_service, _merchantService, _appService);
        }

        public ActionResult Bank()
        {
            var model = new List<BankModel>();
            try
            {
                model = _viewModelBuilder.GetBanks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Bank(BankModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bank = new Bank
                    {
                        Name = model.Name,
                        Code = model.Code,
                        Address = model.Address,
                        ContactPersonName = model.ContactPersonName,
                        ContactPersonEmailId = model.ContactPersonEmailId,
                        ContactPersonMobileNo = model.ContactPersonMobileNo,
                        IsActive = true,
                        CreatedDateTime = System.DateTime.Now
                    };

                    _service.InsertBank(bank);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
         
            return RedirectToAction("Bank");
        }
        [HttpPost]
        public ActionResult UpdateBank(BankModel model)
        {
            if (ModelState.IsValid)
            {
                var bank = new Bank
                {
                    Name = model.Name,
                    Code = model.Code,
                    Address = model.Address,
                    ContactPersonName = model.ContactPersonName,
                    ContactPersonEmailId = model.ContactPersonEmailId,
                    ContactPersonMobileNo = model.ContactPersonMobileNo,
                    IsActive = true,
                    CreatedDateTime = System.DateTime.Now
                };

                _service.InsertBank(bank);
            }

            return RedirectToAction("Bank");
        }

        public ActionResult Merchant()
        {
            var model = new List<MerchantModel>();
            try
            {
                
                var list = (from l in _service.GetBanks()
                            where l.IsActive && l.Name != null
                            select new SelectListItem
                            {
                                Text = l.Name,
                                Value = l.Id.ToString()
                            });

                model = _viewModelBuilder.GetMerchants();
                ViewBag.Banks = list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
            return View(model);
        }

        [HttpPost]
        public ActionResult Merchant(MerchantModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var merchant = new Merchant
                    {
                        Name = model.Name,
                        Code = model.Code,
                        Address = model.Address,
                        BankId = new Guid(model.BankId),
                        BRC = model.BRC,
                        IsActive = true,
                        CreatedDateTime = System.DateTime.Now
                    };

                    _merchantService.InsertMerchant(merchant);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return RedirectToAction(model.RedirectTo);
        }
        public ActionResult App(string id)
        {
            var model = new BankMerchantModel
            {
                Apps = new List<AppModel>(),
                Banks = new List<SelectListItem>(),
                Merchants = new List<SelectListItem> (),
                Code = string.Empty
            };
            try
            {
                var banks = (from l in _service.GetBanks()
                             where l.IsActive && l.Name != null
                             select new SelectListItem
                             {
                                 Text = l.Name,
                                 Value = l.Id.ToString()
                             }).ToList();

                var merchants = (from l in _merchantService.GetMerchants()
                                 where l.IsActive && l.Name != null
                                 select new SelectListItem
                                 {
                                     Text = l.Name,
                                     Value = l.Id.ToString()
                                 }).ToList();




                ViewBag.Banks = banks;
                ViewBag.Merchants = merchants;

                model = new BankMerchantModel
                {
                    Apps = new List<AppModel>(),
                    Banks = banks,
                    Merchants = merchants,
                    Code = string.Empty
                };

                if (!string.IsNullOrEmpty(id))
                {
                    var bankMerchant = _appService.GetBankMerchant(new Guid(id));
                    if (bankMerchant != null)
                    {
                        model.BankId = bankMerchant.BankId.ToString();
                        model.MerchantId = bankMerchant.MerchantId.ToString();
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpPost]
        public ActionResult App(AppModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.BMCode = model.Code;
                    var isExist = _appService.FindBankMerchant(new Guid(model.BankId), new Guid(model.MerchantId));
                    if (isExist == null)
                    {
                        var merchant = new BankMerchant
                        {
                            Code = model.BMCode,
                            BankId = new Guid(model.BankId),
                            MerchantId = new Guid(model.MerchantId),
                        };
                        _appService.InsertBankMerchant(merchant);
                        model.BankMerchantId = merchant.Id.ToString();
                    }

                    if (string.IsNullOrEmpty(model.BankMerchantId))
                        model.BankMerchantId = isExist.Id.ToString();

                    //get bank
                    var bankCode = _service.GetBank(new Guid(model.BankId)).Code;
                    //get merchant
                    var merchantCode = _merchantService.GetMerchant(new Guid(model.MerchantId)).Code;

                    var app = new App
                    {
                        Code = model.Code,
                        BankMerchantId = new Guid(model.BankMerchantId),
                        Address =string.Empty,
                        Name = model.Name,
                        Package = model.Package,
                        PlatForm = model.PlatForm,
                        Production = string.Empty,
                        SandBox =string.Empty,
                        IsActive = true,
                        CreatedDateTime = DateTime.Now,
                        JustPayCode = bankCode + "_" + merchantCode + "_" + model.Code,
                    };

                    _appService.InsertApp(app);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return RedirectToAction("App");
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AppList(string bankId, string merchantId)
        {
            var model = new ApplistModel
            {
                Apps = new List<AppModel>(),
                BankId = bankId,
                MerchantId = merchantId,
            };

            try
            {
                var isExist = _appService.FindBankMerchant(new Guid(bankId), new Guid(merchantId));
                if (isExist != null)
                {
                    model.Apps = (from a in isExist.Apps
                                  select new AppModel
                                  {
                                      Id=a.Id.ToString(),
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
       
            return View(model);
        }

        public ActionResult CheckBankCode(string code)
        {
            return Json("true");
        }
        public ActionResult CheckMerchantCode(string bankId,string code)
        {
            return Json("true");
        }
        public ActionResult CheckAppCode(string bankId, string merchnatId,string code)
        {
            return Json("true");
        }

        public ActionResult Json(string appId)
        {
            return Json("true");
        }
        private string CreateJson(string dataJson)
        {
            string appPath = Request.PhysicalApplicationPath;
            string filePath = appPath + "/JsonFiles";

            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = filePath + "/package-" + DateTime.Now.Ticks.ToString() + ".json";   //Text File Name
                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.File.Create(filePath).Dispose();
                }
                using (StreamWriter sw = System.IO.File.AppendText(filePath))
                {
                    sw.WriteLine(dataJson);
                    sw.Flush();
                    sw.Close();
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
            return filePath;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CASecurity.API.Models
{
    public class BankMerchantModel: ApplistModel
    {
        public string Id { get; set; }       
        public string Code { get; set; }
        public List<SelectListItem> Banks { get; set; }
        public List<SelectListItem> Merchants { get; set; }
      
    }
    public class ApplistModel
    {
        public string BankMerchantId { get; set; }
        public string BankId { get; set; }
        public string MerchantId { get; set; }
        public List<AppModel> Apps { get; set; }
    }
}
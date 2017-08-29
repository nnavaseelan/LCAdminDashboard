using CASecurity.API.Domain;
using CASecurity.API.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CASecurity.API.Service
{
    public interface IAppService
    {
        void InsertBankMerchant(BankMerchant bm);
        BankMerchant GetBankMerchant(Guid id);
        BankMerchant FindBankMerchant(Guid bankId,Guid merchantId);
        void InsertApp(App app);
        App GetApp(Guid id);
        void UpdateApp(App app);
        void DeleteApp(Guid id);
        List<App> GetApps();
        Task<App> GetApp(string justPayCode);
    }

    public class AppService : IAppService
    {
        public void DeleteApp(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var app = new App { Id = id };
                db.Apps.Attach(app);
                db.Entry(app).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public App GetApp(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Apps.FirstOrDefault(q => q.Id == id);
            }
        }

        public List<App> GetApps()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Apps.ToList();
            }
        }

        public BankMerchant GetBankMerchant(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.BankMerchants.Include(a=>a.Apps).FirstOrDefault(q => q.Id == id);
            }
        }

        public void InsertBankMerchant(BankMerchant bm)
        {
            using (var db = new ApplicationDbContext())
            {
                db.BankMerchants.Add(bm);
                db.SaveChanges();
            }
        }

        public void InsertApp(App app)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Apps.Add(app);
                db.SaveChanges();
            }
        }

        public void UpdateApp(App app)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Apps.Attach(app);
                db.Entry(app).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public BankMerchant FindBankMerchant(Guid bankId, Guid merchantId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.BankMerchants.Include(a => a.Apps).FirstOrDefault(q => q.BankId == bankId && q.MerchantId== merchantId);
            }
        }

        public async Task <App> GetApp(string justPayCode)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Apps.FirstOrDefaultAsync(q => q.JustPayCode == justPayCode);
            }
        }
    }
}
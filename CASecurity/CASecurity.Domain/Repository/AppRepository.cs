using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CASecurity.Domain.Dtos;
using CASecurity.Domain.Migrations;
using System.Data.Entity;

namespace CASecurity.Domain.Repository
{
    public class AppRepository : IAppRepository
    {
        public void Delete(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var app = new App { Id = id };
                db.Apps.Attach(app);
                db.Entry(app).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public BankMerchant FindBankMerchant(Guid bankId, Guid merchantId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.BankMerchants.Include(a => a.Apps).FirstOrDefault(q => q.BankId == bankId && q.MerchantId == merchantId);
            }
        }

        public App Get(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Apps.FirstOrDefault(q => q.Id == id);
            }
        }

        public List<App> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Apps.ToList();
            }
        }

        public async Task<App> GetApp(string justPayCode)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Apps.FirstOrDefaultAsync(q => q.JustPayCode == justPayCode);
            }
        }

        public BankMerchant GetBankMerchant(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.BankMerchants.Include(a => a.Apps).FirstOrDefault(q => q.Id == id);
            }
        }

        public void Insert(App entity)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Apps.Add(entity);
                db.SaveChanges();
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

        public void Update(App entity)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Apps.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}

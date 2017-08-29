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
    public interface IMerchantService
    {
        void InsertMerchant(Merchant merchant);
        Merchant GetMerchant(Guid Id);
        void UpdateMerchant(Merchant merchant);
        void DeleteMerchant(Guid id);
        List<Merchant> GetMerchants();
    }
    public class MerchantService : IMerchantService
    {
        public void DeleteMerchant(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var merchant = new Merchant { Id = id };
                db.Merchants.Attach(merchant);
                db.Entry(merchant).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Merchant GetMerchant(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return  db.Merchants.FirstOrDefault(q => q.Id == id);
            }
        }

        public List<Merchant> GetMerchants()
        {
            using (var db = new ApplicationDbContext())
            {
                return  db.Merchants.Where(q => q.IsActive).ToList();
            }
        }

        public  void InsertMerchant(Merchant merchant)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Merchants.Add(merchant);
                db.SaveChanges();
            }
        }

        public void UpdateMerchant(Merchant merchant)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Merchants.Attach(merchant);
                db.Entry(merchant).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
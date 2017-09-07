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
    public class MerchantRepository : IMerchantRepository
    {
        public void Delete(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var merchant = new Merchant { Id = id };
                db.Merchants.Attach(merchant);
                db.Entry(merchant).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Merchant Get(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Merchants.FirstOrDefault(q => q.Id == id);
            }
        }

        public List<Merchant> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Merchants.Where(q => q.IsActive).ToList();
            }
        }

        public void Insert(Merchant entity)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Merchants.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Merchant entity)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Merchants.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}

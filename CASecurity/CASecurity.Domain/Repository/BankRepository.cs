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
    public class BankRepository : IBankRepository
    {
        public void Delete(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var bank = new Bank { Id = id };
                db.Banks.Attach(bank);
                db.Entry(bank).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Bank Get(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Banks.FirstOrDefault(q => q.Id == id);

            }
        }

        public List<Bank> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Banks.Where(q => q.IsActive).ToList();

            }
        }

        public void Insert(Bank entity)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Banks.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Bank entity)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Banks.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}

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
    public interface IBankService
    {
        void InsertBank(Bank bank);
        Bank GetBank(Guid id);
        void UpdateBank(Bank bank);
        void DeleteBank(Guid id);
        List<Bank> GetBanks();

    }
    public class BankService : IBankService
    {
        public void DeleteBank(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var bank = new Bank { Id = id };
                db.Banks.Attach(bank);
                db.Entry(bank).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Bank GetBank(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Banks.FirstOrDefault(q => q.Id == id);

            }
        }

        public List<Bank> GetBanks()
        {
            using (var db = new ApplicationDbContext())
            {
                return  db.Banks.Where(q => q.IsActive).ToList();

            }
        }

        public void InsertBank(Bank bank)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Banks.Add(bank);
                db.SaveChanges();
            }
        }

        public void UpdateBank(Bank bank)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Banks.Attach(bank);
                db.Entry(bank).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
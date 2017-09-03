using CASecurity.Domain.Dtos;
using CASecurity.Domain.Migrations;
using CASecurity.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CASecurity.Service
{
    public interface IBankService
    {
        void Save(Bank bank);
        Bank Get(Guid id);
        void Delete(Guid id);
        List<Bank> Get();

    }
    public class BankService : IBankService
    {
        private readonly IBankRepository repository;

        public BankService()
        {
            repository = new BankRepository();
        }


        public void Delete(Guid id)
        {
            repository.Delete(id);
        }

        public Bank Get(Guid id)
        {
            return repository.Get(id);
        }

        public List<Bank> Get()
        {
            return repository.Get();
        }

        public void Save(Bank bank)
        {
            if (bank.Id == new Guid())
            {
                bank.Id = Guid.NewGuid();
                repository.Insert(bank);
            }
            else
            {
                repository.Update(bank);
            }
        }
    }
}
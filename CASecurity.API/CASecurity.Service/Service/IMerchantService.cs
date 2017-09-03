
using CASecurity.Domain.Dtos;
using CASecurity.Domain.Migrations;
using CASecurity.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace CASecurity.Service
{
    public interface IMerchantService
    {
        void Save(Merchant merchant);
        Merchant Get(Guid Id);
        void Delete(Guid id);
        List<Merchant> Get();
    }

    public class MerchantService : IMerchantService
    {
        private readonly MerchantRepository repository;

        public MerchantService()
        {
            repository = new MerchantRepository();
        }

        public void Delete(Guid id)
        {
            repository.Delete(id);
        }

        public Merchant Get(Guid id)
        {
            return repository.Get(id);
        }

        public List<Merchant> Get()
        {
            return repository.Get();
        }

        public void Save(Merchant merchant)
        {
            if (merchant.Id == new Guid())
            {
                merchant.Id = Guid.NewGuid();
                repository.Insert(merchant);
            }
            else
            {
                repository.Update(merchant);
            }
        }
    }
}
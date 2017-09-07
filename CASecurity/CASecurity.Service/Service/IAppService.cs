using CASecurity.Domain.Dtos;
using CASecurity.Domain.Migrations;
using CASecurity.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CASecurity.Service
{
    public interface IAppService
    {
        void InsertBankMerchant(BankMerchant bm);
        BankMerchant GetBankMerchant(Guid id);
        BankMerchant FindBankMerchant(Guid bankId, Guid merchantId);
        void Save(App app);
        App Get(Guid id);
        void Delete(Guid id);
        List<App> Get();
        Task<App> GetApp(string justPayCode);
    }

    public class AppService : IAppService
    {
        private readonly IAppRepository repository;

        public AppService()
        {
            repository = new AppRepository();
        }

        public void Delete(Guid id)
        {
            repository.Delete(id);
        }

        public App Get(Guid id)
        {
            return repository.Get(id);
        }

        public List<App> Get()
        {
            return repository.Get();
        }

        public BankMerchant GetBankMerchant(Guid id)
        {
            return repository.GetBankMerchant(id);
        }

        public void InsertBankMerchant(BankMerchant bm)
        {
            repository.InsertBankMerchant(bm);
        }

        public void Save(App app)
        {
            if (app.Id == new Guid())
            {
                app.Id = Guid.NewGuid();
                repository.Insert(app);
            }
            else
            {
                repository.Update(app);
            }
        }

        public void SaveFile(string id, string filePath)
        {
            Guid aId = new Guid();
            bool isValid = Guid.TryParse(id, out aId);

            if (isValid)
            {

            }
        }

        public BankMerchant FindBankMerchant(Guid bankId, Guid merchantId)
        {
            return repository.FindBankMerchant(bankId, merchantId);
        }

        public async Task<App> GetApp(string justPayCode)
        {
            return await repository.GetApp(justPayCode);
        }
    }
}
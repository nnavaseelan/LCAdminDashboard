using CASecurity.API.Domain;
using CASecurity.API.Migrations;
using CASecurity.API.Models;
using CASecurity.API.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CASecurity.API.Service
{
    public interface ICAService: IDisposable
    {
        void InsertChallengeAsync(UserDevice challenge);
        Task<UserDevice> GetChallenge(string merchantId, string bankId, string AppId);
        Task<UserDevice> GetChallenge(string deviceId, string AppId, string bankId, string merchantId);

        Task UpdateChallengeAsync(UserDevice challenge);
        Task DeleteChallengeAsync(Guid id);

        List<UserDevice> GetAll();
        void InsertChallenge(UserDevice challenge);
        Task<UserDevice> GetChallenge(string certChallenge);

        void InsertChallengeLogAsync(UserDeviceLog log);
        Task<UserDevice> CheckChallenge(ApiModelNew model);

        Task<App> GetPackageName(string justPayCode);

    }
    public class CAService: ICAService
    {
        public async void InsertChallengeAsync(UserDevice challenge)
        {
            using(var db = new ApplicationDbContext())
            {
                db.UserDevices.Add(challenge);
                await db.SaveChangesAsync();
            }           
        }

        
        public async Task<UserDevice> GetChallenge(string merchantId, string bankId, string AppId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.UserDevices.FirstOrDefaultAsync(q => q.MerchantId == merchantId & q.AppId == AppId && q.BankId == bankId);
                
            }
        }

        public async Task<UserDevice> GetChallenge(string deviceId, string AppId, string bankId, string merchantId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.UserDevices.FirstOrDefaultAsync(q => q.DeviceId == deviceId & q.AppId == AppId && q.BankId == bankId && q.MerchantId== merchantId);
            }
        }

        public async Task UpdateChallengeAsync(UserDevice challenge)
        {
            using (var db = new ApplicationDbContext())
            {
                db.UserDevices.Attach(challenge);
                db.Entry(challenge).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteChallengeAsync(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var challenge = new UserDevice { Id = id };
                db.UserDevices.Attach(challenge);
                db.Entry(challenge).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
        }        

        public void Dispose()
        {
            this.Dispose();
        }

        public List<UserDevice> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return  db.UserDevices.OrderByDescending(o=>o.CreatedDate).ToList();
            }
        }
             

        public void InsertChallenge(UserDevice challenge)
        {
            using (var db = new ApplicationDbContext())
            {
                db.UserDevices.Add(challenge);
                db.SaveChanges();
            }
        }

        public async Task<UserDevice> GetChallenge(string certChallenge)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.UserDevices.FirstOrDefaultAsync(q => q.CertificateChallenge == certChallenge);
            }
        }

        public async void InsertChallengeLogAsync(UserDeviceLog log)
        {
            using (var db = new ApplicationDbContext())
            {
                db.UserDeviceLogs.Add(log);
                await db.SaveChangesAsync();
            }
        }

        public async Task<UserDevice> CheckChallenge(ApiModelNew model)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.UserDevices.FirstOrDefaultAsync(q => q.DeviceId == model.device_id && q.JustPayCode == model.justpay_code
                &&q.UserName==model.user_name&&q.UserNic==model.user_id&&q.EmailId==model.user_email&&q.UserPassport==model.user_id&&q.Platform==model.platform                
                );
            }
        }

        public async Task<App> GetPackageName(string justPayCode)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Apps.FirstOrDefaultAsync(q => q.JustPayCode == justPayCode);
            }
        }
    }

}
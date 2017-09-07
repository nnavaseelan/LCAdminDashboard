using CASecurity.Domain.Dtos;
using System.Data.Entity;

namespace CASecurity.Domain.Migrations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<IssueChallenge> Issuechallenges { get; set; }
        public DbSet<ErrorLog> Errorlogs { get; set; }
        public DbSet<UserDevice> UserDevices { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<BankMerchant> BankMerchants { get; set; }
        public DbSet<App> Apps { get; set; }
        public DbSet<UserDeviceLog> UserDeviceLogs { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuditLogin> AuditLogins { get; set; }
    }
}
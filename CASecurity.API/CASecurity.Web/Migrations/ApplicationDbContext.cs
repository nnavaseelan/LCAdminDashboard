using CASecurity.API.Domain;
using CASecurity.API.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CASecurity.API.Migrations
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
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

    }
}
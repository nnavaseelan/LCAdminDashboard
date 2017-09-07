namespace CASecurity.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialsetforMySql : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apps",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BankMerchantId = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Package = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        Code = c.String(unicode: false),
                        PlatForm = c.String(unicode: false),
                        Production = c.String(unicode: false),
                        SandBox = c.String(unicode: false),
                        JustPayCode = c.String(unicode: false),
                        SDKIssuedDateTime = c.DateTime(precision: 0),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankMerchants", t => t.BankMerchantId, cascadeDelete: true)
                .Index(t => t.BankMerchantId);
            
            CreateTable(
                "dbo.BankMerchants",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BankId = c.Guid(nullable: false),
                        MerchantId = c.Guid(nullable: false),
                        Code = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Code = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        ContactPersonName = c.String(unicode: false),
                        ContactPersonEmailId = c.String(unicode: false),
                        ContactPersonMobileNo = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Merchants",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BankId = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        BRC = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        Code = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateOfLog = c.DateTime(nullable: false, precision: 0),
                        ErrorDetail = c.String(unicode: false),
                        ErrorFrom = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IssueChallenges",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeviceId = c.String(unicode: false),
                        AppId = c.String(unicode: false),
                        BankCode = c.String(unicode: false),
                        Parameters = c.String(unicode: false),
                        ChallengeToken = c.String(unicode: false),
                        TokenIssued = c.Boolean(nullable: false),
                        TokenIssuedDateTime = c.DateTime(nullable: false, precision: 0),
                        TokenValidated = c.Boolean(nullable: false),
                        TokenValidatedDateTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateOfRequest = c.DateTime(nullable: false, precision: 0),
                        RequestDetail = c.String(unicode: false),
                        RequestFrom = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserDeviceLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.String(unicode: false),
                        LogDateTime = c.DateTime(nullable: false, precision: 0),
                        UserDevice_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDevices", t => t.UserDevice_Id)
                .Index(t => t.UserDevice_Id);
            
            CreateTable(
                "dbo.UserDevices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeviceId = c.String(nullable: false, unicode: false),
                        BankId = c.String(nullable: false, unicode: false),
                        MerchantId = c.String(nullable: false, unicode: false),
                        Platform = c.String(nullable: false, unicode: false),
                        UserName = c.String(nullable: false, unicode: false),
                        AppId = c.String(unicode: false),
                        UserNic = c.String(nullable: false, unicode: false),
                        UserPassport = c.String(nullable: false, unicode: false),
                        JustPayCode = c.String(nullable: false, unicode: false),
                        EmailId = c.String(nullable: false, unicode: false),
                        MobileNo = c.String(nullable: false, unicode: false),
                        CertificateChallenge = c.String(unicode: false),
                        Status = c.String(unicode: false),
                        IssuedDateTime = c.DateTime(precision: 0),
                        VaidityPriod = c.DateTime(nullable: false, precision: 0),
                        ValidatedDateTime = c.DateTime(precision: 0),
                        IsActive = c.Boolean(nullable: false),
                        NoOfAttempt = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserDeviceLogs", "UserDevice_Id", "dbo.UserDevices");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Merchants", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Apps", "BankMerchantId", "dbo.BankMerchants");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserDeviceLogs", new[] { "UserDevice_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Merchants", new[] { "BankId" });
            DropIndex("dbo.Apps", new[] { "BankMerchantId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserDevices");
            DropTable("dbo.UserDeviceLogs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RequestLogs");
            DropTable("dbo.IssueChallenges");
            DropTable("dbo.ErrorLogs");
            DropTable("dbo.Merchants");
            DropTable("dbo.Banks");
            DropTable("dbo.BankMerchants");
            DropTable("dbo.Apps");
        }
    }
}

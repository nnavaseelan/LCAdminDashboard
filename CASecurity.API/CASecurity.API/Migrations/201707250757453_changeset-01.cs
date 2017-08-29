namespace CASecurity.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeset01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apps",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Package = c.String(),
                        Address = c.String(),
                        Code = c.String(),
                        PlatForm = c.Int(nullable: false),
                        Production = c.String(),
                        SandBox = c.String(),
                        SDKIssuedDateTime = c.DateTime(),
                        BankMerchant_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankMerchants", t => t.BankMerchant_Id)
                .Index(t => t.BankMerchant_Id);
            
            CreateTable(
                "dbo.BankMerchants",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Bank_Id = c.Guid(),
                        Merchant_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.Bank_Id)
                .ForeignKey("dbo.Merchants", t => t.Merchant_Id)
                .Index(t => t.Bank_Id)
                .Index(t => t.Merchant_Id);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Address = c.String(),
                        ContactPersonName = c.String(),
                        ContactPersonEmailId = c.String(),
                        ContactPersonMobileNo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Merchants",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BankId = c.Guid(nullable: false),
                        Name = c.String(),
                        BRC = c.String(),
                        Address = c.String(),
                        Code = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateOfLog = c.DateTime(nullable: false),
                        ErrorDetail = c.String(),
                        ErrorFrom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IssueChallenges",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeviceId = c.String(),
                        AppId = c.String(),
                        BankCode = c.String(),
                        Parameters = c.String(),
                        ChallengeToken = c.String(),
                        TokenIssued = c.Boolean(nullable: false),
                        TokenIssuedDateTime = c.DateTime(nullable: false),
                        TokenValidated = c.Boolean(nullable: false),
                        TokenValidatedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateOfRequest = c.DateTime(nullable: false),
                        RequestDetail = c.String(),
                        RequestFrom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
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
                        Status = c.String(),
                        LogDateTime = c.DateTime(nullable: false),
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
                        DeviceId = c.String(nullable: false),
                        JustPayCode = c.String(nullable: false),
                        UserId = c.String(nullable: false),
                        EmailId = c.String(nullable: false),
                        MobileNo = c.String(nullable: false),
                        Challenge = c.String(),
                        Status = c.String(),
                        IssuedDateTime = c.DateTime(nullable: false),
                        VaidityPriod = c.DateTime(nullable: false),
                        ValidatedDateTime = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        NoOfAttempt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
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
            DropForeignKey("dbo.Apps", "BankMerchant_Id", "dbo.BankMerchants");
            DropForeignKey("dbo.BankMerchants", "Merchant_Id", "dbo.Merchants");
            DropForeignKey("dbo.BankMerchants", "Bank_Id", "dbo.Banks");
            DropForeignKey("dbo.Merchants", "BankId", "dbo.Banks");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserDeviceLogs", new[] { "UserDevice_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Merchants", new[] { "BankId" });
            DropIndex("dbo.BankMerchants", new[] { "Merchant_Id" });
            DropIndex("dbo.BankMerchants", new[] { "Bank_Id" });
            DropIndex("dbo.Apps", new[] { "BankMerchant_Id" });
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

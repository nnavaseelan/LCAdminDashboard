namespace CASecurity.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chanageset05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDevices", "BankId", c => c.String(nullable: false));
            AddColumn("dbo.UserDevices", "MerchantId", c => c.String(nullable: false));
            AddColumn("dbo.UserDevices", "Platform", c => c.String(nullable: false));
            AddColumn("dbo.UserDevices", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.UserDevices", "AppId", c => c.String());
            AddColumn("dbo.UserDevices", "UserNic", c => c.String(nullable: false));
            AddColumn("dbo.UserDevices", "UserPassport", c => c.String(nullable: false));
            AddColumn("dbo.UserDevices", "CertificateChallenge", c => c.String());
            AddColumn("dbo.UserDevices", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserDevices", "IssuedDateTime", c => c.DateTime());
            DropColumn("dbo.UserDevices", "UserId");
            DropColumn("dbo.UserDevices", "Challenge");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDevices", "Challenge", c => c.String());
            AddColumn("dbo.UserDevices", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.UserDevices", "IssuedDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.UserDevices", "CreatedDate");
            DropColumn("dbo.UserDevices", "CertificateChallenge");
            DropColumn("dbo.UserDevices", "UserPassport");
            DropColumn("dbo.UserDevices", "UserNic");
            DropColumn("dbo.UserDevices", "AppId");
            DropColumn("dbo.UserDevices", "UserName");
            DropColumn("dbo.UserDevices", "Platform");
            DropColumn("dbo.UserDevices", "MerchantId");
            DropColumn("dbo.UserDevices", "BankId");
        }
    }
}

namespace CASecurity.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeset02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BankMerchants", "Bank_Id", "dbo.Banks");
            DropForeignKey("dbo.BankMerchants", "Merchant_Id", "dbo.Merchants");
            DropForeignKey("dbo.Apps", "BankMerchant_Id", "dbo.BankMerchants");
            DropIndex("dbo.Apps", new[] { "BankMerchant_Id" });
            DropIndex("dbo.BankMerchants", new[] { "Bank_Id" });
            DropIndex("dbo.BankMerchants", new[] { "Merchant_Id" });
            RenameColumn(table: "dbo.Apps", name: "BankMerchant_Id", newName: "BankMerchantId");
            AddColumn("dbo.BankMerchants", "BankId", c => c.Guid(nullable: false));
            AddColumn("dbo.BankMerchants", "MerchantId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Apps", "BankMerchantId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Apps", "BankMerchantId");
            AddForeignKey("dbo.Apps", "BankMerchantId", "dbo.BankMerchants", "Id", cascadeDelete: true);
            DropColumn("dbo.BankMerchants", "Bank_Id");
            DropColumn("dbo.BankMerchants", "Merchant_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankMerchants", "Merchant_Id", c => c.Guid());
            AddColumn("dbo.BankMerchants", "Bank_Id", c => c.Guid());
            DropForeignKey("dbo.Apps", "BankMerchantId", "dbo.BankMerchants");
            DropIndex("dbo.Apps", new[] { "BankMerchantId" });
            AlterColumn("dbo.Apps", "BankMerchantId", c => c.Guid());
            DropColumn("dbo.BankMerchants", "MerchantId");
            DropColumn("dbo.BankMerchants", "BankId");
            RenameColumn(table: "dbo.Apps", name: "BankMerchantId", newName: "BankMerchant_Id");
            CreateIndex("dbo.BankMerchants", "Merchant_Id");
            CreateIndex("dbo.BankMerchants", "Bank_Id");
            CreateIndex("dbo.Apps", "BankMerchant_Id");
            AddForeignKey("dbo.Apps", "BankMerchant_Id", "dbo.BankMerchants", "Id");
            AddForeignKey("dbo.BankMerchants", "Merchant_Id", "dbo.Merchants", "Id");
            AddForeignKey("dbo.BankMerchants", "Bank_Id", "dbo.Banks", "Id");
        }
    }
}

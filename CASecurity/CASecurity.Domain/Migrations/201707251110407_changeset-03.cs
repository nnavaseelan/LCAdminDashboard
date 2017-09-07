namespace CASecurity.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeset03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apps", "JustPayCode", c => c.String());
            AddColumn("dbo.Apps", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Apps", "CreatedDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apps", "CreatedDateTime");
            DropColumn("dbo.Apps", "IsActive");
            DropColumn("dbo.Apps", "JustPayCode");
        }
    }
}

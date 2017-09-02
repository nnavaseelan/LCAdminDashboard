namespace CASecurity.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeset04 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Apps", "PlatForm", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Apps", "PlatForm", c => c.Int(nullable: false));
        }
    }
}

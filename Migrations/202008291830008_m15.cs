namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCart", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCart", "UserId");
        }
    }
}

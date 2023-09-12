namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCart", "FarmerEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCart", "FarmerEmail");
        }
    }
}

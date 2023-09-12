namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "PFarmerEmail", c => c.String());
            DropColumn("dbo.ProductDetails", "PFarmerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductDetails", "PFarmerId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductDetails", "PFarmerEmail");
        }
    }
}

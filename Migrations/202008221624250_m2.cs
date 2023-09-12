namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductCategory = c.Int(nullable: false),
                        ItemName = c.String(nullable: false),
                        QuantityInStock = c.Int(nullable: false),
                        RatePerKg = c.Double(nullable: false),
                        DateOfHarvest = c.DateTime(nullable: false),
                        PFarmerId = c.Int(nullable: false),
                        FreshRating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductDetails");
        }
    }
}

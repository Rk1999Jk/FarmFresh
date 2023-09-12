namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCart",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ItemName = c.String(),
                        Quantity = c.Int(nullable: false),
                        RatePerKg = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CartId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserCart");
        }
    }
}

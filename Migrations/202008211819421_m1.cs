namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FarmerDetails",
                c => new
                    {
                        FarmerId = c.Int(nullable: false, identity: true),
                        FarmersName = c.String(nullable: false),
                        FarmersMobileNumber = c.Long(nullable: false),
                        FarmsAddress = c.String(),
                        FarmersEmail = c.String(nullable: false),
                        FPassword = c.String(nullable: false, maxLength: 100),
                        FConfirmPassword = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.FarmerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FarmerDetails");
        }
    }
}

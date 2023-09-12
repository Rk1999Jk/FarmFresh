namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FarmerLogin",
                c => new
                    {
                        FarmersLoginEmail = c.String(nullable: false, maxLength: 128),
                        FarmersLoginPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FarmersLoginEmail);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FarmerLogin");
        }
    }
}

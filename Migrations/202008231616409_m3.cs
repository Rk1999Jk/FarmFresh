namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        UserEmail = c.String(nullable: false, maxLength: 128),
                        UserPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserEmail);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLogin");
        }
    }
}

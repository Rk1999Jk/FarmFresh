namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCategoryViewModel",
                c => new
                    {
                        Cid = c.Int(nullable: false, identity: true),
                        UserEmail = c.String(),
                        ChosenCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserCategoryViewModel");
        }
    }
}

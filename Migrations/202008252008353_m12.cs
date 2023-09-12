namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserCategoryViewModel");
            AlterColumn("dbo.UserCategoryViewModel", "UserEmail", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserCategoryViewModel", "UserEmail");
            DropColumn("dbo.UserCategoryViewModel", "Cid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserCategoryViewModel", "Cid", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserCategoryViewModel");
            AlterColumn("dbo.UserCategoryViewModel", "UserEmail", c => c.String());
            AddPrimaryKey("dbo.UserCategoryViewModel", "Cid");
        }
    }
}

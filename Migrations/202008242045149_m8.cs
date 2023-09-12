namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m8 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategorySelectionModel", newName: "ProductDetails");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductDetails", newName: "CategorySelectionModel");
        }
    }
}

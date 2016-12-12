namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Branches", newName: "Branch");
            RenameTable(name: "dbo.Customers", newName: "Customer");
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.Products", newName: "Product");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameTable(name: "dbo.Customer", newName: "Customers");
            RenameTable(name: "dbo.Branch", newName: "Branches");
        }
    }
}

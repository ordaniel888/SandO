namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "IsAdmin");
        }
    }
}

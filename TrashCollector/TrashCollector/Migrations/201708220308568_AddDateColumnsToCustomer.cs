namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateColumnsToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Comment");
            DropColumn("dbo.Customers", "EndDate");
            DropColumn("dbo.Customers", "StartDate");
        }
    }
}

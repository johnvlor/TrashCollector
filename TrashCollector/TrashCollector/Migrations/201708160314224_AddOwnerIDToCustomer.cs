namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnerIDToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "OwnerID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "OwnerID");
        }
    }
}

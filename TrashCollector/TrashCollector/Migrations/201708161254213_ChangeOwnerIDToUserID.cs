namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOwnerIDToUserID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserID", c => c.String());
            DropColumn("dbo.Customers", "OwnerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "OwnerID", c => c.String());
            DropColumn("dbo.Customers", "UserID");
        }
    }
}

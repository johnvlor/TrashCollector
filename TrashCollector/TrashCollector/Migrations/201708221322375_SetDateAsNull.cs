namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDateAsNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}

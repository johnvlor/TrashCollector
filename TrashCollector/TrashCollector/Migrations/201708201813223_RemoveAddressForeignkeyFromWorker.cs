namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAddressForeignkeyFromWorker : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workers", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Workers", new[] { "AddressID" });
            DropColumn("dbo.Workers", "AddressID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "AddressID", c => c.Int(nullable: false));
            CreateIndex("dbo.Workers", "AddressID");
            AddForeignKey("dbo.Workers", "AddressID", "dbo.Addresses", "ID", cascadeDelete: true);
        }
    }
}

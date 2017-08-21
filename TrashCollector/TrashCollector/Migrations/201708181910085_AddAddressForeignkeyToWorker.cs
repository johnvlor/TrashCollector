namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressForeignkeyToWorker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "AddressID", c => c.Int(nullable: false));
            CreateIndex("dbo.Workers", "AddressID");
            AddForeignKey("dbo.Workers", "AddressID", "dbo.Addresses", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Workers", new[] { "AddressID" });
            DropColumn("dbo.Workers", "AddressID");
        }
    }
}

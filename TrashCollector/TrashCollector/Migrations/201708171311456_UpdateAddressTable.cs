namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddressTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Addresses", "StateID", "dbo.States");
            DropForeignKey("dbo.Addresses", "ZipID", "dbo.Zips");
            DropIndex("dbo.Addresses", new[] { "CityID" });
            DropIndex("dbo.Addresses", new[] { "StateID" });
            DropIndex("dbo.Addresses", new[] { "ZipID" });
            AddColumn("dbo.Addresses", "City", c => c.String());
            AddColumn("dbo.Addresses", "State", c => c.String());
            AddColumn("dbo.Addresses", "Zip", c => c.String());
            DropColumn("dbo.Addresses", "CityID");
            DropColumn("dbo.Addresses", "StateID");
            DropColumn("dbo.Addresses", "ZipID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "ZipID", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "StateID", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "CityID", c => c.Int(nullable: false));
            DropColumn("dbo.Addresses", "Zip");
            DropColumn("dbo.Addresses", "State");
            DropColumn("dbo.Addresses", "City");
            CreateIndex("dbo.Addresses", "ZipID");
            CreateIndex("dbo.Addresses", "StateID");
            CreateIndex("dbo.Addresses", "CityID");
            AddForeignKey("dbo.Addresses", "ZipID", "dbo.Zips", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "StateID", "dbo.States", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "CityID", "dbo.Cities", "ID", cascadeDelete: true);
        }
    }
}

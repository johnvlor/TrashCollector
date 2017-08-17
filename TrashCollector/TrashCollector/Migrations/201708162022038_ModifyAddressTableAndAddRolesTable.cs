namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyAddressTableAndAddRolesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Zips",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Addresses", "CityID", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "StateID", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "ZipID", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "CityID");
            CreateIndex("dbo.Addresses", "StateID");
            CreateIndex("dbo.Addresses", "ZipID");
            AddForeignKey("dbo.Addresses", "CityID", "dbo.Cities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "StateID", "dbo.States", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "ZipID", "dbo.Zips", "ID", cascadeDelete: true);
            DropColumn("dbo.Addresses", "City");
            DropColumn("dbo.Addresses", "State");
            DropColumn("dbo.Addresses", "Zip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Zip", c => c.String());
            AddColumn("dbo.Addresses", "State", c => c.String());
            AddColumn("dbo.Addresses", "City", c => c.String());
            DropForeignKey("dbo.Addresses", "ZipID", "dbo.Zips");
            DropForeignKey("dbo.Addresses", "StateID", "dbo.States");
            DropForeignKey("dbo.Addresses", "CityID", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "ZipID" });
            DropIndex("dbo.Addresses", new[] { "StateID" });
            DropIndex("dbo.Addresses", new[] { "CityID" });
            DropColumn("dbo.Addresses", "ZipID");
            DropColumn("dbo.Addresses", "StateID");
            DropColumn("dbo.Addresses", "CityID");
            DropTable("dbo.Zips");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
        }
    }
}

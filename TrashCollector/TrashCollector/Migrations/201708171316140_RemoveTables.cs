namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTables : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Cities");
            DropTable("dbo.States");
            DropTable("dbo.Zips");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Zips",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ZipCode = c.String(),
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
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}

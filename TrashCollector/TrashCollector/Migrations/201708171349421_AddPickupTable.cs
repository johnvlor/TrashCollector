namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPickupTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        AlternateDay = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pickups");
        }
    }
}

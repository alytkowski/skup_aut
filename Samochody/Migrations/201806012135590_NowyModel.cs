namespace Samochody.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NowyModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "CarID", "dbo.Cars");
            DropIndex("dbo.Services", new[] { "CarID" });
            DropTable("dbo.Services");
        }
    }
}

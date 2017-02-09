namespace PetConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AdoptionStatusId", "dbo.AdoptionStatus");
            DropIndex("dbo.Users", new[] { "AdoptionStatusId" });
            DropColumn("dbo.Users", "AdoptionStatusId");
            DropTable("dbo.AdoptionStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdoptionStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PetIsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "AdoptionStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "AdoptionStatusId");
            AddForeignKey("dbo.Users", "AdoptionStatusId", "dbo.AdoptionStatus", "Id", cascadeDelete: true);
        }
    }
}

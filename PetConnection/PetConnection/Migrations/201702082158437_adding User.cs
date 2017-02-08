namespace PetConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        AddressID = c.Int(nullable: false),
                        EMail = c.String(),
                        AdoptionStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.AdoptionStatus", t => t.AdoptionStatusId, cascadeDelete: true)
                .Index(t => t.AddressID)
                .Index(t => t.AdoptionStatusId);
            
            CreateTable(
                "dbo.AdoptionStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PetIsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AdoptionStatusId", "dbo.AdoptionStatus");
            DropForeignKey("dbo.Users", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "AdoptionStatusId" });
            DropIndex("dbo.Users", new[] { "AddressID" });
            DropTable("dbo.AdoptionStatus");
            DropTable("dbo.Users");
        }
    }
}

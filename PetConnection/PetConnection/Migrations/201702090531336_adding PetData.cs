namespace PetConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPetData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Sex = c.String(),
                        Color = c.String(),
                        Breed = c.String(),
                        Age = c.Int(nullable: false),
                        Size = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetDatas", "UserId", "dbo.Users");
            DropIndex("dbo.PetDatas", new[] { "UserId" });
            DropTable("dbo.PetDatas");
        }
    }
}

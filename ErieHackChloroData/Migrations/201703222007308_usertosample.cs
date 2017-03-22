namespace ErieHackChloroData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertosample : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChlorophyllSamples",
                c => new
                    {
                        SampleId = c.Int(nullable: false, identity: true),
                        Lake = c.Int(nullable: false),
                        Site = c.Int(nullable: false),
                        TimeEntered = c.DateTime(nullable: false),
                        Parameter = c.Int(nullable: false),
                        EntryCode = c.Int(nullable: false),
                        Result = c.Double(nullable: false),
                        Unit = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SampleId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChlorophyllSamples", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ChlorophyllSamples", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ChlorophyllSamples");
        }
    }
}

namespace jsL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImgPathSmall = c.String(),
                        ImgPathLarge = c.String(),
                        StatsId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.Stats", t => t.StatsId, cascadeDelete: true)
                .Index(t => t.StatsId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Haki = c.Int(nullable: false),
                        AkumaNoMi = c.Int(),
                        AkumaNoMiName = c.String(),
                        Atk = c.Int(nullable: false),
                        Def = c.Int(nullable: false),
                        Spd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "StatsId", "dbo.Stats");
            DropForeignKey("dbo.Characters", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Characters", new[] { "OrganizationId" });
            DropIndex("dbo.Characters", new[] { "StatsId" });
            DropTable("dbo.Stats");
            DropTable("dbo.Organizations");
            DropTable("dbo.Characters");
        }
    }
}

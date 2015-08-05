namespace jsL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPicAndStats : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Characters", "ImgPathSmall", c => c.String());
            AddColumn("dbo.Characters", "ImgPathLarge", c => c.String());
            AddColumn("dbo.Characters", "Stats_Id", c => c.Int());
            CreateIndex("dbo.Characters", "Stats_Id");
            AddForeignKey("dbo.Characters", "Stats_Id", "dbo.Stats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "Stats_Id", "dbo.Stats");
            DropIndex("dbo.Characters", new[] { "Stats_Id" });
            DropColumn("dbo.Characters", "Stats_Id");
            DropColumn("dbo.Characters", "ImgPathLarge");
            DropColumn("dbo.Characters", "ImgPathSmall");
            DropTable("dbo.Stats");
        }
    }
}

namespace WordChainGame.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(),
                        GameId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        WordsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        WordContent = c.String(nullable: false, maxLength: 100),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.InappropriateWordRequestMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InappropriateWordId = c.Int(nullable: false),
                        IsInappropriate = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Words", t => t.InappropriateWordId, cascadeDelete: true)
                .Index(t => t.InappropriateWordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "GameId", "dbo.Games");
            DropForeignKey("dbo.Words", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.InappropriateWordRequestMappings", "InappropriateWordId", "dbo.Words");
            DropIndex("dbo.InappropriateWordRequestMappings", new[] { "InappropriateWordId" });
            DropIndex("dbo.Words", new[] { "TopicId" });
            DropIndex("dbo.Topics", new[] { "GameId" });
            DropTable("dbo.InappropriateWordRequestMappings");
            DropTable("dbo.Words");
            DropTable("dbo.Topics");
            DropTable("dbo.Games");
        }
    }
}

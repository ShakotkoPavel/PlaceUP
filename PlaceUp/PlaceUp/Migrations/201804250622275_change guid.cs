namespace PlaceUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeguid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Places", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Places", new[] { "CategoryId" });
            AlterColumn("dbo.Places", "CategoryId", c => c.Guid());
            CreateIndex("dbo.Places", "CategoryId");
            AddForeignKey("dbo.Places", "CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Places", new[] { "CategoryId" });
            AlterColumn("dbo.Places", "CategoryId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Places", "CategoryId");
            AddForeignKey("dbo.Places", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}

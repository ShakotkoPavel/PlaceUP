namespace PlaceUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changetags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "ImageData", c => c.Binary());
            AddColumn("dbo.Places", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "ImageMimeType");
            DropColumn("dbo.Places", "ImageData");
        }
    }
}

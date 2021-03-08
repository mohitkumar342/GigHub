namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGigAndGenreModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Genre_ID" });
            RenameColumn(table: "dbo.Gigs", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Gigs", name: "Genre_ID", newName: "GenreId");
            RenameIndex(table: "dbo.Gigs", name: "IX_Artist_Id", newName: "IX_ArtistId");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "ID", c => c.Byte(nullable: false));
            AlterColumn("dbo.Gigs", "GenreId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "ID");
            CreateIndex("dbo.Gigs", "GenreId");
            AddForeignKey("dbo.Gigs", "GenreId", "dbo.Genres", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "GenreId", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Gigs", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Genres", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Genres", "ID");
            RenameIndex(table: "dbo.Gigs", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Gigs", name: "GenreId", newName: "Genre_ID");
            RenameColumn(table: "dbo.Gigs", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.Gigs", "Genre_ID");
            AddForeignKey("dbo.Gigs", "Genre_ID", "dbo.Genres", "ID", cascadeDelete: true);
        }
    }
}

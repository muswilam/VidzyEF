namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enableCascadeDeleteForForeignKeyGenreId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "GenreId", "dbo.Genres");
            AddForeignKey("dbo.Videos", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "GenreId", "dbo.Genres");
            AddForeignKey("dbo.Videos", "GenreId", "dbo.Genres", "Id");
        }
    }
}

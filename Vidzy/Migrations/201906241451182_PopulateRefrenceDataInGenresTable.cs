namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRefrenceDataInGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres values(1,'Action')");
            Sql("insert into Genres values(2,'Drama')");
            Sql("insert into Genres values(3,'Fantasy')");
            Sql("insert into Genres values(4,'History')");
            Sql("insert into Genres values(5,'Romance')");
            Sql("insert into Genres values(6,'War')");

        }
        
        public override void Down()
        {
        }
    }
}

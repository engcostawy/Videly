namespace Videly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into genres(name) values('Comedy')");
            Sql("Insert into genres(name) values('Action')");
            Sql("Insert into genres(name) values('Family')");
            Sql("Insert into genres(name) values('Romance')");

        }

        public override void Down()
        {
        }
    }
}

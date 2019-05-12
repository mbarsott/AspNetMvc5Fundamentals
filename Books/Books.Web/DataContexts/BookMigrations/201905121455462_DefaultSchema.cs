namespace Books.Web.DataContexts.BookMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Books", newSchema: "libary");
        }
        
        public override void Down()
        {
            MoveTable(name: "libary.Books", newSchema: "dbo");
        }
    }
}

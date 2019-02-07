namespace TotusTuus.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsHomeParishToParishRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParishRequests", "IsHomeParish", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParishRequests", "IsHomeParish");
        }
    }
}

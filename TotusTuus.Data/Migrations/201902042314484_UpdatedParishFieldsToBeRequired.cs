namespace TotusTuus.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedParishFieldsToBeRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parishes", "StreetAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Parishes", "PostalCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parishes", "PostalCode", c => c.String());
            AlterColumn("dbo.Parishes", "StreetAddress", c => c.String());
        }
    }
}

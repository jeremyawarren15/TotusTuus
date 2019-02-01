namespace TotusTuus.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedExtraTrackingFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeSlots", "RemovedDate", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Parishes", "ParishName", c => c.String(nullable: false));
            AlterColumn("dbo.Parishes", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Parishes", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Parishes", "Archdiocese", c => c.String(nullable: false));
            AlterColumn("dbo.Parishes", "OfficePhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parishes", "OfficePhoneNumber", c => c.String());
            AlterColumn("dbo.Parishes", "Archdiocese", c => c.String());
            AlterColumn("dbo.Parishes", "State", c => c.String());
            AlterColumn("dbo.Parishes", "City", c => c.String());
            AlterColumn("dbo.Parishes", "ParishName", c => c.String());
            DropColumn("dbo.TimeSlots", "RemovedDate");
        }
    }
}

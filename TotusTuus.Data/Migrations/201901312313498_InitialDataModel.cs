namespace TotusTuus.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParishName = c.String(),
                        StreetAddress = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Pastor = c.String(),
                        Archdiocese = c.String(),
                        OfficePhoneNumber = c.String(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParishRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DecisionDate = c.DateTimeOffset(precision: 7),
                        Parish_Id = c.Int(nullable: false),
                        RequestingUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parishes", t => t.Parish_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.RequestingUser_Id, cascadeDelete: true)
                .Index(t => t.Parish_Id)
                .Index(t => t.RequestingUser_Id);
            
            CreateTable(
                "dbo.SubstitutionHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        AssignedDate = c.DateTimeOffset(precision: 7),
                        RequestingUser_Id = c.String(nullable: false, maxLength: 128),
                        ResponsibleUser_Id = c.String(maxLength: 128),
                        TimeSlot_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RequestingUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ResponsibleUser_Id)
                .ForeignKey("dbo.TimeSlots", t => t.TimeSlot_Id, cascadeDelete: true)
                .Index(t => t.RequestingUser_Id)
                .Index(t => t.ResponsibleUser_Id)
                .Index(t => t.TimeSlot_Id);
            
            CreateTable(
                "dbo.TimeSlots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Parish_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parishes", t => t.Parish_Id, cascadeDelete: true)
                .Index(t => t.Parish_Id);
            
            CreateTable(
                "dbo.TimeSlotHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        EndDate = c.DateTimeOffset(precision: 7),
                        ResponsibleUser_Id = c.String(nullable: false, maxLength: 128),
                        TimeSlot_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ResponsibleUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.TimeSlots", t => t.TimeSlot_Id, cascadeDelete: true)
                .Index(t => t.ResponsibleUser_Id)
                .Index(t => t.TimeSlot_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeSlotHistory", "TimeSlot_Id", "dbo.TimeSlots");
            DropForeignKey("dbo.TimeSlotHistory", "ResponsibleUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubstitutionHistory", "TimeSlot_Id", "dbo.TimeSlots");
            DropForeignKey("dbo.TimeSlots", "Parish_Id", "dbo.Parishes");
            DropForeignKey("dbo.SubstitutionHistory", "ResponsibleUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubstitutionHistory", "RequestingUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ParishRequests", "RequestingUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ParishRequests", "Parish_Id", "dbo.Parishes");
            DropIndex("dbo.TimeSlotHistory", new[] { "TimeSlot_Id" });
            DropIndex("dbo.TimeSlotHistory", new[] { "ResponsibleUser_Id" });
            DropIndex("dbo.TimeSlots", new[] { "Parish_Id" });
            DropIndex("dbo.SubstitutionHistory", new[] { "TimeSlot_Id" });
            DropIndex("dbo.SubstitutionHistory", new[] { "ResponsibleUser_Id" });
            DropIndex("dbo.SubstitutionHistory", new[] { "RequestingUser_Id" });
            DropIndex("dbo.ParishRequests", new[] { "RequestingUser_Id" });
            DropIndex("dbo.ParishRequests", new[] { "Parish_Id" });
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.TimeSlotHistory");
            DropTable("dbo.TimeSlots");
            DropTable("dbo.SubstitutionHistory");
            DropTable("dbo.ParishRequests");
            DropTable("dbo.Parishes");
        }
    }
}

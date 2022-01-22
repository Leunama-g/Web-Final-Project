namespace Clinic_Patient_Info_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moredomainmodelsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Adderess = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LabTeches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Adderess = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receptionists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Adderess = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Doctors", "UserID", c => c.String());
            AddColumn("dbo.Doctors", "FirstName", c => c.String());
            AddColumn("dbo.Doctors", "LastName", c => c.String());
            AddColumn("dbo.Doctors", "Birthdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "Adderess", c => c.String());
            AddColumn("dbo.Doctors", "PhoneNumber", c => c.String());
            AddColumn("dbo.Doctors", "Specialty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Specialty");
            DropColumn("dbo.Doctors", "PhoneNumber");
            DropColumn("dbo.Doctors", "Adderess");
            DropColumn("dbo.Doctors", "Birthdate");
            DropColumn("dbo.Doctors", "LastName");
            DropColumn("dbo.Doctors", "FirstName");
            DropColumn("dbo.Doctors", "UserID");
            DropTable("dbo.Receptionists");
            DropTable("dbo.LabTeches");
            DropTable("dbo.Admins");
        }
    }
}

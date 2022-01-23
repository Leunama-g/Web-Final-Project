namespace Clinic_Patient_Info_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientandvisitationtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Adderess = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.String(),
                        ReasonForVisit = c.String(),
                        Medicine = c.String(),
                        VisitDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Priority = c.String(),
                        DoctorName = c.String(),
                        Diagnosis = c.String(),
                        Perscription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Visitations");
            DropTable("dbo.Patients");
        }
    }
}

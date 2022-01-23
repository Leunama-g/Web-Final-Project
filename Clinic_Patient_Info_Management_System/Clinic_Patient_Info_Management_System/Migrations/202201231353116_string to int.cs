namespace Clinic_Patient_Info_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringtoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visitations", "PatientId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visitations", "PatientId", c => c.String());
        }
    }
}

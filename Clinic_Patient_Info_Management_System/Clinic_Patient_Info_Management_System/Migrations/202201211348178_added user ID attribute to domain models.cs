namespace Clinic_Patient_Info_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduserIDattributetodomainmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "UserID", c => c.String());
            AddColumn("dbo.LabTeches", "UserID", c => c.String());
            AddColumn("dbo.Receptionists", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receptionists", "UserID");
            DropColumn("dbo.LabTeches", "UserID");
            DropColumn("dbo.Admins", "UserID");
        }
    }
}

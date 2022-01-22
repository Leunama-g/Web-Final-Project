namespace Clinic_Patient_Info_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class singleEmployeetablewithtypeattribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Type");
        }
    }
}

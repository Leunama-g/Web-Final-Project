namespace Clinic_Patient_Info_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedoccupationtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Occupations");
        }
    }
}

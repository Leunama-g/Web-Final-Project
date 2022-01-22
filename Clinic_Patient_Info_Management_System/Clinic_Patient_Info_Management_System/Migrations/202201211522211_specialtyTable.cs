namespace Clinic_Patient_Info_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class specialtyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Occupations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Specialties");
        }
    }
}

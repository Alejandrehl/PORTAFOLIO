namespace Portafolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentApplication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CEM.StudentApplications",
                c => new
                    {
                        StudentApplicationId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ApplicationStatus = c.String(),
                        StudentName = c.String(),
                        ProgramId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.StudentApplicationId)
                .ForeignKey("CEM.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CEM.StudentApplications", "ProgramId", "CEM.Programs");
            DropIndex("CEM.StudentApplications", new[] { "ProgramId" });
            DropTable("CEM.StudentApplications");
        }
    }
}

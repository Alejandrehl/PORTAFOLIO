namespace Portafolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CEM.ApplicationStatus",
                c => new
                    {
                        ApplicationStatusId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationStatusId);
            
            AddColumn("CEM.StudentApplications", "ApplicationStatusId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            CreateIndex("CEM.StudentApplications", "ApplicationStatusId");
            AddForeignKey("CEM.StudentApplications", "ApplicationStatusId", "CEM.ApplicationStatus", "ApplicationStatusId", cascadeDelete: true);
            DropColumn("CEM.StudentApplications", "ApplicationStatus");
        }
        
        public override void Down()
        {
            AddColumn("CEM.StudentApplications", "ApplicationStatus", c => c.String());
            DropForeignKey("CEM.StudentApplications", "ApplicationStatusId", "CEM.ApplicationStatus");
            DropIndex("CEM.StudentApplications", new[] { "ApplicationStatusId" });
            DropColumn("CEM.StudentApplications", "ApplicationStatusId");
            DropTable("CEM.ApplicationStatus");
        }
    }
}

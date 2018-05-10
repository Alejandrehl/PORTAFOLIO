namespace Portafolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CEM.Countries",
                c => new
                    {
                        CountryId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "CEM.Courses",
                c => new
                    {
                        CourseId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        ProgramId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Program_ProgramId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("CEM.Programs", t => t.Program_ProgramId)
                .ForeignKey("CEM.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.Program_ProgramId);
            
            CreateTable(
                "CEM.Programs",
                c => new
                    {
                        ProgramId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.String(),
                        Spaces = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Course_CourseId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ProgramId)
                .ForeignKey("CEM.Courses", t => t.Course_CourseId)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "CEM.FamilyInfoes",
                c => new
                    {
                        FamilyInfoId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CriminalRecord = c.String(),
                        Residence = c.String(),
                        Work = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.FamilyInfoId);
            
            CreateTable(
                "CEM.Notes",
                c => new
                    {
                        NoteId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CourseId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("CEM.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "CEM.StudyCenters",
                c => new
                    {
                        StudyCenterId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        CountryId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.StudyCenterId)
                .ForeignKey("CEM.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CEM.StudyCenters", "CountryId", "CEM.Countries");
            DropForeignKey("CEM.Notes", "CourseId", "CEM.Courses");
            DropForeignKey("CEM.Programs", "Course_CourseId", "CEM.Courses");
            DropForeignKey("CEM.Courses", "ProgramId", "CEM.Programs");
            DropForeignKey("CEM.Courses", "Program_ProgramId", "CEM.Programs");
            DropIndex("CEM.StudyCenters", new[] { "CountryId" });
            DropIndex("CEM.Notes", new[] { "CourseId" });
            DropIndex("CEM.Programs", new[] { "Course_CourseId" });
            DropIndex("CEM.Courses", new[] { "Program_ProgramId" });
            DropIndex("CEM.Courses", new[] { "ProgramId" });
            DropTable("CEM.StudyCenters");
            DropTable("CEM.Notes");
            DropTable("CEM.FamilyInfoes");
            DropTable("CEM.Programs");
            DropTable("CEM.Courses");
            DropTable("CEM.Countries");
        }
    }
}

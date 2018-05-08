namespace Portafolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ADMIN_PORTAFOLIO.Countries",
                c => new
                    {
                        CountryId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "ADMIN_PORTAFOLIO.Courses",
                c => new
                    {
                        CourseId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        ExchangeProgramId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("ADMIN_PORTAFOLIO.ExchangePrograms", t => t.ExchangeProgramId, cascadeDelete: true)
                .Index(t => t.ExchangeProgramId);
            
            CreateTable(
                "ADMIN_PORTAFOLIO.ExchangePrograms",
                c => new
                    {
                        ExchangeProgramId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.String(),
                        SpacesAvailables = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ExchangeProgramId);
            
            CreateTable(
                "ADMIN_PORTAFOLIO.ExchangeProgramCourses1",
                c => new
                    {
                        ProgramCoursesId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ExchangeProgramId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CourseId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ProgramCoursesId)
                .ForeignKey("ADMIN_PORTAFOLIO.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("ADMIN_PORTAFOLIO.ExchangePrograms", t => t.ExchangeProgramId, cascadeDelete: true)
                .Index(t => t.ExchangeProgramId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "ADMIN_PORTAFOLIO.FamilyInfoes",
                c => new
                    {
                        FamilyInfoId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CriminalRecord = c.String(),
                        ResidenceCertificate = c.String(),
                        WorkCertificate = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.FamilyInfoId)
                .ForeignKey("ADMIN_PORTAFOLIO.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "ADMIN_PORTAFOLIO.Users",
                c => new
                    {
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        IsActive = c.Decimal(nullable: false, precision: 1, scale: 0),
                        RoleId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("ADMIN_PORTAFOLIO.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "ADMIN_PORTAFOLIO.Roles",
                c => new
                    {
                        RoleId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "ADMIN_PORTAFOLIO.LocalCenters",
                c => new
                    {
                        LocalCenterId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        CountryId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.LocalCenterId)
                .ForeignKey("ADMIN_PORTAFOLIO.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "ADMIN_PORTAFOLIO.Notes",
                c => new
                    {
                        NoteId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CourseId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("ADMIN_PORTAFOLIO.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("ADMIN_PORTAFOLIO.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
            CreateTable(
                "ADMIN_PORTAFOLIO.ExchangeProgramCourses",
                c => new
                    {
                        ExchangeProgramId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CourseId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.ExchangeProgramId, t.CourseId })
                .ForeignKey("ADMIN_PORTAFOLIO.ExchangePrograms", t => t.ExchangeProgramId, cascadeDelete: true)
                .ForeignKey("ADMIN_PORTAFOLIO.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.ExchangeProgramId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "ADMIN_PORTAFOLIO.UserRoles",
                c => new
                    {
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        RoleId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("ADMIN_PORTAFOLIO.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("ADMIN_PORTAFOLIO.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ADMIN_PORTAFOLIO.Notes", "UserId", "ADMIN_PORTAFOLIO.Users");
            DropForeignKey("ADMIN_PORTAFOLIO.Notes", "CourseId", "ADMIN_PORTAFOLIO.Courses");
            DropForeignKey("ADMIN_PORTAFOLIO.LocalCenters", "CountryId", "ADMIN_PORTAFOLIO.Countries");
            DropForeignKey("ADMIN_PORTAFOLIO.FamilyInfoes", "UserId", "ADMIN_PORTAFOLIO.Users");
            DropForeignKey("ADMIN_PORTAFOLIO.UserRoles", "RoleId", "ADMIN_PORTAFOLIO.Roles");
            DropForeignKey("ADMIN_PORTAFOLIO.UserRoles", "UserId", "ADMIN_PORTAFOLIO.Users");
            DropForeignKey("ADMIN_PORTAFOLIO.Users", "RoleId", "ADMIN_PORTAFOLIO.Roles");
            DropForeignKey("ADMIN_PORTAFOLIO.ExchangeProgramCourses1", "ExchangeProgramId", "ADMIN_PORTAFOLIO.ExchangePrograms");
            DropForeignKey("ADMIN_PORTAFOLIO.ExchangeProgramCourses1", "CourseId", "ADMIN_PORTAFOLIO.Courses");
            DropForeignKey("ADMIN_PORTAFOLIO.Courses", "ExchangeProgramId", "ADMIN_PORTAFOLIO.ExchangePrograms");
            DropForeignKey("ADMIN_PORTAFOLIO.ExchangeProgramCourses", "CourseId", "ADMIN_PORTAFOLIO.Courses");
            DropForeignKey("ADMIN_PORTAFOLIO.ExchangeProgramCourses", "ExchangeProgramId", "ADMIN_PORTAFOLIO.ExchangePrograms");
            DropIndex("ADMIN_PORTAFOLIO.UserRoles", new[] { "RoleId" });
            DropIndex("ADMIN_PORTAFOLIO.UserRoles", new[] { "UserId" });
            DropIndex("ADMIN_PORTAFOLIO.ExchangeProgramCourses", new[] { "CourseId" });
            DropIndex("ADMIN_PORTAFOLIO.ExchangeProgramCourses", new[] { "ExchangeProgramId" });
            DropIndex("ADMIN_PORTAFOLIO.Notes", new[] { "UserId" });
            DropIndex("ADMIN_PORTAFOLIO.Notes", new[] { "CourseId" });
            DropIndex("ADMIN_PORTAFOLIO.LocalCenters", new[] { "CountryId" });
            DropIndex("ADMIN_PORTAFOLIO.Users", new[] { "RoleId" });
            DropIndex("ADMIN_PORTAFOLIO.FamilyInfoes", new[] { "UserId" });
            DropIndex("ADMIN_PORTAFOLIO.ExchangeProgramCourses1", new[] { "CourseId" });
            DropIndex("ADMIN_PORTAFOLIO.ExchangeProgramCourses1", new[] { "ExchangeProgramId" });
            DropIndex("ADMIN_PORTAFOLIO.Courses", new[] { "ExchangeProgramId" });
            DropTable("ADMIN_PORTAFOLIO.UserRoles");
            DropTable("ADMIN_PORTAFOLIO.ExchangeProgramCourses");
            DropTable("ADMIN_PORTAFOLIO.Notes");
            DropTable("ADMIN_PORTAFOLIO.LocalCenters");
            DropTable("ADMIN_PORTAFOLIO.Roles");
            DropTable("ADMIN_PORTAFOLIO.Users");
            DropTable("ADMIN_PORTAFOLIO.FamilyInfoes");
            DropTable("ADMIN_PORTAFOLIO.ExchangeProgramCourses1");
            DropTable("ADMIN_PORTAFOLIO.ExchangePrograms");
            DropTable("ADMIN_PORTAFOLIO.Courses");
            DropTable("ADMIN_PORTAFOLIO.Countries");
        }
    }
}

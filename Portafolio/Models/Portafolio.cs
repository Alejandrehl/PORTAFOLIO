namespace Portafolio.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class Portafolio : DbContext
    {
        public Portafolio()
            : base("name=PortafolioConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ADMIN_PORTAFOLIO");
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.ToTable("UserRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });

            modelBuilder.Entity<ExchangeProgram>()
                .HasMany(e => e.Courses)
                .WithMany(c => c.ExchangePrograms)
                .Map(m =>
                {
                    m.ToTable("ExchangeProgramCourses");
                    m.MapLeftKey("ExchangeProgramId");
                    m.MapRightKey("CourseId");
                });
        }

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<FamilyInfo> FamilyInfo { get; set; }
        public virtual DbSet<ExchangeProgram> ExchangeProgram { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<LocalCenter> LocalCenter { get; set; }
        public virtual DbSet<ExchangeProgramCourse> ExchangeProgramCourse { get; set; }
    }

    //Modelos
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }

    public class FamilyInfo
    {
        [Key]
        public int FamilyInfoId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public string CriminalRecord { get; set; }
        public string ResidenceCertificate { get; set; }
        public string WorkCertificate { get; set; }
        public string Photo { get; set; }
    }

    public class ExchangeProgram
    {
        [Key]
        public int ExchangeProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int SpacesAvailables { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }

    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int ExchangeProgramId { get; set; }
        [ForeignKey("ExchangeProgramId")]
        public virtual ExchangeProgram ExchangeProgram { get; set; }
        public virtual ICollection<ExchangeProgram> ExchangePrograms { get; set; }
    }

    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public double Score { get; set; }
    }

    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
    }

    public class LocalCenter
    {
        [Key]
        public int LocalCenterId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country country { get; set; }
    }

    public class ExchangeProgramCourse
    {
        [Key]
        public int ProgramCoursesId { get; set; }
        public int ExchangeProgramId { get; set; }
        [ForeignKey("ExchangeProgramId")]
        public virtual ExchangeProgram ExchangeProgram { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
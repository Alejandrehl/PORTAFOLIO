namespace Portafolio.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class Cem : DbContext
    {
        public Cem()
            : base("name=cem")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CEM");
        }

        public virtual DbSet<FamilyInfo> FamilyInfo { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<StudyCenter> StudyCenter { get; set; }
    }

    //Modelos
    public class FamilyInfo
    {
        [Key]
        public int FamilyInfoId { get; set; }
        public string CriminalRecord { get; set; }
        public string Residence { get; set; }
        public string Work { get; set; }
        public string Photo { get; set; }
    }

    public class Program
    {
        [Key]
        public int ProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Spaces { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }

    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public virtual Program Program { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }

    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public double Score { get; set; }
    }

    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
    }

    public class StudyCenter
    {
        [Key]
        public int StudyCenterId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country country { get; set; }
    }
}
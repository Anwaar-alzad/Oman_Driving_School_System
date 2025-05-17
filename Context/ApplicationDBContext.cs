// This is created when using inheriting DBContext class
using Microsoft.EntityFrameworkCore;

namespace Oman_Driving_School_System;

public class ApplicationDBContext : DbContext
{
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Lesson> Lessons { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=134.209.227.169,1433;Database=OmanDrivingSchoolDB;User Id=SA;Password=qKTxTjgSzDhs0EykMhbqmwrktJUeeNX#;Encrypt=False;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Student)
            .WithMany(s => s.Lessons)
            .HasForeignKey(l => l.StudentId);

        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Instructor)
            .WithMany(i => i.Lessons)
            .HasForeignKey(l => l.InstructorId);

        modelBuilder.Entity<Lesson>()
               .Property(l => l.Time)
               .HasConversion(
                   v => v.ToTimeSpan(),               // Convert TimeOnly to TimeSpan for DB
                   v => TimeOnly.FromTimeSpan(v))     // Convert TimeSpan from DB to TimeOnly
               .HasColumnType("time");
    }
}

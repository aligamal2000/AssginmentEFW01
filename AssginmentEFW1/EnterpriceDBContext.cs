using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace AssginmentEFW1
{
    public class EnterpriceDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-68C09D0;Database=EnterPrice3DB;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<CourseInst> CourseInsts { get; set; }
        public DbSet<StudCourse> StudCourses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-Many: Student & Course
            modelBuilder.Entity<StudCourse>()
                .HasKey(sc => new { sc.Stud_ID, sc.Course_ID });

            modelBuilder.Entity<StudCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudCourses)
                .HasForeignKey(sc => sc.Stud_ID);

            modelBuilder.Entity<StudCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudCourses)
                .HasForeignKey(sc => sc.Course_ID);

            // Many-to-Many: Course & Instructor
            modelBuilder.Entity<CourseInst>()
                .HasKey(ci => new { ci.InstId, ci.CourseId });

            modelBuilder.Entity<CourseInst>()
                .HasOne(ci => ci.Instructor)
                .WithMany(i => i.CourseInsts)
                .HasForeignKey(ci => ci.InstId);

            modelBuilder.Entity<CourseInst>()
                .HasOne(ci => ci.Course)
                .WithMany(c => c.CourseInsts)
                .HasForeignKey(ci => ci.CourseId);

            // One-to-Many: Student -> Department
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepId);

            // One-to-Many: Instructor -> Department
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Instructor)
                .WithMany()
                .HasForeignKey(d => d.Ins_ID);
            modelBuilder.Entity<Instructor>()
       .HasOne(i => i.Department)
       .WithMany()
       .HasForeignKey(i => i.Dept_ID)
       .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
        public void AddEntity<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
            SaveChanges();
        }

        public List<T> GetAllEntities<T>() where T : class
        {
            return Set<T>().ToList();
        }

        public T GetEntityById<T>(int id) where T : class
        {
            return Set<T>().Find(id);
        }

        public void UpdateEntity<T>(T entity) where T : class
        {
            Set<T>().Update(entity);
            SaveChanges();
        }

        public void DeleteEntity<T>(int id) where T : class
        {
            var entity = Set<T>().Find(id);
            if (entity != null)
            {
                Set<T>().Remove(entity);
                SaveChanges();
            }
        }

    }

}


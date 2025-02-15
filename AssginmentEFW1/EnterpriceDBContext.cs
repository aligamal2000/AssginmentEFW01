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
            optionsBuilder.UseSqlServer("Server=DESKTOP-68C09D0;Database=EnterPriceDB;Integrated Security=True;TrustServerCertificate=True;");
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
            modelBuilder.Entity<CourseInst>().ToTable("CourseInstructor");
            modelBuilder.Entity<StudCourse>().ToTable("StudentCourse");
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


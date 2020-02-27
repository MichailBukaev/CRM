using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using models;

namespace data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<History> Historys { get; set; }
        public DbSet<HistoryGroup> HistoryGroups { get; set; }
        public DbSet<HR> HRs { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Status> Statuss { get; set; }
        public DbSet<SkillsLead> SkillsLeads { get; set; }
        public DbSet<Teacher> Teacherss { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<LinkTeacherCourse> LinkTeacherCourses { get; set; }
        public DbSet<TaskWork> TaskWorks { get; set; }
        public DbSet<TasksStatus> TasksStatuses { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = CRM; Trusted_Connection = True; ");
        }   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<HistoryGroup>().HasNoKey();
            //modelBuilder.Entity<History>().HasNoKey();
            //base.OnModelCreating(modelBuilder);

        }
    }
}

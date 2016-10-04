using MiniProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace MiniProject.DAL
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext()
            : base("AttendanceContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
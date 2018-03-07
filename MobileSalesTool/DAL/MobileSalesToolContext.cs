using MobileSalesTool.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MobileSalesTool.DAL
{
    public class MobileSalesToolContext : DbContext
    {

        public MobileSalesToolContext() : base("MobileSalesToolContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
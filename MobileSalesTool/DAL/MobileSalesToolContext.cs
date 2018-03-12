using MobileSalesTool.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MobileSalesTool.DAL
{
    public class MobileSalesToolContext : DbContext
    {
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Promotion>()
                .HasMany(c => c.Consumers).WithMany(i => i.Promotions)
                .Map(t => t.MapLeftKey("PromotionID")
                    .MapRightKey("ConsumerID")
                    .ToTable("PromotionConsumer"));
        }
    }
}
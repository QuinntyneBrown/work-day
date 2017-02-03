using System.Data.Entity;
using WorkDay.Data.Models;
using System.Linq;
using System;

namespace WorkDay.Data
{
    public class WorkDayDataContext: DbContext
    {
        public WorkDayDataContext()
            : base(nameOrConnectionString: "WorkDayDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<TimeOff> TimeOffs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries()
            .Where(e => e.Entity is ILoggable && ((e.State == EntityState.Added || (e.State == EntityState.Modified)))))
            {

                if (((ILoggable)entry.Entity).CreatedOn == default(DateTime))
                {
                    ((ILoggable)entry.Entity).CreatedOn = DateTime.UtcNow;
                }

                ((ILoggable)entry.Entity).LastModifiedOn = DateTime.UtcNow;

            }

            return base.SaveChanges();
        }
    }
}

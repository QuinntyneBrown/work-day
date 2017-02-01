using System.Data.Entity;
using WorkDay.Data.Models;

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
    }
}

namespace WorkDay.Migrations
{
    using System.Data.Entity.Migrations;
    
    internal sealed class Configuration : DbMigrationsConfiguration<WorkDay.Data.WorkDayDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WorkDay.Data.WorkDayDataContext context)
        {
            RoleConfiguration.Seed(context);
            UserConfiguration.Seed(context);
            EmployeeConfiguration.Seed(context);
            TimeOffConfiguration.Seed(context);
        }
    }
}

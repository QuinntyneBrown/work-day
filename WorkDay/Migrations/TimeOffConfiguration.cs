using System.Data.Entity.Migrations;
using WorkDay.Data;

namespace WorkDay.Migrations
{
    public class TimeOffConfiguration
    {
        public static void Seed(WorkDayDataContext context) {

            context.SaveChanges();
        }
    }
}

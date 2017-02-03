using System.Data.Entity.Migrations;
using WorkDay.Data;
using WorkDay.Data.Models;

namespace WorkDay.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(WorkDayDataContext context) {

            context.SaveChanges();
        }
    }
}

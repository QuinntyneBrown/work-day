using System.Data.Entity.Migrations;
using WorkDay.Data;
using WorkDay.Data.Models;

namespace WorkDay.Migrations
{
    public class EmployeeConfiguration
    {
        public static void Seed(WorkDayDataContext context) {

            context.Employees.AddOrUpdate(x => x.Email, new Employee()
            {
                Email = "quinntynebrown@gmail.com",
                Firstname = "Quinntyne",
                Lastname = "Brown",
                Name = "Quinntyne Brown"
            });

            context.SaveChanges();
        }
    }
}

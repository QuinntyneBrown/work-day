using WorkDay.Data.Models;

namespace WorkDay.Features.Employees
{
    public class EmployeeApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromEmployee<TModel>(Employee employee) where
            TModel : EmployeeApiModel, new()
        {
            var model = new TModel();
            model.Id = employee.Id;
            return model;
        }

        public static EmployeeApiModel FromEmployee(Employee employee)
            => FromEmployee<EmployeeApiModel>(employee);

    }
}

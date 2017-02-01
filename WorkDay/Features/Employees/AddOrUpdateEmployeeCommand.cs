using MediatR;
using WorkDay.Data;
using WorkDay.Data.Models;
using WorkDay.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace WorkDay.Features.Employees
{
    public class AddOrUpdateEmployeeCommand
    {
        public class AddOrUpdateEmployeeRequest : IRequest<AddOrUpdateEmployeeResponse>
        {
            public EmployeeApiModel Employee { get; set; }
        }

        public class AddOrUpdateEmployeeResponse { }

        public class AddOrUpdateEmployeeHandler : IAsyncRequestHandler<AddOrUpdateEmployeeRequest, AddOrUpdateEmployeeResponse>
        {
            public AddOrUpdateEmployeeHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateEmployeeResponse> Handle(AddOrUpdateEmployeeRequest request)
            {
                var entity = await _dataContext.Employees
                    .SingleOrDefaultAsync(x => x.Id == request.Employee.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Employees.Add(entity = new Employee());
                entity.Name = request.Employee.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateEmployeeResponse()
                {

                };
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

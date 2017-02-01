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
    public class RemoveEmployeeCommand
    {
        public class RemoveEmployeeRequest : IRequest<RemoveEmployeeResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveEmployeeResponse { }

        public class RemoveEmployeeHandler : IAsyncRequestHandler<RemoveEmployeeRequest, RemoveEmployeeResponse>
        {
            public RemoveEmployeeHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveEmployeeResponse> Handle(RemoveEmployeeRequest request)
            {
                var employee = await _dataContext.Employees.FindAsync(request.Id);
                employee.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveEmployeeResponse();
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

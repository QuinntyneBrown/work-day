using MediatR;
using WorkDay.Data;
using WorkDay.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace WorkDay.Features.Employees
{
    public class GetEmployeesQuery
    {
        public class GetEmployeesRequest : IRequest<GetEmployeesResponse> { }

        public class GetEmployeesResponse
        {
            public ICollection<EmployeeApiModel> Employees { get; set; } = new HashSet<EmployeeApiModel>();
        }

        public class GetEmployeesHandler : IAsyncRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
        {
            public GetEmployeesHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetEmployeesResponse> Handle(GetEmployeesRequest request)
            {
                var employees = await _dataContext.Employees.ToListAsync();
                return new GetEmployeesResponse()
                {
                    Employees = employees.Select(x => EmployeeApiModel.FromEmployee(x)).ToList()
                };
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

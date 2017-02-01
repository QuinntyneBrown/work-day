using MediatR;
using WorkDay.Data;
using WorkDay.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace WorkDay.Features.Employees
{
    public class GetEmployeeByIdQuery
    {
        public class GetEmployeeByIdRequest : IRequest<GetEmployeeByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetEmployeeByIdResponse
        {
            public EmployeeApiModel Employee { get; set; } 
		}

        public class GetEmployeeByIdHandler : IAsyncRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
        {
            public GetEmployeeByIdHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request)
            {                
                return new GetEmployeeByIdResponse()
                {
                    Employee = EmployeeApiModel.FromEmployee(await _dataContext.Employees.FindAsync(request.Id))
                };
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

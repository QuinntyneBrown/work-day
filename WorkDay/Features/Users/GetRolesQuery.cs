using MediatR;
using WorkDay.Data;
using WorkDay.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace WorkDay.Features.Users
{
    public class GetRolesQuery
    {
        public class GetRolesRequest : IRequest<GetRolesResponse> { }

        public class GetRolesResponse
        {
            public ICollection<RoleApiModel> Roles { get; set; } = new HashSet<RoleApiModel>();
        }

        public class GetRolesHandler : IAsyncRequestHandler<GetRolesRequest, GetRolesResponse>
        {
            public GetRolesHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetRolesResponse> Handle(GetRolesRequest request)
            {
                var roles = await _dataContext.Roles.ToListAsync();
                return new GetRolesResponse()
                {
                    Roles = roles.Select(x => RoleApiModel.FromRole(x)).ToList()
                };
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

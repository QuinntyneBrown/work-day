using MediatR;
using WorkDay.Data;
using WorkDay.Data.Models;
using WorkDay.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace WorkDay.Features.Users
{
    public class RemoveRoleCommand
    {
        public class RemoveRoleRequest : IRequest<RemoveRoleResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveRoleResponse { }

        public class RemoveRoleHandler : IAsyncRequestHandler<RemoveRoleRequest, RemoveRoleResponse>
        {
            public RemoveRoleHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveRoleResponse> Handle(RemoveRoleRequest request)
            {
                var role = await _dataContext.Roles.FindAsync(request.Id);
                role.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveRoleResponse();
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

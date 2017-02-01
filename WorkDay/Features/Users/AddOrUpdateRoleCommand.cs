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
    public class AddOrUpdateRoleCommand
    {
        public class AddOrUpdateRoleRequest : IRequest<AddOrUpdateRoleResponse>
        {
            public RoleApiModel Role { get; set; }
        }

        public class AddOrUpdateRoleResponse
        {

        }

        public class AddOrUpdateRoleHandler : IAsyncRequestHandler<AddOrUpdateRoleRequest, AddOrUpdateRoleResponse>
        {
            public AddOrUpdateRoleHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateRoleResponse> Handle(AddOrUpdateRoleRequest request)
            {
                var entity = await _dataContext.Roles
                    .SingleOrDefaultAsync(x => x.Id == request.Role.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Roles.Add(entity = new Role());
                entity.Name = request.Role.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateRoleResponse()
                {

                };
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

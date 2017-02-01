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
    public class RemoveUserCommand
    {
        public class RemoveUserRequest : IRequest<RemoveUserResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveUserResponse { }

        public class RemoveUserHandler : IAsyncRequestHandler<RemoveUserRequest, RemoveUserResponse>
        {
            public RemoveUserHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveUserResponse> Handle(RemoveUserRequest request)
            {
                var user = await _dataContext.Users.FindAsync(request.Id);
                user.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveUserResponse();
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

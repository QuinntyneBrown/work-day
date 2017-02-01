using MediatR;
using WorkDay.Data;
using WorkDay.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace WorkDay.Features.Users
{
    public class GetUserByUsernameQuery
    {
        public class GetUserByUsernameRequest : IRequest<GetUserByUsernameResponse>
        {
            public string Username { get; set; }
        }

        public class GetUserByUsernameResponse
        {
            public UserApiModel User { get; set; }
        }

        public class GetUserByUsernameHandler : IAsyncRequestHandler<GetUserByUsernameRequest, GetUserByUsernameResponse>
        {
            public GetUserByUsernameHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetUserByUsernameResponse> Handle(GetUserByUsernameRequest request)
            {
                return new GetUserByUsernameResponse()
                {
                    User = UserApiModel.FromUser(await _dataContext.Users.SingleAsync(x=>x.Username == request.Username))
                };
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

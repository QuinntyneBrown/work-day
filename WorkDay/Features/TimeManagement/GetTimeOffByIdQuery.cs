using MediatR;
using WorkDay.Data;
using WorkDay.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace WorkDay.Features.TimeManagement
{
    public class GetTimeOffByIdQuery
    {
        public class GetTimeOffByIdRequest : IRequest<GetTimeOffByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetTimeOffByIdResponse
        {
            public TimeOffApiModel TimeOff { get; set; } 
		}

        public class GetTimeOffByIdHandler : IAsyncRequestHandler<GetTimeOffByIdRequest, GetTimeOffByIdResponse>
        {
            public GetTimeOffByIdHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetTimeOffByIdResponse> Handle(GetTimeOffByIdRequest request)
            {                
                return new GetTimeOffByIdResponse()
                {
                    TimeOff = TimeOffApiModel.FromTimeOff(await _dataContext.TimeOffs.FindAsync(request.Id))
                };
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

using MediatR;
using WorkDay.Data;
using WorkDay.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace WorkDay.Features.TimeManagement
{
    public class GetTimeOffsQuery
    {
        public class GetTimeOffsRequest : IRequest<GetTimeOffsResponse> { }

        public class GetTimeOffsResponse
        {
            public ICollection<TimeOffApiModel> TimeOffs { get; set; } = new HashSet<TimeOffApiModel>();
        }

        public class GetTimeOffsHandler : IAsyncRequestHandler<GetTimeOffsRequest, GetTimeOffsResponse>
        {
            public GetTimeOffsHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetTimeOffsResponse> Handle(GetTimeOffsRequest request)
            {
                var timeOffs = await _dataContext.TimeOffs.ToListAsync();
                return new GetTimeOffsResponse()
                {
                    TimeOffs = timeOffs.Select(x => TimeOffApiModel.FromTimeOff(x)).ToList()
                };
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

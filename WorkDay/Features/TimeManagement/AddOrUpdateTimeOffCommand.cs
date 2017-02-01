using MediatR;
using WorkDay.Data;
using WorkDay.Data.Models;
using WorkDay.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace WorkDay.Features.TimeManagement
{
    public class AddOrUpdateTimeOffCommand
    {
        public class AddOrUpdateTimeOffRequest : IRequest<AddOrUpdateTimeOffResponse>
        {
            public TimeOffApiModel TimeOff { get; set; }
        }

        public class AddOrUpdateTimeOffResponse
        {

        }

        public class AddOrUpdateTimeOffHandler : IAsyncRequestHandler<AddOrUpdateTimeOffRequest, AddOrUpdateTimeOffResponse>
        {
            public AddOrUpdateTimeOffHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateTimeOffResponse> Handle(AddOrUpdateTimeOffRequest request)
            {
                var entity = await _dataContext.TimeOffs
                    .SingleOrDefaultAsync(x => x.Id == request.TimeOff.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.TimeOffs.Add(entity = new TimeOff());
                entity.Name = request.TimeOff.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateTimeOffResponse()
                {

                };
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}

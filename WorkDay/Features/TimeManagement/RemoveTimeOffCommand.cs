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
    public class RemoveTimeOffCommand
    {
        public class RemoveTimeOffRequest : IRequest<RemoveTimeOffResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveTimeOffResponse { }

        public class RemoveTimeOffHandler : IAsyncRequestHandler<RemoveTimeOffRequest, RemoveTimeOffResponse>
        {
            public RemoveTimeOffHandler(WorkDayDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveTimeOffResponse> Handle(RemoveTimeOffRequest request)
            {
                var timeOff = await _dataContext.TimeOffs.FindAsync(request.Id);
                timeOff.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveTimeOffResponse();
            }

            private readonly WorkDayDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}

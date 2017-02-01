using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WorkDay.Features.TimeManagement
{
    [Authorize]
    [RoutePrefix("api/timeOff")]
    public class TimeOffController : ApiController
    {
        public TimeOffController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateTimeOffCommand.AddOrUpdateTimeOffResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateTimeOffCommand.AddOrUpdateTimeOffRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateTimeOffCommand.AddOrUpdateTimeOffResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateTimeOffCommand.AddOrUpdateTimeOffRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetTimeOffsQuery.GetTimeOffsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetTimeOffsQuery.GetTimeOffsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetTimeOffByIdQuery.GetTimeOffByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetTimeOffByIdQuery.GetTimeOffByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveTimeOffCommand.RemoveTimeOffResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveTimeOffCommand.RemoveTimeOffRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}

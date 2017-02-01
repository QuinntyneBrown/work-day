using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WorkDay.Features.Employees
{
    [Authorize]
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateEmployeeCommand.AddOrUpdateEmployeeResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateEmployeeCommand.AddOrUpdateEmployeeRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateEmployeeCommand.AddOrUpdateEmployeeResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateEmployeeCommand.AddOrUpdateEmployeeRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetEmployeesQuery.GetEmployeesResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetEmployeesQuery.GetEmployeesRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetEmployeeByIdQuery.GetEmployeeByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetEmployeeByIdQuery.GetEmployeeByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveEmployeeCommand.RemoveEmployeeResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveEmployeeCommand.RemoveEmployeeRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}

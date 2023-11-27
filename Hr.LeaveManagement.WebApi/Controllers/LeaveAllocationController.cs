using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hr.LeaveManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<List<LeaveAllocationDto>>
    }
}

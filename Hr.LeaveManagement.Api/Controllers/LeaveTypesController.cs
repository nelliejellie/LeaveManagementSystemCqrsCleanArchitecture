using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using Hr.LeaveManagement.Domain.Features.LeaveType.Queries.GetAllLeaveTypes;
using Hr.LeaveMangement.Application.Features.LeaveTypeArea.Commands.CreateLeaveType;
using Hr.LeaveMangement.Application.Features.LeaveTypeArea.Commands.DeleteLeaveType;
using Hr.LeaveMangement.Application.Features.LeaveTypeArea.Commands.UpdateLeaveType;
using Hr.LeaveMangement.Application.Features.LeaveTypeArea.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hr.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            try
            {
                var leaveTypes = await _mediator.Send(new GetAllLeaveTypesQuery());
                return leaveTypes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDetailDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
            return Ok(leaveType);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateLeaveTypeCommand leaveType)
        {
            var response = await _mediator.Send(leaveType);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateLeaveTypeCommand leaveType)
        {
            await _mediator.Send(leaveType);
            return NoContent();
        }


        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTypeCommandQuery { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

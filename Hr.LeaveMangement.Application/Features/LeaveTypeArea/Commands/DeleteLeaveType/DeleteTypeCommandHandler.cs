using Hr.LeaveManagement.Domain;
using Hr.LeaveMangement.Application.Contracts.Persistence;
using Hr.LeaveMangement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveTypeArea.Commands.DeleteLeaveType
{
    public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommandQuery, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {

            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteTypeCommandQuery request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            //retrieve domain entity object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
            if (leaveTypeToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            //Remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            //Return record Id
            return Unit.Value;
        }
    }
}

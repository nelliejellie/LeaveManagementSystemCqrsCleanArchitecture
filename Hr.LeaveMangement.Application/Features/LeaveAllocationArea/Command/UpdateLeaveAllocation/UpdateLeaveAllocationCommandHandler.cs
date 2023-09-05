using AutoMapper;
using Hr.LeaveManagement.Domain;
using Hr.LeaveMangement.Application.Contracts.Persistence;
using Hr.LeaveMangement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveAllocationArea.Command.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public UpdateLeaveAllocationCommandHandler(
            IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveAllocationRepository leaveAllocationRepository
        )
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new UpdateLeaveAllocationCommandValidator(_leaveTypeRepository, _leaveAllocationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException("Invalid Leave Allocation", validationResult);
            }

            // convert to domain entity object
            var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);


            if (leaveAllocation is null)
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);

            // add to database
            _mapper.Map(request, leaveAllocation);

            // return Unit value
            await _leaveAllocationRepository.UpdateAsync(leaveAllocation);
            return Unit.Value;
        }
    }
}

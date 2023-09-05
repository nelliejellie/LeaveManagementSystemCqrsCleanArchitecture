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

namespace Hr.LeaveMangement.Application.Features.LeaveTypeArea.Commands.CreateLeaveType
{
    
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        
        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave type", validationResult);


            var leaveType = _mapper.Map<LeaveType>(request);

            await _leaveTypeRepository.CreateAsync(leaveType);

            return leaveType.Id;
        }
    }
}

using AutoMapper;
using Hr.LeaveManagement.Domain;
using Hr.LeaveMangement.Application.Contracts.Persistence;
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
        
        public CreateLeaveTypeCommandHandler(IMapper _mapper, ILeaveTypeRepository _leaveTypeRepository)
        {
            
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = _mapper.Map<LeaveType>(request);

            await _leaveTypeRepository.CreateAsync(leaveType);

            return leaveType.Id;
        }
    }
}

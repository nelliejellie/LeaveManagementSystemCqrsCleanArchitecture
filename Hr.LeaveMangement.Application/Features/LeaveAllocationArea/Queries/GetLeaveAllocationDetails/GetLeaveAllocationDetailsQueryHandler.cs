using AutoMapper;
using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using Hr.LeaveMangement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveAllocationArea.Queries.GetLeaveAllocationDetails
{
    public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationDetailsQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails(request.Id);
            return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
        }
    }
}

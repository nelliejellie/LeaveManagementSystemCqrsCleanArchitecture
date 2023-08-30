using AutoMapper;
using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using Hr.LeaveMangement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveTypeArea.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailHandler : IRequestHandler<GetLeaveTypeDetailsQuery,LeaveTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypeDetailHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
            var data = _mapper.Map<LeaveTypeDto>(leaveType);

            return data;
        }
    }
}

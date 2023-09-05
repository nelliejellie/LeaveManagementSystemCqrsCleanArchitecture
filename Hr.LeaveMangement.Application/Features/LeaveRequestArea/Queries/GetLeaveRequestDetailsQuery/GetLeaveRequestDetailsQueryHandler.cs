using AutoMapper;
using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using Hr.LeaveMangement.Application.Contracts.Persistence;
using Hr.LeaveMangement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveRequestArea.Queries.GetLeaveRequestDetailsQuery
{
    public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestDetailDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public GetLeaveRequestDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDetailDto> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequestDetailDto>(await _leaveRequestRepository.GetLeaveRequestsWithDetails(request.Id));

            if (leaveRequest == null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            // Add Employee details as needed
            //leaveRequest.Employee = await _userService.GetEmployee(leaveRequest.RequestingEmployeeId);

            return leaveRequest;
        }
    }
}

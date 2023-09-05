using AutoMapper;
using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using Hr.LeaveMangement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveRequestArea.Queries.GetLeaveRequestListQuery
{
    public class GetLeaveRequestListQueryHandler : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public GetLeaveRequestListQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
        {
            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
            var requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);

            if(request.IsLoggedInUser)
            {
                //var userId = _userService.UserId;
                //leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails(userId);

                //var employee = await _userService.GetEmployee(userId);
                requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
                //foreach (var req in requests)
                //{
                //    req.Employee = employee;
                //}
            }
            else
            {
                leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
                requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
                //foreach (var req in requests)
                //{
                //    req.Employee = await _userService.GetEmployee(req.RequestingEmployeeId);
                //}
            }
            return requests;
        }
    }
}

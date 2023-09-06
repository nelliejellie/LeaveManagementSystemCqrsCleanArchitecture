using AutoMapper;
using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using Hr.LeaveManagement.Domain.Features.LeaveType.Queries.GetAllLeaveTypes;
using Hr.LeaveMangement.Application.Contracts.Persistence;
using Hr.LeaveMangement.Application.Logger;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Domain.Features.LeaveTypeArea.Queries.GetAllLeaveTypes
{
    public class GetAllLeaveTypesHandler : IRequestHandler<GetAllLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetAllLeaveTypesHandler> _logger;

        public GetAllLeaveTypesHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetAllLeaveTypesHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAsync();
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            return data;
        }
    }
}

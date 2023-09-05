using AutoMapper;
using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using Hr.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.LeaveMangement.Application.Features.LeaveAllocationArea.Command.CreateLeaveAllocation;
using Hr.LeaveMangement.Application.Features.LeaveAllocationArea.Command.UpdateLeaveAllocation;

namespace Hr.LeaveMangement.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}

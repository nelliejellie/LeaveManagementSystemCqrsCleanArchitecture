using AutoMapper;
using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using Hr.LeaveMangement.Application.Features.LeaveTypeArea.Commands.CreateLeaveType;
using Hr.LeaveMangement.Application.Features.LeaveTypeArea.Commands.UpdateLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveTypeDetailDto, LeaveType>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}

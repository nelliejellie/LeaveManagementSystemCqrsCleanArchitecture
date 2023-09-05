using AutoMapper;
using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using Hr.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.MappingProfiles
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequestListDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequestDetailDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDetailDto>();
            //CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
            //CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
        }
    }
}

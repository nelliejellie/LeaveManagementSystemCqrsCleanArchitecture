using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveRequestArea.Queries.GetLeaveRequestListQuery
{
    public class GetLeaveRequestListQuery : IRequest<List<LeaveRequestListDto>>
    {
        public bool IsLoggedInUser { get; set; }
    }
}

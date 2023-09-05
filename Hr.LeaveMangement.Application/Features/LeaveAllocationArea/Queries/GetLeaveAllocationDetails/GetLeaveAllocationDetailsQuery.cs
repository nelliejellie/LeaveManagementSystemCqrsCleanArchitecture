using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveAllocationArea.Queries.GetLeaveAllocationDetails
{
    public class GetLeaveAllocationDetailQuery : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveAllocationArea.Command.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommand : IRequest<Unit>
    {
        public int LeaveTypeId { get; set; }
    }
}

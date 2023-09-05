using Hr.LeaveMangement.Application.Features.LeaveRequestArea.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveRequestArea.Command.UpdateLeaveRequestCommand
{
    public class UpdateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
    {
        public int Id { get; set; }
        public string RequestComments { get; set; } = string.Empty;
        public bool Cancelled { get; set; }
    }
}

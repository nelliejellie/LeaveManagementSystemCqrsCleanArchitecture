using Hr.LeaveMangement.Application.Features.LeaveRequestArea.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveRequestArea.Command.CreateLeaveRequestCommand
{
    public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
    {
        public string RequestComments { get; set; } = string.Empty;
    }
}

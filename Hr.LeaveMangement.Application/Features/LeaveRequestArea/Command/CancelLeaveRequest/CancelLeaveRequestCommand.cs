using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveRequestArea.Command.CancelLeaveRequest
{
    public class CancelLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

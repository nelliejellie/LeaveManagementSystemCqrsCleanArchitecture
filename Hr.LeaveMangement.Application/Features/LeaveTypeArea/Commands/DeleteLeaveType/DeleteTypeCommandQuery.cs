using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveTypeArea.Commands.DeleteLeaveType
{
    public class DeleteTypeCommandQuery: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

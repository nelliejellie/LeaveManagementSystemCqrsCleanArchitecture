using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveRequestArea.Command.DeleteLeaveRequestCommand
{
    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}

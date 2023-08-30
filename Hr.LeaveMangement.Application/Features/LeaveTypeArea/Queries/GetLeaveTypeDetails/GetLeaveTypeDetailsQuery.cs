using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Features.LeaveTypeArea.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQuery : IRequest<LeaveTypeDto>
    {
        public int Id { get; }

        public GetLeaveTypeDetailsQuery(int id)
        {
            Id = id;
        }
    }
}

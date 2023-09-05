using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Domain.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetAllLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
    {
    }
}

using Hr.LeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Domain
{
    public class LeaveRequest : BaseEntity
    {
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
        public bool? Cancelled { get; set; }
        public string? RequestComments { get; set; }
        public string RequestingEmployeeId { get; set; } = string.Empty;
    }
}

using Hr.LeaveManagement.Domain.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Domain.DTOs.RequestDto
{
    public class LeaveTypeDto : BaseDto
    {
        public string? Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
        
    }
}

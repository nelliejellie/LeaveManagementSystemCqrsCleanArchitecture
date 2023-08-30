using Hr.LeaveManagement.Domain.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Domain.DTOs.ResponseDto
{
    public class LeaveTypeDto : BaseDto
    {
        public string? Name { get; set; }
        public int DefaultDays { get; set; }
    }
}

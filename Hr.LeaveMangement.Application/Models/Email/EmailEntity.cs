using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Models.Email
{
    public class EmailEntity
    {
        public string? Receipient { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? FirstName { get; set; }
    }
}

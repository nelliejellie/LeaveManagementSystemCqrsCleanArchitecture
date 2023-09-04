using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application.Models.Email
{
    public class BrevoRequest
    {
        public Sender sender { get; set; }
        public List<To> to { get; set; }
        public string? subject { get; set; }
        public string? htmlContent { get; set; }
    }
}

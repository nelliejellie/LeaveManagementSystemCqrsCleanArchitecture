using Hr.LeaveMangement.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hr.LeaveMangement.Application.Contracts.Email
{
    public interface IEmailService
    {
        Task SendEmail(EmailEntity email);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Infrastructure.EmailService
{
    public static class Templates
    {
        public static string TemplateBuilder(string name, string body)
        {
            return @$"<html>
                   <body>
                       <h1 style='background-color: #336699; color: #FFFFFF; font-size: 24px;text-align: center;'>Welcome to IWallet</h1>
                       <p>Dear {name},</p>
                       <p>{body}.</p>
                       <p>Best regards,</p>
                       <p>The IWallet Team</p>
                   </body>
               </html>";

        }
    }
}

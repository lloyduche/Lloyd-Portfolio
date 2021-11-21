using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloyd.Data.Mail
{
    public interface IMailService
    {
        Task SendMailAsync(MailRequest mailRequest);
    }
}

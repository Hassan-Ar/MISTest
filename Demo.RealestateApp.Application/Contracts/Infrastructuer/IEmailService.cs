using Demo.RealestateApp.Application.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Application.Contracts.Infrastructuer
{
    public interface IEmailService
    {
        public Task<bool> SendEmail(Email email);
    }
}

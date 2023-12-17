using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Models.Mail;

namespace TravelOoty.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
        Task<bool> SendPasswordEmail(Email email);
    }
}

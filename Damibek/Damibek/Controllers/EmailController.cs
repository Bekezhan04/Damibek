using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Damibek.Models;
using ActionMailer.Net.Mvc;

namespace Damibek.Controllers
{
    public class EmailController : MailerBase
    {
        public EmailResult SendEmail(Message model)
        {
            To.Add("be04@yandex.kz");

            From = model.email;

            Subject = model.name;

            return Email("SendEmail", model);
        }
    }
}
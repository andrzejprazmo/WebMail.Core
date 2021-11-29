using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebMail.Application.Common.Const;
using WebMail.Domain.Entities;

namespace WebMail.Application.Common.Extensions
{
    public static class HttpContextExtensions
    {
        public static Credentials GetCredentials(this IHttpContextAccessor httpContextAccessor)
        {
            var claims = httpContextAccessor.HttpContext.User;
            return new Credentials
            {
                UserEmail = claims.FindFirstValue(CustomClaimTypes.UserEmail),
                UserPassword = claims.FindFirstValue(CustomClaimTypes.UserPassword),
                Mailbox = new Mailbox
                {
                    ImapAddress = claims.FindFirstValue(CustomClaimTypes.ImapAddress),
                    ImapPort = int.Parse(claims.FindFirstValue(CustomClaimTypes.ImapPort)),
                    ImapSsl = bool.Parse(claims.FindFirstValue(CustomClaimTypes.ImapSsl)),
                    SmtpAddress = claims.FindFirstValue(CustomClaimTypes.SmtpAddress),
                    SmtpPort = int.Parse(claims.FindFirstValue(CustomClaimTypes.SmtpPort)),
                    SmtpSsl = bool.Parse(claims.FindFirstValue(CustomClaimTypes.SmtpSsl)),
                }
            };
        }
    }
}

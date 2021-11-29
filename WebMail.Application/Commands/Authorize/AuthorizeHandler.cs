using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebMail.Application.Common;
using WebMail.Application.Common.Const;
using WebMail.Application.Common.Interfaces;
using WebMail.Application.Common.Validators;
using WebMail.Domain.Entities;

namespace WebMail.Application.Commands.Authorize
{
    public class AuthorizeHandler : IRequestHandler<AuthorizeRequest, CommandResult<AuthorizeResponse>>
    {
        private readonly IDatabaseRepository databaseRepository;
        private readonly IMailServerRepository mailServerRepository;
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthorizeHandler> logger;
        public AuthorizeHandler(ILogger<AuthorizeHandler> logger, IDatabaseRepository databaseRepository, IMailServerRepository mailServerRepository, IConfiguration configuration)
        {
            this.logger = logger;
            this.databaseRepository = databaseRepository;
            this.mailServerRepository = mailServerRepository;
            this.configuration = configuration;
        }
        public async Task<CommandResult<AuthorizeResponse>> Handle(AuthorizeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (EmailValidator.IsValidEmail(request.EmailAddress))
                {
                    var userEmail = new MailAddress(request.EmailAddress);
                    var mailbox = await databaseRepository.FindMailboxByName(userEmail.Host);
                    if (mailbox != null)
                    {
                        if (await mailServerRepository.Authorize(mailbox, request.EmailAddress, request.Password))
                        {
                            var user = await databaseRepository.FindUserByName(userEmail.Address);
                            return CommandResult<AuthorizeResponse>.Create(new AuthorizeResponse
                            {
                                IsAdmin = user != null,
                                UserEmail = request.EmailAddress,
                                Token = CreateToken(mailbox, request.EmailAddress, request.Password, user),
                            });
                        }
                    }
                }
                logger.LogError("Email is not valid", request);
                return CommandResult<AuthorizeResponse>.Create(null).WithError(ErrorCodes.LoginUserNotFound);
            }
            catch (Exception e)
            {
                logger.LogError(e, string.Empty, request);
                return CommandResult<AuthorizeResponse>.Create(null).WithError(ErrorCodes.SystemError);
            }
        }

        private string CreateToken(Mailbox mailbox, string userEmail, string password, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(CustomClaimTypes.UserEmail, userEmail),
                new Claim(CustomClaimTypes.UserPassword, password),
                new Claim(CustomClaimTypes.ImapAddress, mailbox.ImapAddress),
                new Claim(CustomClaimTypes.ImapPort, mailbox.ImapPort.ToString()),
                new Claim(CustomClaimTypes.ImapSsl, mailbox.ImapSsl.ToString()),
                new Claim(CustomClaimTypes.SmtpAddress, mailbox.SmtpAddress),
                new Claim(CustomClaimTypes.SmtpPort, mailbox.SmtpPort.ToString()),
                new Claim(CustomClaimTypes.SmtpSsl, mailbox.SmtpSsl.ToString()),
                new Claim(ClaimTypes.Role, user != null ? "ADMIN" : "USER"),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authorization:Secret"])), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

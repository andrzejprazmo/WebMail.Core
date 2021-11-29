using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WebMail.Application.Common;

namespace WebMail.Application.Commands.Authorize
{
    public record AuthorizeRequest(string EmailAddress, string Password) : IRequest<CommandResult<AuthorizeResponse>>;
}

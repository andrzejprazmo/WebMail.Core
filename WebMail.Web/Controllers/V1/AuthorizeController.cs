using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebMail.Application.Commands.Authorize;
using WebMail.Application.Common;

namespace WebMail.Web.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthorizeController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthorizeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<CommandResult<AuthorizeResponse>> Login(AuthorizeRequest request)
        {
            return await mediator.Send(request);
        }
    }
}

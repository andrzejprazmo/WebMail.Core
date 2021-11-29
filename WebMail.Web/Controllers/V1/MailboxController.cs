using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMail.Application.Queries.GetFolders;
using WebMail.Application.Queries.GetMailBody;
using WebMail.Application.Queries.GetMailPackage;

namespace WebMail.Web.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class MailboxController : ControllerBase
    {
        private readonly IMediator mediator;
        public MailboxController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("folders")]
        public async Task<GetFoldersResponse> GetFolders()
        {
            return await mediator.Send(new GetFoldersRequest());
        }

        [HttpGet]
        [Route("list")]
        public async Task<GetMailPackageResponse> GetMailPackage(string folderName, int pageNumber = 0)
        {
            return await mediator.Send(new GetMailPackageRequest(folderName, pageNumber));
        }

        [HttpGet]
        [Route("body")]
        public async Task<GetMailBodyResponse> GetMailBody(string folderName, int mailIndex)
        {
            return await mediator.Send(new GetMailBodyRequest(folderName, mailIndex));
        }
    }
}

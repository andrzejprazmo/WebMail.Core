using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebMail.Application.Common.Extensions;
using WebMail.Application.Common.Interfaces;

namespace WebMail.Application.Queries.GetMailBody
{
    public class GetMailBodyHandler : IRequestHandler<GetMailBodyRequest, GetMailBodyResponse>
    {
        private readonly IMailServerRepository mailServerRepository;
        private readonly IHttpContextAccessor httpContextAccessor; 
        public GetMailBodyHandler(IMailServerRepository mailServerRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.mailServerRepository = mailServerRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<GetMailBodyResponse> Handle(GetMailBodyRequest request, CancellationToken cancellationToken)
        {
            var mailBody = await mailServerRepository.GetMailBody(httpContextAccessor.GetCredentials(), request.FolderName, request.MailIndex);
            return new GetMailBodyResponse
            {
                Content = mailBody.Content,
                Date = mailBody.Date,
                Flagged = mailBody.Flagged,
                HasAttachments = mailBody.HasAttachments,
                Index = mailBody.Index,
                Seen = mailBody.Seen,
                Subject = mailBody.Subject,
                Senders = mailBody.Senders,
                Recipients = mailBody.Recipients,
            };
        }
    }
}

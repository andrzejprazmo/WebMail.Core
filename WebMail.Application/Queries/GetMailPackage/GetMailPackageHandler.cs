using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebMail.Application.Common.Extensions;
using WebMail.Application.Common.Helpers;
using WebMail.Application.Common.Interfaces;

namespace WebMail.Application.Queries.GetMailPackage
{
    public class GetMailPackageHandler : IRequestHandler<GetMailPackageRequest, GetMailPackageResponse>
    {
        private readonly IMailServerRepository mailServerRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration configuration;
        public GetMailPackageHandler(IMailServerRepository mailServerRepository, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.mailServerRepository = mailServerRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.configuration = configuration;
        }
        public async Task<GetMailPackageResponse> Handle(GetMailPackageRequest request, CancellationToken cancellationToken)
        {
            int pageSize = configuration.GetValue<int>("Mailbox:PageSize");
            var package = await mailServerRepository.GetMailPackage(httpContextAccessor.GetCredentials()
                , request.FolderName
                , pageSize
                , request.PageNumber);
            return new GetMailPackageResponse
            {
                PageNumber = package.PageNumber,
                PageCount = Package.GetPageCount(package.TotalCount, pageSize),
                List = package.List.ToList(),
            };
        }
    }
}

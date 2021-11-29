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
using WebMail.Domain.Entities;
using WebMail.Domain.Enums;

namespace WebMail.Application.Queries.GetFolders
{
    public class GetFoldersHandler : IRequestHandler<GetFoldersRequest, GetFoldersResponse>
    {
        private readonly IMailServerRepository mailServerRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public GetFoldersHandler(IMailServerRepository mailServerRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.mailServerRepository = mailServerRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<GetFoldersResponse> Handle(GetFoldersRequest request, CancellationToken cancellationToken)
        {
            var folders = await mailServerRepository.GetFolders(httpContextAccessor.GetCredentials());
            return new GetFoldersResponse
            {
                Folders = folders
                .Select(f => new Folder
                {
                    FolderName = f.FolderName,
                    FolderType = MapFolderType(f.FolderName)
                })
                .OrderBy(f => f.FolderType)
                .ToList()
            };

        }

        private FolderType MapFolderType(string folderName)
        {
            switch (folderName.ToUpper())
            {
                case "INBOX":
                    return FolderType.Inbox;
                case "ARCHIVE":
                    return FolderType.Archive;
                case "DRAFTS":
                    return FolderType.Drafts;
                case "SENT":
                    return FolderType.Sent;
                case "JUNK E-MAIL":
                    return FolderType.Junk;
                case "DELETED ITEMS":
                    return FolderType.Deleted;
                default:
                    return FolderType.Custom;
            }
        }
    }
}

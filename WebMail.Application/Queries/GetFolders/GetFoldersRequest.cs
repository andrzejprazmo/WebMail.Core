using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Application.Queries.GetFolders
{
    public record GetFoldersRequest() : IRequest<GetFoldersResponse>;
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Application.Queries.GetMailPackage
{
    public record GetMailPackageRequest(string FolderName, int PageNumber) : IRequest<GetMailPackageResponse>;
}

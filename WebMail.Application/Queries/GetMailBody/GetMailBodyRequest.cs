using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Application.Queries.GetMailBody
{
    public record GetMailBodyRequest(string FolderName, int MailIndex) : IRequest<GetMailBodyResponse>;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMail.Domain.Entities;

namespace WebMail.Application.Queries.GetMailPackage
{
    public class GetMailPackageResponse
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public IReadOnlyList<MailHeader> List { get; set; }
    }
}

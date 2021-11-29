using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Domain.Entities
{
    public class MailPackage
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<MailHeader> List { get; set; }
    }
}

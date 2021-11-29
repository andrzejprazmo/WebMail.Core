using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Domain.Entities
{
    public class Mailbox
    {
        public int Id { get; set; }
        public string DomainName { get; set; }
        public string ImapAddress { get; set; }
        public int ImapPort { get; set; }
        public bool ImapSsl { get; set; }
        public string SmtpAddress { get; set; }
        public int SmtpPort { get; set; }
        public bool SmtpSsl { get; set; }
    }
}

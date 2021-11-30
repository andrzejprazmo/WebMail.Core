using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Domain.Entities
{
    public class MailHeader
    {
        public int Index { get; set; }
        public MailAddress[] Senders { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public bool HasAttachments { get; set; }
        public bool Flagged { get; set; }
        public bool Seen { get; set; }
    }
}

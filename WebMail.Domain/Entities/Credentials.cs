using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Domain.Entities
{
    public class Credentials
    {
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public Mailbox Mailbox { get; set; }
    }
}

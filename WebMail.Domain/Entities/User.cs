using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int MailboxId { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}

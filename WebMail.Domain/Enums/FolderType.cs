using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Domain.Enums
{
    public enum FolderType
    {
        Inbox = 1,
        Sent = 2,
        Deleted = 3,
        Drafts = 4,
        Junk = 5,
        Archive = 6,
        Custom = 100,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMail.Domain.Entities;

namespace WebMail.Application.Common.Interfaces
{
    public interface IDatabaseRepository
    {
        Task<Mailbox> FindMailboxByName(string domainName);
        Task<User> FindUserByName(string userName);
    }
}

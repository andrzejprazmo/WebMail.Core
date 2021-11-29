using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMail.Domain.Entities;

namespace WebMail.Application.Common.Interfaces
{
    public interface IMailServerRepository
    {
        Task<bool> Authorize(Mailbox mailbox, string userEmail, string password);
        Task<IReadOnlyList<Folder>> GetFolders(Credentials credentials);
        Task<MailPackage> GetMailPackage(Credentials credentials, string folderName, int pageSize, int pageNumber = 0);
        Task<MailBody> GetMailBody(Credentials credentials, string folderName, int mailIndex);
    }
}

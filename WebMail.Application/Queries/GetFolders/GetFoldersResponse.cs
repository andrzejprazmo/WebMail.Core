using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMail.Domain.Entities;

namespace WebMail.Application.Queries.GetFolders
{
    public class GetFoldersResponse
    {
        public IReadOnlyList<Folder> Folders { get; set; }
    }
}

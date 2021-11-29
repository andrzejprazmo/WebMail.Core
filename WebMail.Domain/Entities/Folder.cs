using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMail.Domain.Enums;

namespace WebMail.Domain.Entities
{
    public class Folder
    {
        public string FolderName { get; set; }
        public FolderType FolderType { get; set; }
    }
}

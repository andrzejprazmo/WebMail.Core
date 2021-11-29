using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Application.Commands.Authorize
{
    public class AuthorizeResponse
    {
        public string UserEmail { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
    }
}

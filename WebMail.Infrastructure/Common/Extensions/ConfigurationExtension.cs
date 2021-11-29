using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Infrastructure.Common.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetWebMailConnectionString(this IConfiguration configuration) => configuration.GetConnectionString("WebmailDatabase");
    }
}

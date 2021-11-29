using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMail.Application.Common.Interfaces;
using WebMail.Infrastructure.Common.Extensions;
using WebMail.Infrastructure.Database;
using WebMail.Infrastructure.Mailkit;

namespace WebMail.Infrastructure.Installers
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDatabaseRepository>(new DatabaseRepository(configuration.GetWebMailConnectionString()));
            services.AddSingleton<IMailServerRepository, MailServerRepository>();

            return services;
        }
    }
}

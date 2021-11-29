using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMail.Application.Common.Interfaces;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.Database.Scripts;

namespace WebMail.Infrastructure.Database
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string connectionString;
        public DatabaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task<Mailbox> FindMailboxByName(string domainName)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<Mailbox>(Sql.FindMailboxByName, new { DomainName = domainName });
            }
        }

        public async Task<User> FindUserByName(string userName)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<User>(Sql.FindUserByName, new { UserName = userName });
            }
        }
    }
}

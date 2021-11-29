using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using WebMail.Infrastructure.Common.Extensions;

namespace WebMail.Infrastructure.Installers
{
    public class DatabaseInstaller
    {
        const string createMailboxTableSql = @"CREATE TABLE IF NOT EXISTS mailboxes (
	        mbx_id INTEGER PRIMARY KEY,
	        mbx_domain_name varchar(128) NOT NULL,
	        mbx_imap_address varchar(128) NOT NULL,
	        mbx_imap_port INT NOT NULL,
	        mbx_imap_ssl BIT NOT NULL,
	        mbx_smtp_address varchar(128) NOT NULL,
	        mbx_smtp_port INT NOT NULL,
	        mbx_smtp_ssl BIT NOT NULL
	        );";
        const string createUserTable = @"CREATE TABLE IF NOT EXISTS users (
	        usr_id INTEGER PRIMARY KEY,
	        mbx_id INTEGER,
	        usr_name varchar(128) NOT NULL,
	        usr_admin BIT NOT NULL,
	        FOREIGN KEY (mbx_id)
               REFERENCES mailboxes (mbx_id)
	        );";
        const string insertInitialMailbox = @"INSERT INTO mailboxes (mbx_domain_name, mbx_imap_address, mbx_imap_port, mbx_imap_ssl, mbx_smtp_address, mbx_smtp_port, mbx_smtp_ssl) 
            SELECT @DomainName, @ImapAddress, @ImapPort, @ImapSsl, @SmtpAddress, @SmtpPort, @SmtpSsl WHERE NOT EXISTS(SELECT * FROM mailboxes LIMIT 1);
            INSERT INTO users (mbx_id, usr_name, usr_admin) SELECT last_insert_rowid(), @EmailAddress, 1 WHERE NOT EXISTS(SELECT * FROM users LIMIT 1)";

        public static void Initialize(IConfiguration configuration)
        {
            using (var connection = new SqliteConnection(configuration.GetWebMailConnectionString()))
            {
                connection.Execute(createMailboxTableSql);
                connection.Execute(createUserTable);
                connection.Execute(insertInitialMailbox, new
                {
                    EmailAddress = configuration.GetValue<string>("InitialAccount:EmailAddress"),
                    DomainName = configuration.GetValue<string>("InitialAccount:DomainName"),
                    ImapAddress = configuration.GetValue<string>("InitialAccount:ImapAddress"),
                    ImapPort = configuration.GetValue<int>("InitialAccount:ImapPort"),
                    ImapSsl = configuration.GetValue<bool>("InitialAccount:ImapSsl"),
                    SmtpAddress = configuration.GetValue<string>("InitialAccount:SmtpAddress"),
                    SmtpPort = configuration.GetValue<int>("InitialAccount:SmtpPort"),
                    SmtpSsl = configuration.GetValue<bool>("InitialAccount:SmtpSsl"),
                });
            }
        }
    }
}

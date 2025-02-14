﻿using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMail.Application.Common.Interfaces;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.Mailkit.Mappers;

namespace WebMail.Infrastructure.Mailkit
{
    public class MailServerRepository : IMailServerRepository
    {
        public async Task<bool> Authorize(Mailbox mailbox, string userEmail, string password)
        {
            try
            {
                using (var imapClient = new ImapClient())
                {
                    imapClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await imapClient.ConnectAsync(mailbox.ImapAddress, mailbox.ImapPort, mailbox.SmtpSsl);
                    await imapClient.AuthenticateAsync(userEmail, password);
                    return true;
                }
            }
            catch (AuthenticationException)
            {
                return false;
            }
            catch (SslHandshakeException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IReadOnlyList<Folder>> GetFolders(Credentials credentials)
        {
            using (var imapClient = await GetImapClient(credentials))
            {
                var folders = await imapClient.GetFoldersAsync(imapClient.PersonalNamespaces[0]);
                return folders.Select(f => new Folder
                {
                    FolderName = f.Name,
                })
                .ToList();
            }
        }

        public async Task<MailPackage> GetMailPackage(Credentials credentials, string folderName, int pageSize, int pageNumber = 0)
        {
            using (var imapClient = await GetImapClient(credentials))
            {
                var folder = await imapClient.GetFolderAsync(folderName);
                if (folder != null)
                {
                    await folder.OpenAsync(FolderAccess.ReadOnly);
                    int totalCount = folder.Count;
                    var indexes = GetMinMaxIndex(totalCount, pageSize, pageNumber);
                    var mailItems = await folder.FetchAsync(indexes.minIndex, indexes.maxIndex, MessageSummaryItems.Full);
                    var list = mailItems.Select(mi => MailMapper.MapHeader(mi)).ToList();
                    await folder.CloseAsync();
                    return new MailPackage
                    {
                        TotalCount = totalCount,
                        PageNumber = pageNumber,
                        List = list.OrderByDescending(mi => mi.Date),
                    };
                }
                throw new Exception($"Cannot open folder {folderName}");
            }
        }

        public async Task<MailBody> GetMailBody(Credentials credentials, string folderName, int mailIndex)
        {
            using (var imapClient = await GetImapClient(credentials))
            {
                var folder = await imapClient.GetFolderAsync(folderName);
                if (folder != null)
                {
                    await folder.OpenAsync(FolderAccess.ReadOnly);
                    var mailBody = await folder.GetMessageAsync(mailIndex);
                    if (mailBody != null)
                    {
                        return MailMapper.MapBody(mailIndex, mailBody);
                    }
                    await folder.CloseAsync();
                }
            }
            throw new Exception($"Cannot open folder {folderName}");
        }

        private async Task<ImapClient> GetImapClient(Credentials credentials)
        {
            var imapClient = new ImapClient();
            imapClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await imapClient.ConnectAsync(credentials.Mailbox.ImapAddress, credentials.Mailbox.ImapPort, credentials.Mailbox.SmtpSsl);
            await imapClient.AuthenticateAsync(credentials.UserEmail, credentials.UserPassword);
            return imapClient;
        }

        private (int minIndex, int maxIndex) GetMinMaxIndex(int totalCount, int pageSize, int pageNumber)
        {
            int maxIndex = totalCount - 1 - pageNumber;
            int minIndex = maxIndex > pageSize ? (maxIndex - pageSize) + 1 : 0;
            return (minIndex, maxIndex);
        }
    }
}

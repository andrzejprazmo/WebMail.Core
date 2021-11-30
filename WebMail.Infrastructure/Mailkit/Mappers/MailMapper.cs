using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMail.Domain.Entities;

namespace WebMail.Infrastructure.Mailkit.Mappers
{
    public static class MailMapper
    {
        public static MailHeader MapHeader(IMessageSummary message)
        {
            return new MailHeader
            {
                Index = message.Index,
                Subject = message.Envelope.Subject,
                Date = message.Date.DateTime,
                HasAttachments = message.BodyParts.Any(bp => bp.ContentType.MediaType == "application"),
                Seen = message.Flags?.HasFlag(MessageFlags.Seen) ?? false,
                Flagged = message.Flags?.HasFlag(MessageFlags.Flagged) ?? false,
                Senders = MapMailAddresses(message.Envelope.Sender),
            };
        }

        public static MailBody MapBody(int index, MimeMessage body)
        {
            return new MailBody
            {
                Index = index,
                Content = body.HtmlBody,
                Date = body.Date.Date,
                Subject = body.Subject,
                HasAttachments = body.Attachments.Any(),
                Senders = MapMailAddresses(body.From),
                Recipients = MapMailAddresses(body.To),
            };
        }

        private static MailAddress MapMailAddress(InternetAddress address)
        {
            if (address is MailboxAddress)
            {
                return new MailAddress
                {
                    Name = address.Name,
                    Address = ((MailboxAddress)address).Address
                };
            }
            return new MailAddress
            {
                Name = address.Name,
            };
        }

        private static MailAddress[] MapMailAddresses(InternetAddressList senders)
        {
            if (senders != null && senders.Any())
            {
                return senders.Select(s => MapMailAddress(s)).ToArray();
            }
            return Array.Empty<MailAddress>();
        }
    }
}

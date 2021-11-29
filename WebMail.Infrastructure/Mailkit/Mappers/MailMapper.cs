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
                Sender = GetSender(message.Envelope),
            };
        }

        private static string GetSender(Envelope envelope)
        {
            if (envelope.Sender.Any())
            {
                var sender = envelope.Sender.First() as MailboxAddress;
                if (sender != null)
                {
                    if (!string.IsNullOrWhiteSpace(sender.Name))
                    {
                        return sender.Name;
                    }
                    return sender.Address;
                }
            }
            return string.Empty;
        }
    }
}

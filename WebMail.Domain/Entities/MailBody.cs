﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMail.Domain.Entities
{
    public class MailBody : MailHeader
    {
        public string Content { get; set; }
        public MailAddress[] Recipients { get; set; }
    }
}

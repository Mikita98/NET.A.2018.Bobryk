using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocks
{
    public sealed class MailEvent : EventArgs
    {
            public MailEvent()
            {
            }

            public DateTime MailDateTime { get; set; }
    }
}

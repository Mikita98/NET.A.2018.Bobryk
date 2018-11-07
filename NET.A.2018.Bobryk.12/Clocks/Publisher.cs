using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Clocks
{
    public class Publisher
    {
        private MailEvent mail;

        private EventHandler<MailEvent> newMail;

        public Publisher()
        {
            mail = new MailEvent();
        }

        public event EventHandler<MailEvent> NewMail
        {
            add
            {
                newMail = (EventHandler<MailEvent>)Delegate.Combine(newMail, value);
            }
            remove
            {
                newMail = (EventHandler<MailEvent>)Delegate.Remove(newMail, value);
            }
        }

        public void Publish(int miliseconds)
        {
            Timer tmrShow = new Timer();
            tmrShow.Interval = miliseconds;
            tmrShow.Elapsed += OnTimedEvent;
            tmrShow.AutoReset = true;
            tmrShow.Enabled = true;

        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            GenerateData();
            newMail?.Invoke(this, mail);
        }

        private void GenerateData()
        {
            mail.MailDateTime = DateTime.Now;
        }


        private void Notify()
        {
            newMail?.Invoke(this, mail);
        }
    }
}

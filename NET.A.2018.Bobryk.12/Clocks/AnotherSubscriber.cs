using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocks
{
    public class AnotherSubscriber
    {
        public void Register(Publisher mail)
        {
            mail.NewMail += Update;
        }

        public void Unregister(Publisher mail)
        {
            mail.NewMail -= Update;
        }

        private void Update(Object sender, MailEvent eventArgs)
        {
            Console.WriteLine(String.Format("Time now {0}", eventArgs.MailDateTime));
        }
    }
}

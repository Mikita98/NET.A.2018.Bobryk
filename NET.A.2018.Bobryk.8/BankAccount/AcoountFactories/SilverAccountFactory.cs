using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.AcoountFactories
{
    public class SilverAccountFactory : AccountFactory
    {
        public override BankAccount CreateNewAccount(string holderId)
        {
            return new SilverAccount(holderId);
        }
    }
}

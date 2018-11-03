using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.AcoountFactories
{
    class PlatinumAccountFactory : AccountFactory
    {
        public override BankAccount CreateNewAccount(Holder.Holder holder, string id)
        {
            throw new NotImplementedException();
        }
    }
}

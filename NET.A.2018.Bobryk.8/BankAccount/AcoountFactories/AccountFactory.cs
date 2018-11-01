using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.AcoountFactories
{
    public abstract class AccountFactory
    {
        public abstract BankAccount CreateNewAccount(Holder.Holder holder, string id);
    }
}

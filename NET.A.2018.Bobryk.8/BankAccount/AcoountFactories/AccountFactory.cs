using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.AcoountFactories
{
    /// <summary>
    /// Abstract class describing bank Account
    /// </summary>
    public abstract class AccountFactory
    {
        public abstract BankAccount CreateNewAccount(string holderId);
    }
}

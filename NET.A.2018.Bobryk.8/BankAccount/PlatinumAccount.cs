using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class PlatinumAccount : BankAccount
    {
        public PlatinumAccount(string holderId)
        {
            this.HolderId = holderId;
            this.DefaultBonus = 0.1m;
            this.BonusPoint = this.DefaultBonus;
            this.AccountId = this.CreateId();
            this.MinimumSum = -100000m;
        }
    }
}

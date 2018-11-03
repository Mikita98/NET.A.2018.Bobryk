using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class SilverAccount : BankAccount
    {
        public SilverAccount(string holderId)
        {
            this.HolderId = holderId;
            this.DefaultBonus = 0.01m;
            this.BonusPoint = this.DefaultBonus;
            this.MinimumSum = -10000m;
            this.AccountId = this.CreateId();
        }
    }
}

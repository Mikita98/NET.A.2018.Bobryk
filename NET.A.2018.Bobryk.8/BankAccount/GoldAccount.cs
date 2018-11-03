using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class GoldAccount : BankAccount
    {
        public GoldAccount(string holderId)
        {
            this.HolderId = holderId;
            this.DefaultBonus = 0.05m;
            this.BonusPoint = this.DefaultBonus;
            this.AccountId = this.CreateId();
            this.MinimumSum = -50000m;
        }
    }
}

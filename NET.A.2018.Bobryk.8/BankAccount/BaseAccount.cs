using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BaseAccount : BankAccount
    {
        public BaseAccount(string holderId) 
        {
            this.HolderId = holderId;
            this.DefaultBonus = 0.001m;
            this.BonusPoint = this.DefaultBonus;
            this.AccountId = this.CreateId();
            this.MinimumSum = -1000m;
        }
    }
}

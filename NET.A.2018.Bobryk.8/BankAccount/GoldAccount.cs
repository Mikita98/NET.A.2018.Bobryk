using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class GoldAccount : BankAccount
    {
        GoldAccount(Holder.Holder holder, string generationId) : base(holder, generationId)
        {
            this.holder = holder;
            this.DefaultBonus = 0.001m;
            this.bonusPoint = this.DefaultBonus;
            this.AccountId = generationId;
            this.minimumSum = -1000m;
        }
    }
}

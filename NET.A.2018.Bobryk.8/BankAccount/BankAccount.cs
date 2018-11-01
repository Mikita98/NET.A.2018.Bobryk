using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public abstract class BankAccount
    {
        private Holder.Holder _holder;

        private decimal fixedPoint;

        public decimal minimumSum { get; set; }

        private decimal balance { get; set; }

        public string AccountId
        {
            get => AccountId;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(nameof(value), "can't be equal to null or empty!");
                }

                AccountId = value;
            }
        }

        public decimal bonusPoint { get; set; }

        public Holder.Holder holder
        {
            get => _holder;
            set => _holder = value ?? throw new ArgumentException(nameof(value), "can't be equal to null or empty!");
        }

        public void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException(nameof(sum), "Deposit amount can not be less or equal to zero");
            }
            balance += sum* bonusPoint;
            bonusPoint = CalculateBonusPoint(sum);
        }

        public decimal DefaultBonus
        {
            get => fixedPoint;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(value), "can't be equal to null or empty!");
                }

                fixedPoint = value;
            }
        }

        public void WithDraw(decimal sum)
        {
            if(!IsValidBalance(balance - sum))
            {
                throw new ArgumentException(nameof(sum), "Number is bigger then maximum amount!");
            }
            balance -= sum;
            bonusPoint -= IsValidPoint(CalculateBonusPoint(sum));
        }

        public bool IsValidBalance(decimal balance)
        {
            if (balance < minimumSum)
            {
                return false;
            }
            else
                return true;
        }

        public decimal CalculateBonusPoint(decimal sum)
        {
            return (decimal)Math.Round(sum / 100);
        }

        public decimal IsValidPoint(decimal bonusPoint)
        {
            if (bonusPoint < fixedPoint)
            {
                return fixedPoint;
            }
            else
            {
                return bonusPoint;
            }
        }

        public BankAccount(Holder.Holder holder, string generationId) {
        }

    }

}

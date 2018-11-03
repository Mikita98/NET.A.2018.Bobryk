using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public abstract class BankAccount
    {
        public decimal FixedPoint { get; protected set; }

        public decimal MinimumSum { get; protected set; }

        public decimal Balance { get; protected set; }

        public string AccountId { get; protected set; }

        public decimal BonusPoint { get; protected set; }

        public string HolderId { get; protected set; }

        public decimal DefaultBonus
        {
            get => FixedPoint;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(value), "can't be equal to null or empty!");
                }

                FixedPoint = value;
            }
        }

        public void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException(nameof(sum), "Deposit amount can not be less or equal to zero");
            }

            Balance += sum * BonusPoint;
            BonusPoint = CalculateBonusPoint(sum);
        }

        public void WithDraw(decimal sum)
        {
            if (!IsValidBalance(Balance - sum))
            {
                throw new ArgumentException(nameof(sum), "Number is bigger then maximum amount!");
            }

            Balance -= sum;
            BonusPoint -= IsValidPoint(CalculateBonusPoint(sum));
        }

        public bool IsValidBalance(decimal balance)
        {
            if (balance < MinimumSum)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public decimal CalculateBonusPoint(decimal sum)
        {
            return (decimal)Math.Round(sum / 1000);
        }

        public decimal IsValidPoint(decimal bonusPoint)
        {
            if (bonusPoint < FixedPoint)
            {
                return FixedPoint;
            }
            else
            {
                return bonusPoint;
            }
        }

        public string CreateId()
        {
            Random random = new Random();
            string result = random.Next(0, int.MaxValue).ToString();
            return result;
        }
    }
}

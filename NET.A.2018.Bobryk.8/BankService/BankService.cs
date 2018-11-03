using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount;
using BankAccount.AcoountFactories;

namespace BankService
{
    public class BankService
    {
        private Holder.Holder _holder;

        public BankService(Holder.Holder holder)
        {
            if (holder.Equals(null))
            {
                throw new ArgumentException("Holder can't be null!");
            }

            _holder = holder;
        }

        public void Deposit(BankAccount.BankAccount bankAccount, decimal sum)
        {
            CheckNumbers(sum, bankAccount, _holder);
            bankAccount.Deposit(sum);
        }

        public void Withdraw(BankAccount.BankAccount bankAccount, decimal sum)
        {
            CheckNumbers(sum, bankAccount, _holder);
            bankAccount.Deposit(sum);
        }

        public void CreateAccount(AccountFactory accountFactory)
        {
            CheckFactory(accountFactory);
            BankAccount.BankAccount bankAccount = accountFactory.CreateNewAccount(_holder.holderId);
            _holder.accountsId.Add(bankAccount);
        }

        public void DeleteAccount(BankAccount.BankAccount bankAccount)
        {
            CheckAccount(bankAccount);
            _holder.accountsId.Remove(bankAccount);
        }

        private void CheckNumbers(decimal sum, BankAccount.BankAccount bankAccount, Holder.Holder holder)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum can't be less or equal zero!");
            }

            if (holder.Equals(null))
            {
                throw new ArgumentException("Holder can't be null!");
            }

            CheckAccount(bankAccount);
        }

        private void CheckAccount(BankAccount.BankAccount bankAccount)
        {
            if (bankAccount.Equals(null))
            {
                throw new ArgumentException("Bank account can't be null!");
            }
        }

        private void CheckFactory(AccountFactory account)
        {
            if (account.Equals(null))
            {
                throw new ArgumentException("Factory can't be null!");
            }
        }
    }
}

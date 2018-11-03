using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Holder.Holder holder1 = Holder.HolderFactory.Create("Mikita", "Bobryk", "Victorovich", "memesnotwar@gmail.com");
            Holder.Holder holder2 = Holder.HolderFactory.Create("Nikolay", "Bobrov", "Vladimirovich", "drakula@gmail.com");

            BankService.BankService bankService = new BankService.BankService(holder1);

            bankService.CreateAccount(new AcoountFactories.BaseAccountFactory());

            bankService.CreateAccount(new AcoountFactories.GoldAccountFactory());

            foreach (var temp in holder1.AccountsId)
            {
                Console.WriteLine(temp.ToString());
            }

            Console.WriteLine();

            foreach (var temp in holder1.AccountsId)
            {
                bankService.Deposit(temp, 400);
            }

            bankService.DeleteAccount(holder1.AccountsId[0]);

            foreach (var temp in holder1.AccountsId)
            {
                bankService.Withdraw(temp, 500);
            }

            foreach (var temp in holder1.AccountsId)
            {
                Console.WriteLine(temp.ToString());
            }

            bankService = new BankService.BankService(holder2);

            bankService.CreateAccount(new AcoountFactories.PlatinumAccountFactory());

            bankService.CreateAccount(new AcoountFactories.SilverAccountFactory());

            foreach (var temp in holder2.AccountsId)
            {
                Console.WriteLine(temp.ToString());
            }

            Console.WriteLine();

            foreach (var temp in holder2.AccountsId)
            {
                bankService.Deposit(temp, 400);
            }

            bankService.DeleteAccount(holder2.AccountsId[0]);

            foreach (var temp in holder2.AccountsId)
            {
                bankService.Withdraw(temp, 500);
            }

            foreach (var temp in holder2.AccountsId)
            {
                Console.WriteLine(temp.ToString());
            }

            Console.ReadKey();
        }
    }
}

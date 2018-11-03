using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holder
{
    public class Holder
    {
        public readonly string HolderId;

        public Holder(string firstName, string surName, string patronymic, string email)
        {
            this.FirstName = firstName;
            this.SurName = surName;
            this.Patronymic = patronymic;
            this.Email = email;
            this.HolderId = CreateId();
            this.AccountsId = new List<BankAccount.BankAccount>();
        }

        public string FirstName { get; private set; }

        public string SurName { get; private set; }

        public string Patronymic { get; private set; }

        public string Email { get; private set; }

        public List<BankAccount.BankAccount> AccountsId { get; private set; }

        private string CreateId()
        {
            Random random = new Random();
            string result = random.Next(0, int.MaxValue).ToString();
            return result;
        }
    }
}

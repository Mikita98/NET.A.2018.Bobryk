using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holder
{
    public class Holder
    {
        public string firstName { get; private set; }
        public string surName { get; private set; }
        public string patronymic { get; private set; }
        public string email { get; private set; }

        public readonly int holderId;

        Holder(string firstName, string SurName, string patronymic, string email)
        {
            this.firstName = firstName;
            this.surName = SurName;
            this.patronymic = patronymic;
            this.email = email;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holder
{
    public static class HolderFactory
    {
        public static Holder Create(string firstName, string surName, string patronymic, string email)
            => new Holder(firstName, surName, patronymic, email);
    }
}

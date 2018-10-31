using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public sealed class BankSingleton
    {
        private static readonly Lazy<BankSingleton> _instance = new Lazy<BankSingleton>(() => new BankSingleton());

        public List<int> accountsId;
        public List<int> holdersId;

        BankSingleton() { }

        public static BankSingleton Instance { get { return _instance.Value; } }
    }


    public abstract class BankAccount
    {
        public readonly int accountId;
        public List<int> holdersId;

        public abstract void DeleteHolder();

        public abstract void AddHolder();

        private int CreateAccountId()
        {
            BankSingleton singleton = BankSingleton.Instance;
            Random random = new Random();
            int id = random.Next(0, int.MaxValue);

            while (singleton.holdersId.Contains(id))
            {
                id = random.Next(0, int.MaxValue);
            }

            return id;
        }
        public BankAccount(Holder.Holder holder)
        {
            holdersId = new List<int>();
            holdersId.Add(holder.holderId);
            accountId = CreateAccountId();
        }
    }

    public class BaseAcount : BankAccount
    {
        public override void AddHolder()
        {
            throw new NotImplementedException(); 
        }

        public override void DeleteHolder()
        {
            throw new NotImplementedException();
        }

        BaseAcount(Holder.Holder holder) : base(holder)
        {
        }

    }
}

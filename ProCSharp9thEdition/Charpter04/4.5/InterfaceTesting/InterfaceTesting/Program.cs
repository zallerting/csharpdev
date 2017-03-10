using System;
using Wrox.ProCSharp.VenusBank;
using Wrox.ProCSharp.JupiterBank;

namespace Wrox.ProCSharp
{
    public interface IBankAccount
    {
        void PayIn(decimal account);
        bool WithDraw(decimal account);
        decimal Balance { get; }
    }
}

namespace Wrox.ProCSharp
{
    // 接口继承接口
    public interface ITransferAccount: IBankAccount
    {
        bool TransferTo(IBankAccount destination, decimal account);
    }
}

namespace Wrox.ProCSharp.VenusBank
{
    class SaveAccount : IBankAccount
    {
        private decimal balance;
        // 实现IBankAccount接口的方法
        public void PayIn(decimal account)
        {
            balance += account;
        }
        public bool WithDraw(decimal account)
        {
            if (balance >= account)
            {
                balance -= account;
                return true;
            }
            Console.WriteLine("Balance not enough, withdraw attempt failed.");
            return false;
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        // 重写System.Object类的Tostring方法
        public override string ToString()
        {
            return string.Format("VenusBank balance is {0, 6:C}", balance);
        }
    }
}

namespace Wrox.ProCSharp.JupiterBank
{
    class GoldAccount : ITransferAccount
    {
        private decimal balance;
        // 实现IBankAccount接口的方法
        public void PayIn(decimal account)
        {
            balance += account;
        }
        public bool WithDraw(decimal account)
        {
            if (balance >= account)
            {
                balance -= account;
                return true;
            }
            Console.WriteLine("Balace not enough, withdraw attempt failed.");
            return false;
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        // 实现ITransferAccount接口的方法
        public bool TransferTo(IBankAccount destination, decimal account)
        {
            bool result;
            result = WithDraw(account);
            if (result)
            {
                destination.PayIn(account);
            }
            return result;
        }
        // 重写System.Object类的ToString方法
        public override string ToString()
        {
            return string.Format("JupiterBank balance is {0, 6:C}", balance);
        }
    }
}

namespace Wrox.ProCSharp
{
    class MainEntryPoint
    {
        static void Main(String[] args)
        {
            // 创建两个接口引用变量，接口引用可以引用任何实现该接口的类
            IBankAccount vensusAccount = new SaveAccount();
            ITransferAccount jupiterAccount = new GoldAccount();
            vensusAccount.PayIn(200);
            jupiterAccount.PayIn(500);
            // 实现jupiterAccount向venusAccount账户转账
            jupiterAccount.TransferTo(vensusAccount, 100);
            Console.WriteLine(vensusAccount.ToString());
            Console.WriteLine(jupiterAccount.ToString());
            Console.Read();

        }
    }
}

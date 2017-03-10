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
            return string.Format("Balance is {0, 6:C}", balance);
        }
    }
}

namespace Wrox.ProCSharp.JupiterBank
{
    class GoldAccount : IBankAccount
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
        // 重写System.Object类的ToString方法
        public override string ToString()
        {
            return string.Format("Balance is {0, 6:C}", balance);
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
            IBankAccount jupiterAccount = new GoldAccount();
            vensusAccount.PayIn(200);
            vensusAccount.WithDraw(100);
            Console.WriteLine(vensusAccount.ToString());
            jupiterAccount.PayIn(500);
            jupiterAccount.WithDraw(600);
            jupiterAccount.WithDraw(100);
            Console.WriteLine(jupiterAccount.ToString());
            Console.Read();

            // 创建接口数组，其中每个元素都是不同的类
            IBankAccount[] accounts = new IBankAccount[2];
            accounts[0] = new SaveAccount();
            accounts[1] = new GoldAccount();
        }
    }
}
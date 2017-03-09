using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToStringTest
{
    class MainEntryPoint
    {
        static void Main(string[] args)
        {
            Money money = new Money();
            money.Account = 40M;
            Console.WriteLine("money.ToString() = " + money.ToString());
            Console.WriteLine("money.AddToAccount(20M) = " + money.AddToAccount(20M));

            Console.Read();
        }
    }

    class Money
    {
        private decimal account;
        public decimal Account
        {
            get
            {
                return account;
            }
            set
            {
                account = value;
            }
        }
        // 重写Object类的ToString方法
        public override string ToString()
        {
            return "$" + Account.ToString();
        }
    }

    static class MoneyExtension
    {
        // 创建Money类的静态扩展方法,
        // 第一个参数是要扩展的类型，放在this关键字的后面，
        // 告诉编译器这个方法是Money类型的一部分
        public static string AddToAccount(this Money money, decimal amountToAdd)
        {
            money.Account += amountToAdd;
            return money.Account.ToString();
        }
    }
}

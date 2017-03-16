using System;
using System.Collections.Generic;

namespace GenericsFunction
{
    // 创建IAccount接口
    public interface IAccount
    {
        // 定义两个只读属性
        string Name { get; }
        decimal Balance { get; }
    }
    // 创建实现IAccount接口的Account类
    public class Account:IAccount
    {
        // 创建两个实例属性
        public string Name { get; set; }
        public decimal Balance { get; set; }
        // 创建Account类的构造函数
        public Account(string name, decimal balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
    }
    class MainEntry
    {
        static void Main(String[] args)
        {
            // 应累加余额的所有账户都添加到List<Account>类型的列表中
            var accounts = new List<Account>()
            {
                new Account("Christian", 1500M),
                new Account("Stephanie", 2200M),
                new Account("Angela", 1800M),
                new Account("Matthias", 2400M)
            };
            // 调用泛型方法
            Console.WriteLine("Balance in total is " + AccumulateSample(accounts));
            // 调用泛型接口方法
            Console.WriteLine("Balance in total is " + Accumulate<Account>(accounts));
            // 调用泛型委托方法
            Console.WriteLine("Balance in total is " + Accumulate<Account,decimal>(
                accounts,(item,sum) => sum += item.Balance));
            Console.Read();
        }
        // 创建泛型方法
        public static decimal AccumulateSample(IEnumerable<Account> source)
        {
            decimal sum = 0;
            foreach (Account a in source)
            {
                sum += a.Balance;
            }
            return sum;
        }
        // 创建泛型接口方法
        public static decimal Accumulate<TAccount>(IEnumerable<TAccount> source)
            where TAccount: IAccount
        {
            decimal sum = 0;
            foreach (TAccount a in source)
            {
                sum += a.Balance;
            }
            return sum;
        }
        // 创建泛型委托Fun<T1, T2, TResult>的方法
        public static T2 Accumulate<T1, T2>(IEnumerable<T1> source, Func<T1, T2, T2> action)
        {
            T2 sum = default(T2);
            foreach (T1 item in source)
            {
                sum = action(item, sum);
            }
            return sum;
        }

    }
}

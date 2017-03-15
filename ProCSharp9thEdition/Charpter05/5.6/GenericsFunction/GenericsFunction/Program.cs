using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsFunction
{
    public class Accout
    {
        // 创建Account类的2个属性
        public string Name { get; set; }
        public int Balance { get; set; }
        // 创建Account类的构造函数
        public Accout(string name, int balance)
        {
            Name = name;
            Balance = balance;
        }
    }
    class MainEntry
    {
        static void Main(String[] args)
        {
            // 应累加余额的所有账户都添加到List<Account>类型的列表中
            var accounts = new List<Accout>()
            {
                new Accout("Christian", 1500),
                new Accout("Stephanie", 2200),
                new Accout("Angela", 1800),
                new Accout("Matthias", 2400)
            };
            Console.WriteLine("Balance in total is " + AccumulateSimple(accounts));
            Console.Read();
        }
        public static decimal AccumulateSimple(IEnumerable<Accout> source)
        {
            decimal sum = 0;
            foreach (Accout a in source)
            {
                sum += a.Balance;
            }
            return sum;
        }

    }
}

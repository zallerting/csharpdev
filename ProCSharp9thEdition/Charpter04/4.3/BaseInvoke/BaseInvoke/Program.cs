using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInvoke
{
    class CustomerAccount
    {
        public virtual decimal CalculatePrice()
        {
            // implementation
            return 10.0M;
        }
    }
    class GoldAccount: CustomerAccount
    {
        public override decimal CalculatePrice()
        {
            // 调用函数的基类版本
            return base.CalculatePrice() * 0.9M;
        }
        static void Main(String[] args)
        {
            Console.WriteLine(new CustomerAccount().CalculatePrice());
            Console.WriteLine(new GoldAccount().CalculatePrice());
            Console.Read();
        }
    }
}

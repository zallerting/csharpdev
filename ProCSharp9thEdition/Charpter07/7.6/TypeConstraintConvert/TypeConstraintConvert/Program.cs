using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConstraintConvert
{
    struct Currency
    {
        // 无符号数据类型确保Currency只能包含正值
        public uint Dollars;
        public ushort Cents;
        // Currency结构的构造函数
        public Currency(uint dollars, ushort cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;
        }
        // 重写Object类的ToString()方法
        public override string ToString()
        {
            return string.Format("${0}.{1, -2:00}", Dollars, Cents);
        }
        // 定义float类型隐式强制转换
        public static implicit operator float(Currency value)
        {
            return value.Dollars + (value.Cents / 100.0f);
        }
        // 定义Currency类型显式强制转换
        public static explicit operator Currency(float value)
        {
            checked
            {
                uint dollars = (uint)value;
                // System.Convert类的ToUInt16()方法来完成各种数字转换
                ushort cents = Convert.ToUInt16((value - dollars) * 100);
                return new Currency(dollars, cents);
            }
        }
    }
    class MainEntryPoint
    {
        static void Main(String[] args)
        {
            float amount = 45.63f;
            Currency amount2 = (Currency)amount;
            // 下面一行编译错误，试图隐式地使用一个显式类型强制转换
            // Currency amount3 = amount;
            Console.WriteLine("amount2 = " + amount2);

            try
            {
                Currency balance = new Currency(50, 35);
                Console.WriteLine(balance);
                Console.WriteLine("balance is " + balance);
                Console.WriteLine("balance is (using ToString()) " + balance.ToString());
                float balance2 = balance;
                Console.WriteLine("After converting to float, = " + balance2);
                balance = (Currency)balance2;
                Console.WriteLine("After converting back to Currency, = " + balance);
                Console.WriteLine("Now attempt to convert out of range value of " +
                    "-$50.50 to a Currency:");
                checked
                {
                    balance = (Currency)(-50.50);
                    Console.WriteLine("Result is " + balance.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred:" + e.Message);
            }


            Console.Read();
        }
    }
}

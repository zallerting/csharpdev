using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    struct Currency
    {
        // 创建两个属性
        public uint Dollars;
        public ushort Cents;
        // 创建构造函数
        public Currency(uint dollars, ushort cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;
        }
        // 重写Obejct类的ToString()方法
        public override string ToString()
        {
            return string.Format("${0}.{1,2:00}", Dollars, Cents);
        }
        public static string GetCurrencyUint()
        {
            return "Dollars";
        }
        // 操作符重载：float -> Currency
        public static explicit operator Currency(float value)
        {
            checked
            {
                uint dollars = (uint)value;
                ushort cents = (ushort)((value - dollars) * 100);
                return new Currency(dollars, cents);
            }
        }
        // 操作符重载：Currency -> float
        public static implicit operator float(Currency value)
        {
            return value.Dollars + (value.Cents / 100.0f);
        }
        // 操作符重载：uint -> Currency
        public static implicit operator Currency(uint value)
        {
            return new Currency(value, 0);
        }
        // 操作符重载：Currency -> uint
        public static implicit operator uint(Currency value)
        {
            return value.Dollars;
        }
    }
    class Program
    {
        // 创建委托
        private delegate string GetAString();
        static void Main(string[] args)
        {
            int i = 40;
            // 创建并初始化委托实例，将ToString()方法的地址赋予委托变量
            // 委托总是接受一个参数的构造函数
            GetAString firstStringMethod = new GetAString(i.ToString);
            Console.WriteLine("firstStringMethod() is {0} ", firstStringMethod());
            // 委托实例提供圆括号与调用委托类的Invoke()方法完全相同
            Console.WriteLine("firstStringMethod() is {0} ", firstStringMethod.Invoke());
            // 委托推断：编译器解析委托实例为需要的特定类型
            GetAString secondStringMethod = i.ToString;

            Currency balance = new Currency(34, 50);
            // firstStringMethod委托调用一个实例方法
            firstStringMethod = new GetAString(balance.ToString);
            Console.WriteLine("String is {0} ", firstStringMethod());
            // firstStringMethod委托调用一个静态方法
            firstStringMethod = new GetAString(Currency.GetCurrencyUint);
            Console.WriteLine("String is {0} ", firstStringMethod());

            Console.Read();
        }
    }
}

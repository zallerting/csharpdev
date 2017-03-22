using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    class MathOperations
    {
        public static double MultiplyByTwo(double value)
        {
            return value * 2;
        }
        public static double Square(double value)
        {
            return value * value;
        }
    }
    // 创建一个委托
    delegate double DoubleOp(double x);
    // 创建Func<in T, out TResult>的一个委托
    // 带一个参数T 返回值类型为TResult
    delegate double Func<in T, out TResult>(double x);
	
    class Program
    {
        static void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
            // 调用action委托实例封装的方法，相当于operations[i](value)
            double result = action(value);
            Console.WriteLine("Value is {0}, result of operations is {1}",
                value, result);
        }
        static void ProcessAndDisplayNumber2(Func<double, double> action, double value)
        {
            // 调用action委托实例封装的方法，相当于operations2[i](value)
            double result = action(value);
            Console.WriteLine("Value is {0}, result of operations2 is {1}",
                value, result);
        }
        static void Main(string[] args)
        {
            // 实例化DoubleOp委托的数组
            // 一旦定义了委托类，基本上可以实例化它的实例，
            // 所以可以将一些委托的实例放在该数组中。
            DoubleOp[] operations =
            {
                // 初始化为由MathOperations类实现的不同操作
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };
            // 遍历DobleOp数组
            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine("Using operations[{0}]:", i);
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
            }

            // 实例化Func<double, double>委托的数组
            Func<double, double>[] operations2 =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };
            // 遍历Func<in T, out TResult>数组
            for (int i = 0; i < operations2.Length; i++)
            {
                Console.WriteLine("Using operations2[{0}]", i);
                ProcessAndDisplayNumber2(operations2[i], 2.0);
                ProcessAndDisplayNumber2(operations2[i], 7.94);
                ProcessAndDisplayNumber2(operations2[i], 1.414);
            }

            Console.Read();
        }
    }
}

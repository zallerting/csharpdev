using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegate
{
    // 声明返回类型为void的委托
    delegate void Action(double x);

    class MathOperations
    {
        public static void MultiplyByTwo(double value)
        {
            double result = value * 2;
            Console.WriteLine("Multiplying by 2: {0} gives {1}", value, result);
        }
        public static void Square(double value)
        {
            double result = value * value;
            Console.WriteLine("Squaring: {0} gives {1}", value, result);
        }
    }

    class Program
    {
        static void ProcessAndDisplayNumber(Action<double> action, double value)
        {
            Console.WriteLine();
            Console.WriteLine("ProcessAndDisplayNumber called with value = {0}", value);
            // 调用action委托实例的封装方法，相当于MathOperations.MultiplyByTwo + 
            // MathOperations.Square
            action(value);
        }
        static void Main(string[] args)
        {
            // 多播委托：同一个委托按顺序调用多个方法
            Action<double> operations = MathOperations.MultiplyByTwo;
            operations += MathOperations.Square;

            ProcessAndDisplayNumber(operations, 2.0);
            ProcessAndDisplayNumber(operations, 7.94);
            ProcessAndDisplayNumber(operations, 1.414);

            Console.Read();
        }
    }
}

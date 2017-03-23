using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string mid = ", middle part, ";
            // lambda运算符"=>"的左边列出了需要的参数，
            // 右边定义了赋予lambda变量的方法的实现代码。
            Func<string, string> lambda = param =>
            {
                param += mid;
                param += " and this was added to the string.";
                return param;
            };
            // 调用lambda表达式
            Console.WriteLine(lambda("Start of string"));

            // 只有一个参数的lambda表达式
            // lambda表达式只有一条语句，在方法块内就不需要花括
            // 号及return语句，因为编译器会添加一条隐式return语句
            Func<string, string> lambda2 = s =>
                string.Format("change uppercase {0}", s.ToUpper());
            Console.WriteLine(lambda2("test"));
            // 多个参数的lambda表达式
            Func<double, double, double> twoParams = (x, y) => x * y;
            Console.WriteLine("twoParams(3, 2) = {0}", twoParams(3, 2));
            // 给变量名添加参数类型，便于匹配重载后的lambda版本
            Func<double, double, double> twoParamsWithType = (double x, double y) => x * y;
            Console.WriteLine("twoParamsWithType(4, 2) = {0}", twoParamsWithType(4, 2));

            Console.Read();
        }
    }
}
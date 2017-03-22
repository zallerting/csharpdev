using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAnonymityMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string mid = ", middle part,";
            // 匿名方法：用作委托的参数的一段代码
            Func<string, string> anonDel = delegate (string param)
            {
                param += mid;
                param += " and this was added to the string.";
                return param;
            };
            Console.WriteLine(anonDel("Start of string"));

            Console.Read();
        }
    }
}

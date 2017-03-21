using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // 装箱操作：值类型转换为引用类型
            int myIntNumber = 20;
            object myObject = myIntNumber;
            // 拆箱操作：引用类型转换为值类型
            int mySecondNumber = (int)myObject;

            // 拆箱操作的引用类型必须是由之前的值类型装箱而成
            object secondObject = "40";
            int myThirdNumber = (int)secondObject;

            Console.Read();
        }
    }
}

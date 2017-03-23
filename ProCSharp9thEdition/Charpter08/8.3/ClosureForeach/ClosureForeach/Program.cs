using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosureForeach
{
    class Program
    {
        static void Main(string[] args)
        {
            // 填充名为values的列表
            var values = new List<int> { 10, 20, 30 };
            // 变量funcs引用泛型列表，每个对象都引用Func<int>类型的委托
            var funcs = new List<Func<int>>();
            // 添加funcs列表中的每个元素
            foreach (var val in values)
            {
                funcs.Add(() => val);
            }
            // 迭代funcs列表，调用列表中引用的每个函数
            foreach (var f in funcs)
            {
                Console.WriteLine(f());
            }

            Console.Read();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupleTest
{
    class Program
    {
        // 创建元组的Divide()方法
        public static Tuple<int, int> Divide(int dividend, int divisor)
        {
            int result = dividend / divisor;
            int reminder = dividend % divisor;
            // 元组用静态Tuple类的Create()方法创建
            // Create()方法的泛型参数定义了要实例化的元组类型
            // 新建的元组用result和reminder变量初始化
            return Tuple.Create(result, reminder);
        }
        static void Main(string[] args)
        {
            // 调用Divide()方法
            var result = Divide(5, 2);
            // result.Item1:获取当前Tuple<T1, T2>对象的第一个分量的值
            // result.Item2:获取当前Tuple<T1, T2>对象的第二个分量的值
            Console.WriteLine("result of division: {0}, reminder: {1}", result.Item1, result.Item2);
            // 创建八元组, 最后一个模板参数为TRest，表示传递一个元组，这样就可以创建带任意个参数的元组了
            var tuple = Tuple.Create("Stephanie", "Aina", "Nagel", 2009, 6, 2, 1.37, Tuple.Create(52, 3490));
            // 输出八元组各个分量对应的值
            Console.WriteLine("八元组各分量的值依次为：第一分量：{0} 第二分量：{1} 第三分量：{2} 第四分量：{3} 第五分量：{4} 第六分量：{5} 第七分量：{6} 剩余分量：{7} ", 
                tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Rest);
            Console.Read();
        }
    }
}

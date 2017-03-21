using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReferenceEquals()方法
            Program x, y;
            x = new Program();
            y = new Program();
            // ReferenceEquals()认为null等于null
            Console.WriteLine("ReferenceEquals(null, null) = " + ReferenceEquals(null, null));
            // null不等于对象x
            Console.WriteLine("ReferenceEquals(null, x) = " + ReferenceEquals(null, x));
            // x与y指向不同的对象
            Console.WriteLine("ReferenceEquals(x, y) = " + ReferenceEquals(x, y));
            // 值类型需要转向到对象中再比较，故不同引用所以不相等
            int v = 10;
            Console.WriteLine("ReferenceEquals(v, v) = " + ReferenceEquals(v, v));

            Console.Read();
        }
    }
}

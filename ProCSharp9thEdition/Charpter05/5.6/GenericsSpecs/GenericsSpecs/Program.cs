using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsSpecs
{
    public class MethodOverloads
    {
        public void Foo<T>(T obj)
        {
            Console.WriteLine("Foo<T>(T obj), obj type:{0}", obj.GetType().Name);
        }
        public void Foo(int x)
        {
            Console.WriteLine("Foo(int x)");
        }
        public void Bar<T>(T obj)
        {
            Foo(obj);
        }
    }
    class MainEntry
    {
        static void Main(String[] args)
        {
            var test = new MethodOverloads();
            // 调用的方法是在编译期间确定的，而不是在运行期间确定的
            test.Foo(33);
            test.Foo("abc");
            // 将会调用Foo<T>(T obj)方法
            test.Bar(66);
            Console.Read();
        }
        
    }
}

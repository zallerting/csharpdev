using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumTest
{
    class HelloCollection
    {
        public IEnumerator<string> GetEnumerator()
        {
            /**
             * 包含yield语句的方法或属性也称之为迭代块。
             * 迭代块必须声明为返回IEnumerator或IEnumerable
             * 接口，或者这些接口的泛型版本。这个块可以
             * 包含多条yield return语句或yield break语句，
             * 当不能直接包含return语句。
             * yield return语句返回集合的一个元素并移动到
             * 下一个元素上，yield break可停止迭代。 
             */
            yield return "Hello";
            yield return "World";
        }
        public void HelloWorld()
        {
            var helloCollection = new HelloCollection();
            // 使用foreach语句迭代集合
            foreach (var s in helloCollection)
            {
                Console.WriteLine(s);
            }
        }
        static void Main(String[] args)
        {
            new HelloCollection().HelloWorld();
            Console.Read();
        }
    }
}

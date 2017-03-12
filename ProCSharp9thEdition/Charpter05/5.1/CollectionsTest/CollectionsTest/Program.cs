using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsTest
{
    class MainEnteryPoint
    {
        static void Main(string[] args)
        {
            // 创建System.Collections名称空间下ArrayList类的对象
            var list = new ArrayList();
            list.Add(44); // boxing, convert value type to reference type
            int i0 = (int)list[0]; // unboxing, convert reference type to value type
            Console.WriteLine("i0 = " + i0);
            foreach (int i1 in list)
            {
                Console.WriteLine("i1 = " + i1);
            }

            // System.Collections.Generic名称空间下List<T>类不使用对象，  
            // 而在使用时定义类型int，不再进行装箱与拆箱操作
            var list2 = new List<int>();
            list2.Add(55);
            // list2.Add("mystring"); // compile time error
            // list2.Add(new CollectionsTest());// List<int>强制指定传入list2的数据类型智能为int，其他类型无法添加
            int i2 = list2[0];
            Console.WriteLine("i2 = " + i2);
            foreach (int i3 in list2)
            {
                Console.WriteLine("i3 = " + i3);
            }

            // List<T>中使用string及MainEntryPoint类型进行实例化
            var stringList = new List<string>();
            stringList.Add("myString");
            var myClassList = new List<MainEnteryPoint>();
            myClassList.Add(new MainEnteryPoint());                

            Console.Read();
        }
    }
}

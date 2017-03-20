using System;

namespace CheckedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte b = 255;
            // 启用溢出检查
            //checked
            //{
            //    b++;
            //}
            // 禁止溢出检查
            unchecked
            {
                // 不会抛出异常，但会丢失数据，所以b得到的值为0
                b++;
            }
            Console.WriteLine("b = " + b.ToString());

            // is运算符：检查对象是否与特定的类型兼容
            int i = 10;
            if (i is object)
            {
                Console.WriteLine("i is a object.");
            }
            // as运算符：执行引用类型显式转换
            object o1 = "Some String";
            object o2 = 5;
            Console.WriteLine("o1 as string ? " + (o1 as string));
            Console.WriteLine("o2 as string ? " + (o2 as string));
            // sizeof运算符：确定栈中值类型需要的字节长度
            Console.WriteLine("sizeof(int) = " + sizeof(int));
            // typeof运算符：返回特定类型的System.Type对象
            Console.WriteLine("typeof(string) = " + typeof(string));
            // 可空类型和运算符
            int? a = null;
            Console.WriteLine("a + 4 = " + (a + 4)); // null
            Console.WriteLine("a * 5 = " + (a * 5)); // null
            int? c = -5;
            if (a >= c)
            {
                Console.WriteLine("a >= b");
            }
            else
            {
                Console.WriteLine("a < b");
            }
            // 空合并运算符??:
            // 第一个操作数不为null，则表达式的值为第一个操作数的值；
            // 第一个操作数为null，则表达式的值为第二个操作数的值；
            int? d = null;
            Console.WriteLine("a ?? 10 = " + (a ?? 10));
            int? e = 3;
            Console.WriteLine("e ?? 10 = " + (e ?? 10));



            Console.Read();
        }
    }
}

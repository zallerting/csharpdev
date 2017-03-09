using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterTest
{
    class MainEntryPoint
    {
        static void SomeFunction(int[] ints, int i)
        {
            ints[0] = 100;
            i = 100;
        }

        // ref关键字改变值传递为引用传递
        static void SomeFunction2(int[] ints, ref int i)
        {
            ints[0] = 100;
            i = 100;
        }

        // out关键字使传递给方法的参数无需初始化
        static void SomeFunction3(out int j)
        {
            j = 100;
        }

        static string FullName(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }

        // 可选参数为方法最后一个参数，且需提供默认值
        static void TestMethod(int optionalNumber, int notOptionalNumber = 20)
        {
            Console.WriteLine(optionalNumber);
        }

        static void Main(string[] args)
        {
            int i = 0;
            // Note i is declared but not initialized.
            int j;
            int[] ints = {0, 1, 2, 4, 8};
            
            // Display the original values.
            Console.WriteLine("i = " + i);
            Console.WriteLine("ints[0] = " + ints[0]);
            Console.WriteLine("Calling SomeFunction...");

            // After this method returns, ints will be changed,
            // but i will not.
            // 值传递不改变原值，引用传递改变原值
            SomeFunction(ints, i);
            Console.WriteLine("i = " + i);
            Console.WriteLine("ints[0] = " + ints[0]);

            // ref关键字改变值传递为引用传递，故原值被改变
            SomeFunction2(ints, ref i);
            Console.WriteLine("i = " + i);
            Console.WriteLine("ints[0] = " + ints[0]);

            // out关键字使传递给方法的参数无需初始化
            SomeFunction3(out j);
            Console.WriteLine("j = " + j);

            // 位置参数与命名参数调用
            Console.WriteLine(FullName("John", "Doe"));
            Console.WriteLine(FullName(lastName:"Doe", firstName:"John"));

            // 调用含有可选参数的方法
            TestMethod(20, 30);

            Console.ReadLine();
        }
    }
}

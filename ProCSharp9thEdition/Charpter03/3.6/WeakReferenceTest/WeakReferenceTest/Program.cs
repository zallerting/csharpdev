using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakReferenceTest
{
    class MathTest
    {
        public int value;
        public int GetSquare()
        {
            return value * value;
        }
        public int GetSquareOf(int x)
        {
            return x * x;
        }
        public static double GetPi()
        {
            return 3.1415926;
        }
    }
    class MainEntryPoint
    {
        static void Main(string[] args)
        {
            // 创建弱引用对象，可能在任意时刻被垃圾回收
            WeakReference mathReference = new WeakReference(new MathTest());
            MathTest mathTest;
            if (mathReference.IsAlive)
            {
                // WeakReference类继承Object类，强制转换为Target类
                mathTest = mathReference.Target as MathTest;
                mathTest.value = 30;
                Console.WriteLine("Value field of mathTest variable is " + mathTest.value);
                Console.WriteLine("Square is " + mathTest.GetSquareOf(mathTest.value));
            }
            else
            {
                Console.WriteLine("Reference is not available.");
            }

            // 强制垃圾回收
            GC.Collect();

            if (mathReference.IsAlive)
            {
                mathTest = mathReference.Target as MathTest;
                mathTest.value = 40;
                Console.WriteLine("Value field of mathTest variable is " + mathTest.value);
                Console.WriteLine("Square is " + mathTest.GetSquareOf(mathTest.value));

            }
            else
            {
                Console.WriteLine("Reference is not available.");
            }

            Console.Read();
        }
    }
}
